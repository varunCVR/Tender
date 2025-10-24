using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AssignPracticalUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject rowPrefab;             // PracticalRowUI_Assign
    public TMP_Dropdown subjectDropdown;     // optional
    public GameObject dropdownContainer;
    public ScrollRect scrollRect;

    public bool ignoreTeacherFilterIfEmpty = true;

    private int _stdId;
    private int _teacherId;
    private readonly List<GameObject> _rows = new();
    private List<Subject> _subjects = new();

    void OnEnable()
    {
        if (_teacherId == 0 || _stdId == 0)
        {
            _teacherId = AppSession.I?.TeacherId ?? 0;
            _stdId = AppSession.I?.CurrentStdId ?? 0;
            Debug.Log($"[AssignPracticalUI] OnEnable grabbed session teacher={_teacherId}, std={_stdId}");
        }
        BuildSubjectFilter();
        RefreshList();
    }

    public void SetContext(int teacherId, int stdId)
    {
        _teacherId = teacherId;
        _stdId = stdId;
        Debug.Log($"[AssignPracticalUI] SetContext teacher={_teacherId}, std={_stdId}");
        BuildSubjectFilter();
        RefreshList();
    }

    void BuildSubjectFilter()
    {
        _subjects = Queries.GetSubjectsForTeacher(_teacherId);
        Debug.Log($"[AssignPracticalUI] TeacherSubjects count={_subjects.Count}");

        if (_subjects.Count == 0 && ignoreTeacherFilterIfEmpty)
        {
            var stdSubjects = Queries.GetSubjectsForStandard(_stdId);
            _subjects = stdSubjects ?? new List<Subject>();
            Debug.Log($"[AssignPracticalUI] Fallback to StdSubjects count={_subjects.Count}");
        }

        if (!subjectDropdown) return;

        subjectDropdown.onValueChanged.RemoveAllListeners();
        subjectDropdown.ClearOptions();

        var opts = new List<TMP_Dropdown.OptionData>();
        foreach (var s in _subjects) opts.Add(new TMP_Dropdown.OptionData(s.subject_name));
        subjectDropdown.AddOptions(opts);
        subjectDropdown.value = 0;
        subjectDropdown.onValueChanged.AddListener(_ => RefreshList());

        if (dropdownContainer) dropdownContainer.SetActive(_subjects.Count > 1);
    }

    int GetSelectedSubjectId()
    {
        if (_subjects.Count == 0) return 0;
        int idx = subjectDropdown ? subjectDropdown.value : 0;
        if (idx < 0 || idx >= _subjects.Count) idx = 0;
        return _subjects[idx].subject_id;
    }

    public void RefreshList()
    {
        foreach (var r in _rows) Destroy(r);
        _rows.Clear();

        if (_stdId == 0) { Debug.LogWarning("[AssignPracticalUI] stdId=0"); return; }

        int subjectId = GetSelectedSubjectId();
        if (subjectId == 0)
        {
            Debug.LogWarning("[AssignPracticalUI] subjectId=0 (no subjects linked?)");
            return;
        }

        var list = Queries.GetPracticalsFor(_stdId, subjectId);
        Debug.Log($"[AssignPracticalUI] Practicals count={list.Count} for std={_stdId}, subj={subjectId}");

        int i = 1;
        foreach (var p in list)
        {
            var go = Instantiate(rowPrefab, contentParent);
            _rows.Add(go);
            go.GetComponent<PracticalRowUI_Assign>().Bind(i++, p);
        }

        if (contentParent is RectTransform rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
            Canvas.ForceUpdateCanvases();
            if (scrollRect) scrollRect.verticalNormalizedPosition = 1f;
        }
    }
}
