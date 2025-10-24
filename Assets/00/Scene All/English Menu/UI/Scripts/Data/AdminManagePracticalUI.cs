// AdminManagePracticalUI.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AdminManagePracticalUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject rowPrefab;           // reuse PracticalRowUI_Assign
    public TMP_Dropdown standardDropdown;  // optional filter
    public ScrollRect scrollRect;

    private readonly List<GameObject> _rows = new();

    void OnEnable()
    {
        BuildStandardFilter();
        Refresh();
    }

    void BuildStandardFilter()
    {
        if (!standardDropdown) return;
        standardDropdown.onValueChanged.RemoveAllListeners();
        standardDropdown.ClearOptions();

        var standards = Queries.GetStandards();
        var options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData("All Standards"));
        foreach (var s in standards) options.Add(new TMP_Dropdown.OptionData($"Std {s.std_num}"));

        standardDropdown.AddOptions(options);
        standardDropdown.value = 0;
        standardDropdown.onValueChanged.AddListener(_ => Refresh());
    }

    int GetSelectedStdId()
    {
        if (!standardDropdown) return 0; // 0 => all
        int idx = standardDropdown.value;
        if (idx <= 0) return 0;
        var standards = Queries.GetStandards();
        // dropdown option 0 is "All", so shift by -1
        return standards[idx - 1].std_id;
    }

    public void Refresh()
    {
        foreach (var r in _rows) Destroy(r);
        _rows.Clear();

        int stdId = GetSelectedStdId();

        List<Practical> list;
        if (stdId == 0)
        {
            // all practicals (ordered by std/subject/title)
            list = Queries.GetAllPracticalsOrdered();
        }
        else
        {
            // show practicals for that standard across all subjects
            list = Queries.GetPracticalsForStandard(stdId);
        }

        Debug.Log($"[AdminManagePracticalUI] Showing count={list.Count}");

        int i = 1;
        foreach (var p in list)
        {
            var go = Instantiate(rowPrefab, contentParent);
            _rows.Add(go);
            var ui = go.GetComponent<PracticalRowUI_Assign>();
            ui.Bind(i++, p, onChanged: null);
        }

        if (contentParent is RectTransform rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
            Canvas.ForceUpdateCanvases();
            if (scrollRect) scrollRect.verticalNormalizedPosition = 1f;
        }
    }
}
