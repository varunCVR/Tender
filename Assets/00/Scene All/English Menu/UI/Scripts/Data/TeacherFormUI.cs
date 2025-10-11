// TeacherFormUI.cs  (attach this to BOTH: Add Teacher panel and Edit Teacher panel)
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

public class TeacherFormUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField nameInput;      // used for login (Teacher.name)
    public TMP_InputField emailInput;     // must be unique
    public TMP_InputField passwordInput;  // required for Add; optional for Edit

    [Header("Buttons")]
    public Button saveButton;
    public Button backButton;

    // Optional legacy label (unused now; kept in case it's referenced in scene)
    public TMP_Text errorLabel;

    System.Action _onDone;
    int _editingTeacherId = -1;

    void OnEnable()
    {
        // Ensure buttons don’t stack listeners when panel is re-opened
        if (saveButton) saveButton.onClick.RemoveAllListeners();
        if (backButton)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => _onDone?.Invoke());
        }
    }

    // --- Configure for ADD mode ---
    public void SetupForAdd(System.Action onDone)
    {
        _onDone = onDone;
        _editingTeacherId = -1;

        if (nameInput)     nameInput.text = "";
        if (emailInput)    emailInput.text = "";
        if (passwordInput) passwordInput.text = "";

        if (saveButton) saveButton.onClick.AddListener(SaveAdd);
    }

    // --- Configure for EDIT mode ---
    public void SetupForEdit(Teacher t, System.Action onDone)
    {
        _onDone = onDone;
        _editingTeacherId = t.teacher_id;

        if (nameInput)     nameInput.text = t.name;
        if (emailInput)    emailInput.text = t.email;
        if (passwordInput) passwordInput.text = ""; // optional on edit

        if (saveButton) saveButton.onClick.AddListener(SaveEdit);
    }

    // --- ADD flow ---
    void SaveAdd()
    {
        if (!Validate(out string n, out string e, out string p)) return;

        // Uniqueness checks BEFORE hitting DB
        if (Queries.TeacherEmailExists(e))
        {
            UIMessageManager.Instance.ShowError("Email already exists.");
            return;
        }
        // If you also want unique names for login, uncomment:
        // if (Queries.TeacherNameExists(n)) { UIMessageManager.Instance.ShowWarning("Name already exists."); return; }

        try
        {
            var hash = p; // or Sha256(p) if you decide to store hashed
            Queries.AddTeacher(n, e, hash);
            UIMessageManager.Instance.ShowSuccess("Teacher added successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"[Admin] AddTeacher failed: {ex.Message}");
            UIMessageManager.Instance.ShowError("Could not add teacher.");
        }
    }

    // --- EDIT flow ---
    void SaveEdit()
    {
        if (!Validate(out string n, out string e, out string p, allowEmptyPassword: true)) return;

        // Uniqueness check excluding current row
        if (Queries.TeacherEmailExistsForAnother(_editingTeacherId, e))
        {
            UIMessageManager.Instance.ShowWarning("Another teacher already uses this email.");
            return;
        }
        // If you also want unique names for login, uncomment:
        // if (Queries.TeacherNameExistsForAnother(_editingTeacherId, n)) { UIMessageManager.Instance.ShowWarning("Another teacher already uses this name."); return; }

        try
        {
            string hash = string.IsNullOrEmpty(p) ? null : p; // leave password unchanged if empty
            Queries.UpdateTeacher(_editingTeacherId, n, e, hash);
            UIMessageManager.Instance.ShowSuccess("Teacher updated successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning($"[Admin] UpdateTeacher failed: {ex.Message}");
            UIMessageManager.Instance.ShowError("Could not update teacher.");
        }
    }

    // --- Validation helpers ---
    bool Validate(out string n, out string e, out string p, bool allowEmptyPassword = false)
    {
        n = (nameInput ? nameInput.text : "").Trim();
        e = (emailInput ? emailInput.text : "").Trim();
        p = (passwordInput ? passwordInput.text : "");

        if (string.IsNullOrEmpty(n))
        {
            UIMessageManager.Instance.ShowWarning("Enter teacher name.");
            return false;
        }
        if (string.IsNullOrEmpty(e))
        {
            UIMessageManager.Instance.ShowWarning("Enter email.");
            return false;
        }
        if (!IsBasicEmail(e))
        {
            UIMessageManager.Instance.ShowWarning("Enter a valid email address.");
            return false;
        }
        if (!allowEmptyPassword && string.IsNullOrEmpty(p))
        {
            UIMessageManager.Instance.ShowWarning("Enter password.");
            return false;
        }
        // clear any legacy inline error text
        if (errorLabel) errorLabel.text = "";
        return true;
    }

    bool IsBasicEmail(string email)
    {
        // minimal email check; replace with stricter regex if desired
        // avoids heavy patterns on IL2CPP; simple and fast
        return email.Contains("@") && email.Contains(".");
    }

    string Sha256(string s)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
        return System.BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
    }
}
