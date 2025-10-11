using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class SubjectFormUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField subjectNameInput;   // "Subject Name"
    public TMP_InputField standardInput;      // (optional text field; can ignore or use later)
    public TMP_Dropdown teacherDropdown;      // "Select" — teacher list

    [Header("Buttons")]
    public Button saveButton;
    public Button backButton;

    System.Action _onDone;
    int _editingSubjectId = -1;
    List<Teacher> _teachers;

    void OnEnable()
    {
        saveButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => _onDone?.Invoke());
        LoadTeachers();
    }

    void LoadTeachers()
    {
        _teachers = Queries.GetTeachers();
        teacherDropdown.options = _teachers
            .Select(t => new TMP_Dropdown.OptionData(t.name))
            .ToList();
        if (_teachers.Count == 0)
            UIMessageManager.Instance.ShowWarning("No teachers found. Add a teacher first.");
        teacherDropdown.value = 0;
        teacherDropdown.RefreshShownValue();
    }

    // ---- ADD mode ----
    public void SetupForAdd(System.Action onDone)
    {
        _onDone = onDone;
        _editingSubjectId = -1;
        if (subjectNameInput) subjectNameInput.text = "";
        if (standardInput)    standardInput.text = "";
        if (saveButton)       saveButton.onClick.AddListener(SaveAdd);
    }

    // ---- EDIT mode ----
    public void SetupForEdit(Subject s, System.Action onDone)
    {
        _onDone = onDone;
        _editingSubjectId = s.subject_id;

        if (subjectNameInput) subjectNameInput.text = s.subject_name;
        if (standardInput)    standardInput.text = ""; // optional

        // preselect current teacher (first link)
        var currentTid = Queries.GetFirstTeacherIdForSubject(s.subject_id);
        LoadTeachers(); // ensure list is fresh
        if (currentTid.HasValue)
        {
            int idx = _teachers.FindIndex(t => t.teacher_id == currentTid.Value);
            if (idx >= 0) { teacherDropdown.value = idx; teacherDropdown.RefreshShownValue(); }
        }

        if (saveButton) saveButton.onClick.AddListener(SaveEdit);
    }

    void SaveAdd()
    {
        var name = (subjectNameInput ? subjectNameInput.text : "").Trim();
        if (string.IsNullOrEmpty(name))
        {
            UIMessageManager.Instance.ShowWarning("Enter subject name.");
            return;
        }
        if (Queries.SubjectNameExists(name))
        {
            UIMessageManager.Instance.ShowError("Subject already exists.");
            return;
        }
        if (_teachers.Count == 0)
        {
            UIMessageManager.Instance.ShowWarning("Add a teacher first.");
            return;
        }

        int subjectId = Queries.AddSubject(name);

        // link to selected teacher
        int teacherId = _teachers[Mathf.Clamp(teacherDropdown.value, 0, _teachers.Count - 1)].teacher_id;
        Queries.LinkTeacherSubject(teacherId, subjectId);

        UIMessageManager.Instance.ShowSuccess("Subject added & assigned.");
        _onDone?.Invoke();
    }

    void SaveEdit()
    {
        var name = (subjectNameInput ? subjectNameInput.text : "").Trim();
        if (string.IsNullOrEmpty(name))
        {
            UIMessageManager.Instance.ShowWarning("Enter subject name.");
            return;
        }
        if (Queries.SubjectNameExistsForAnother(_editingSubjectId, name))
        {
            UIMessageManager.Instance.ShowError("Another subject with this name exists.");
            return;
        }
        if (_teachers.Count == 0)
        {
            UIMessageManager.Instance.ShowWarning("Add a teacher first.");
            return;
        }

        // update subject name
        Queries.UpdateSubject(_editingSubjectId, name);

        // re-link teacher (single selection model)
        int teacherId = _teachers[Mathf.Clamp(teacherDropdown.value, 0, _teachers.Count - 1)].teacher_id;
        Queries.UnlinkAllTeachersFromSubject(_editingSubjectId);
        Queries.LinkTeacherSubject(teacherId, _editingSubjectId);

        UIMessageManager.Instance.ShowSuccess("Subject updated & reassigned.");
        _onDone?.Invoke();
    }
}
