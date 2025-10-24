using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TeacherStudentLogsUI : MonoBehaviour
{
    [Header("List")]
    public Transform contentParent;      // ScrollView/Viewport/Content
    public GameObject rowPrefab;         // has StudentLogRowUI
    public ScrollRect scrollRect;

    [Header("Filters (auto-hide if single/none)")]
    public GameObject stdContainer;      // parent of std dropdown (for hide/show)
    public TMP_Dropdown stdDropdown;
    public GameObject subjContainer;
    public TMP_Dropdown subjDropdown;

    private readonly List<GameObject> _rows = new();
    private List<Standard> _stds = new();
    private List<Subject> _subjs = new();

    void OnEnable()
    {
        BuildFilters();
        Refresh();
    }

    void BuildFilters()
    {
        int teacherId = AppSession.I?.TeacherId ?? 0;

        // STANDARDS
        _stds = Queries.GetStandardsForTeacher(teacherId);
        if (stdDropdown)
        {
            stdDropdown.onValueChanged.RemoveAllListeners();
            stdDropdown.ClearOptions();

            var opts = new List<TMP_Dropdown.OptionData>();
            opts.Add(new TMP_Dropdown.OptionData("All Standards"));
            foreach (var s in _stds) opts.Add(new TMP_Dropdown.OptionData($"Std {s.std_num}"));
            stdDropdown.AddOptions(opts);
            stdDropdown.value = 0;
            stdDropdown.onValueChanged.AddListener(_ => Refresh());

            if (stdContainer) stdContainer.SetActive(_stds.Count > 1);
        }

        // SUBJECTS
        _subjs = Queries.GetSubjectsForTeacher(teacherId);
        if (subjDropdown)
        {
            subjDropdown.onValueChanged.RemoveAllListeners();
            subjDropdown.ClearOptions();

            var sopts = new List<TMP_Dropdown.OptionData>();
            sopts.Add(new TMP_Dropdown.OptionData("All Subjects"));
            foreach (var s in _subjs) sopts.Add(new TMP_Dropdown.OptionData(s.subject_name));
            subjDropdown.AddOptions(sopts);
            subjDropdown.value = 0;
            subjDropdown.onValueChanged.AddListener(_ => Refresh());

            if (subjContainer) subjContainer.SetActive(_subjs.Count > 1);
        }
    }

    int GetSelectedStdId()
    {
        if (!stdDropdown || stdDropdown.value == 0) return 0;
        return _stds[stdDropdown.value - 1].std_id;
    }

    int GetSelectedSubjectId()
    {
        if (!subjDropdown || subjDropdown.value == 0) return 0;
        return _subjs[subjDropdown.value - 1].subject_id;
    }

    public void Refresh()
    {
        foreach (var r in _rows) Destroy(r);
        _rows.Clear();

        int stdId = GetSelectedStdId();        // 0 = all
        int subjId = GetSelectedSubjectId();   // 0 = all

        var list = Queries.GetLogsJoinedFiltered(stdId, subjId);
        Debug.Log($"[TeacherStudentLogsUI] rows={list.Count} (std={stdId}, subj={subjId})");

        int i = 1;
        foreach (var v in list)
        {
            var go = Instantiate(rowPrefab, contentParent);
            _rows.Add(go);
            go.GetComponent<StudentLogRowUI>().Bind(i++, v);
        }

        if (contentParent is RectTransform rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
            Canvas.ForceUpdateCanvases();
            if (scrollRect) scrollRect.verticalNormalizedPosition = 1f;
        }
    }
}
