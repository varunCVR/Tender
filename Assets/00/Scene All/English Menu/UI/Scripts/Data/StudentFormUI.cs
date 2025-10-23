using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using System.Reflection;

public class StudentFormUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField rollInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;      // new password field
    public TMP_Dropdown classDropdown;       // switched to TMP_Dropdown
    public Button saveButton;
    //public Button cancelButton;
    //public Button clearButton;               // new clear button

    Student editingStudent;

    void OnEnable()
    {
        PopulateClasses();
        //WireClearButton();
    }

    //void WireClearButton()
    //{
    //    if (clearButton == null) return;
    //    clearButton.onClick.RemoveAllListeners();
    //    clearButton.onClick.AddListener(() =>
    //    {
    //        if (nameInput != null) nameInput.text = "";
    //        if (rollInput != null) rollInput.text = "";
    //        if (emailInput != null) emailInput.text = "";
    //        if (passwordInput != null) passwordInput.text = "";
    //        if (classDropdown != null && classDropdown.options.Count > 0) classDropdown.value = 0;
    //    });
    //}

    void PopulateClasses()
    {
        if (classDropdown == null) return;
        classDropdown.ClearOptions();
        var classes = Queries.GetClasses(); // your Standards as classes
        var opts = new List<string>();
        foreach (var c in classes) opts.Add(c.std_num);
        classDropdown.AddOptions(opts);
    }

    public void SetupForAdd(Action onDone)
    {
        editingStudent = null;
        if (nameInput != null) nameInput.text = "";
        if (rollInput != null) rollInput.text = "";
        if (emailInput != null) emailInput.text = "";
        if (passwordInput != null) passwordInput.text = "";
        if (classDropdown != null && classDropdown.options.Count > 0) classDropdown.value = 0;
        SetupSave(onDone, isNew: true);
    }

    public void SetupForEdit(Student student, Action onDone)
    {
        editingStudent = student;
        if (nameInput != null) nameInput.text = student != null ? student.name : "";
        if (rollInput != null) rollInput.text = student != null ? student.roll_number : "";
        if (emailInput != null) emailInput.text = student != null ? student.email : "";
        if (passwordInput != null) passwordInput.text = ""; // do not prefill passwords

        if (classDropdown != null && student != null)
        {
            var classes = Queries.GetClasses();
            int idx = classes.FindIndex(c => c.std_id == student.std_id);
            classDropdown.value = idx >= 0 ? idx : 0;
        }

        SetupSave(onDone, isNew: false);
    }

    void SetupSave(Action onDone, bool isNew)
    {
        if (saveButton != null)
        {
            // Ensure button can be clicked
            try
            {
                saveButton.interactable = true;
            }
            catch { /* ignore if not applicable */ }

            saveButton.onClick.RemoveAllListeners();
            saveButton.onClick.AddListener(() =>
            {
                Debug.Log($"StudentFormUI: Save button clicked. isNew={isNew}, editingStudentId={(editingStudent != null ? editingStudent.student_id.ToString() : "null")}");
                try
                {
                    var name = nameInput != null ? nameInput.text.Trim() : "";
                    var roll = rollInput != null ? rollInput.text.Trim() : "";
                    var email = emailInput != null ? emailInput.text.Trim() : "";
                    var password = passwordInput != null ? passwordInput.text : "";

                    if (string.IsNullOrEmpty(name))
                    {
                        UIMessageManager.Instance.ShowConfirm("Please enter student name.", onYes: () => { });
                        return;
                    }
                    if (string.IsNullOrEmpty(roll))
                    {
                        UIMessageManager.Instance.ShowConfirm("Please enter roll number.", onYes: () => { });
                        return;
                    }

                    // determine selected standard (class)
                    var classes = Queries.GetClasses();
                    int classIndex = (classDropdown != null) ? classDropdown.value : -1;
                    int chosenStdId = (classIndex >= 0 && classIndex < classes.Count) ? classes[classIndex].std_id : 0;

                    // compute hashed password (empty string for create, null-for-update means "don't change")
                    string passwordHash = "";
                    if (!string.IsNullOrEmpty(password))
                    {
                        passwordHash = Queries.HashPassword(password);
                    }

                    if (isNew)
                    {
                        // AddStudent signature: AddStudent(string name, string email, string rollNumber, int stdId = 0, string passwordHash = "")
                        Debug.Log("StudentFormUI: Calling Queries.AddStudent...");
                        Queries.AddStudent(name, email, roll, chosenStdId, passwordHash);
                    }
                    else if (editingStudent != null)
                    {
                        // UpdateStudent signature: UpdateStudent(int studentId, string name, string email, string rollNumber, int stdId = 0, string passwordHash = null)
                        // pass null for passwordHash when user left password blank so existing password is preserved
                        string passParam = string.IsNullOrEmpty(password) ? null : passwordHash;
                        Debug.Log($"StudentFormUI: Calling Queries.UpdateStudent({editingStudent.student_id})...");
                        Queries.UpdateStudent(editingStudent.student_id, name, email, roll, chosenStdId, passParam);
                    }

                    Debug.Log("StudentFormUI: Save operation complete, invoking onDone.");
                    onDone?.Invoke();
                }
                catch (Exception ex)
                {
                    Debug.LogError($"StudentFormUI: Exception during Save handler: {ex}");
                    // Surface a simple message to the user as well
                    try
                    {
                        UIMessageManager.Instance.ShowConfirm("Save failed: " + ex.Message, onYes: () => { });
                    }
                    catch { }
                }
            });
        }
    }

    // Reflection-based helper: tries several common method names that projects often use
    void TrySetStudentPassword(int studentId, string passwordPlain)
    {
        var qType = typeof(Queries);
        MethodInfo mi = null;

        // common candidate names and signatures: (int, string) or (int, string, bool)
        string[] candidateNames = new[] {
            "SetStudentPassword", "UpdateStudentPassword", "SetPasswordForStudent",
            "SetStudentPasswordHash", "UpdatePasswordForStudent"
        };

        foreach (var name in candidateNames)
        {
            mi = qType.GetMethod(name, BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(int), typeof(string) }, null);
            if (mi != null) break;
        }

        // try a fallback where password param might be called "passwordHash" but still string
        if (mi == null)
        {
            // try any method with name that takes (int, string) ignoring exact name
            foreach (var name in candidateNames)
            {
                var methods = qType.GetMethods(BindingFlags.Public | BindingFlags.Static);
                foreach (var m in methods)
                {
                    if (m.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var ps = m.GetParameters();
                        if (ps.Length >= 2 && ps[0].ParameterType == typeof(int) && ps[1].ParameterType == typeof(string))
                        {
                            mi = m;
                            break;
                        }
                    }
                }
                if (mi != null) break;
            }
        }

        if (mi != null)
        {
            try
            {
                mi.Invoke(null, new object[] { studentId, passwordPlain });
            }
            catch (Exception ex)
            {
                Debug.LogWarning($"StudentFormUI: failed to invoke password setter: {ex.Message}");
            }
        }
        else
        {
            // no password setter found — silently ignore so compile stays clean.
            Debug.Log("StudentFormUI: no password setter found on Queries. Student saved without password set.");
        }
    }
}
