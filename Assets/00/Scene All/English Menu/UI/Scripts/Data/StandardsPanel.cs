using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class StandardsPanel : MonoBehaviour
{
    [Header("Prefabs / References")]
    public GameObject standardButtonPrefab; // prefab should have Button + TextMeshProUGUI (label)
    public Transform buttonsParent;         // parent transform to instantiate buttons under
    public Color normalColor = Color.white; // button background normal
    public Color activeColor = new Color(0.8f, 0.9f, 1f); // active highlight
    public StudentListUI studentListUI;     // reference to the list UI to call ShowForStandard

    List<GameObject> _spawned = new List<GameObject>();
    int _activeStdId = 0;

    void Start()
    {
        BuildButtons();
    }

    public void BuildButtons()
    {
        // clear old
        foreach (var g in _spawned) Destroy(g);
        _spawned.Clear();

        // Add an "All" button (stdId = 0)
        CreateButton("All", 0);

        var classes = Queries.GetClasses(); // uses Standards table
        foreach (var c in classes)
        {
            CreateButton(c.std_num, c.std_id);
        }

        // default select 'All'
        SetActiveButtonByStdId(0);

        // ensure layout updates immediately
        if (buttonsParent is RectTransform rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
            Canvas.ForceUpdateCanvases();
        }
    }

    void CreateButton(string label, int stdId)
    {
        if (standardButtonPrefab == null || buttonsParent == null) return;
        var go = Instantiate(standardButtonPrefab, buttonsParent);
        _spawned.Add(go);

        // try to find TMP label
        var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null) tmp.text = label;

        // wire button
        var btn = go.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => OnStandardClicked(stdId, go));
        }
    }

    void OnStandardClicked(int stdId, GameObject clickedButton)
    {
        _activeStdId = stdId;
        // update visuals
        SetActiveButtonByStdId(stdId);

        // inform StudentListUI
        if (studentListUI != null)
        {
            if (stdId == 0) studentListUI.ClearStandardFilter();
            else studentListUI.ShowForStandard(stdId);
        }
    }

    void SetActiveButtonByStdId(int stdId)
    {
        // naive highlight: iterate spawned, compare label text to standard value.
        foreach (var go in _spawned)
        {
            var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
            var btn = go.GetComponent<Button>();
            var img = go.GetComponent<Image>();
            bool active = false;
            if (tmp != null)
            {
                if (stdId == 0 && tmp.text == "All") active = true;
                else
                {
                    // find matching standard by label text (std_num) OR try to parse as int
                    var classes = Queries.GetClasses();
                    var match = classes.Find(c => c.std_num == tmp.text);
                    if (match != null && match.std_id == stdId) active = true;
                }
            }

            if (img != null)
            {
                img.color = active ? activeColor : normalColor;
            }

            // optionally change TMP color
            if (tmp != null)
            {
                tmp.color = active ? Color.black : Color.black;
            }
        }
    }
}
