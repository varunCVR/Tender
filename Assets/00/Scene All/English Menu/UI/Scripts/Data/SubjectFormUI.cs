using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class SubjectFormUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField subjectNameInput;
    public TMP_Dropdown teacherDropdown;
    public TMP_Dropdown standardDropdown;

    [Header("Buttons")]
    public Button saveButton;
    public Button backButton;

    System.Action _onDone;
    int _editingSubjectId = -1;

    List<Teacher> _teachers;
    List<Standard> _standards;

    void OnEnable()
    {
        if (saveButton) saveButton.onClick.RemoveAllListeners();
        if (backButton)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => _onDone?.Invoke());
        }
        LoadOptions();
    }

    void LoadOptions()
    {
        _teachers = Queries.GetTeachers();
        _standards = Queries.GetStandards();

        teacherDropdown.ClearOptions();
        standardDropdown.ClearOptions();

        var teacherOpts = new List<TMP_Dropdown.OptionData> { new TMP_Dropdown.OptionData("Select Teacher") };
        teacherOpts.AddRange(_teachers.Select(t => new TMP_Dropdown.OptionData(t.name)));

        var standardOpts = new List<TMP_Dropdown.OptionData> { new TMP_Dropdown.OptionData("Select Standard") };
        standardOpts.AddRange(_standards.Select(s => new TMP_Dropdown.OptionData(s.std_num)));

        teacherDropdown.AddOptions(teacherOpts);
        standardDropdown.AddOptions(standardOpts);

        teacherDropdown.value = 0;
        standardDropdown.value = 0;
        teacherDropdown.RefreshShownValue();
        standardDropdown.RefreshShownValue();

        if (_teachers.Count == 0)
            UIMessageManager.Instance.ShowWarning("No teachers available. Add a teacher first.");
        if (_standards.Count == 0)
            UIMessageManager.Instance.ShowWarning("No standards available. Add a standard first.");
    }

    // -------------------- ADD --------------------
    public void SetupForAdd(System.Action onDone)
    {
        _onDone = onDone;
        _editingSubjectId = -1;
        if (subjectNameInput) subjectNameInput.text = "";
        if (saveButton) saveButton.onClick.AddListener(SaveAdd);
    }

    void SaveAdd()
    {
        string name = (subjectNameInput ? subjectNameInput.text : "").Trim();

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

        if (_teachers.Count == 0 || _standards.Count == 0)
        {
            UIMessageManager.Instance.ShowWarning("Add teacher and standard first.");
            return;
        }

        int tIdx = teacherDropdown.value - 1;   // -1 means placeholder
        int sIdx = standardDropdown.value - 1;

        if (tIdx < 0 || sIdx < 0)
        {
            UIMessageManager.Instance.ShowWarning("Please select both Teacher and Standard.");
            return;
        }

        int teacherId = _teachers[tIdx].teacher_id;
        int stdId = _standards[sIdx].std_id;

        try
        {
            int subjectId = Queries.AddSubject(name);
            Queries.LinkTeacherSubject(teacherId, subjectId);
            Queries.LinkSubjectStandard(subjectId, stdId);
            UIMessageManager.Instance.ShowSuccess("Subject added successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            UIMessageManager.Instance.ShowError("Could not add subject.");
            Debug.LogWarning($"[Admin] AddSubject failed: {ex.Message}");
        }
    }

    // -------------------- EDIT --------------------
    public void SetupForEdit(Subject s, System.Action onDone)
    {
        _onDone = onDone;
        _editingSubjectId = s.subject_id;

        if (subjectNameInput) subjectNameInput.text = s.subject_name;

        var tid = Queries.GetFirstTeacherIdForSubject(s.subject_id);
        var sid = Queries.GetFirstStdIdForSubject(s.subject_id);

        LoadOptions();

        if (tid.HasValue)
        {
            int idx = _teachers.FindIndex(t => t.teacher_id == tid.Value);
            if (idx >= 0) { teacherDropdown.value = idx + 1; teacherDropdown.RefreshShownValue(); }
        }

        if (sid.HasValue)
        {
            int idx = _standards.FindIndex(st => st.std_id == sid.Value);
            if (idx >= 0) { standardDropdown.value = idx + 1; standardDropdown.RefreshShownValue(); }
        }

        if (saveButton) saveButton.onClick.AddListener(SaveEdit);
    }

    void SaveEdit()
    {
        string name = (subjectNameInput ? subjectNameInput.text : "").Trim();

        if (string.IsNullOrEmpty(name))
        {
            UIMessageManager.Instance.ShowWarning("Enter subject name.");
            return;
        }

        if (Queries.SubjectNameExistsForAnother(_editingSubjectId, name))
        {
            UIMessageManager.Instance.ShowError("Another subject already uses this name.");
            return;
        }

        int tIdx = teacherDropdown.value - 1;
        int sIdx = standardDropdown.value - 1;

        if (tIdx < 0 || sIdx < 0)
        {
            UIMessageManager.Instance.ShowWarning("Please select both Teacher and Standard.");
            return;
        }

        int teacherId = _teachers[tIdx].teacher_id;
        int stdId = _standards[sIdx].std_id;

        try
        {
            Queries.UpdateSubject(_editingSubjectId, name);
            Queries.UnlinkAllTeachersFromSubject(_editingSubjectId);
            Queries.LinkTeacherSubject(teacherId, _editingSubjectId);

            Queries.UnlinkAllStandardsFromSubject(_editingSubjectId);
            Queries.LinkSubjectStandard(_editingSubjectId, stdId);

            UIMessageManager.Instance.ShowSuccess("Subject updated successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            UIMessageManager.Instance.ShowError("Could not update subject.");
            Debug.LogWarning($"[Admin] UpdateSubject failed: {ex.Message}");
        }
    }
}
