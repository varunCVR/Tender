using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StandardsPanel : MonoBehaviour
{
    [Header("UI")]
    public Transform contentArea;                 // ScrollView/Viewport/Content
    public GameObject standardButtonPrefab;       // Simple Button prefab (with TMP_Text child)
    public GameObject standardsPanelRoot;         // This panel root (optional; used to hide self)
    public GameObject manageStudentPanelRoot;     // The Manage Student panel root
    public StudentListUI studentListUI;           // Your StudentListUI on Manage Student

    [Header("Options")]
    public bool includeAllButton = true;          // Adds an "All" entry

    private readonly List<GameObject> _spawned = new();

    void OnEnable()
    {
        BuildButtons();
    }

    public void BuildButtons()
    {
        // clear
        foreach (var go in _spawned) Destroy(go);
        _spawned.Clear();

        // optional "All" button
        if (includeAllButton)
        {
            MakeButton("All Students", 0);
        }

        // real standards
        var standards = Queries.GetStandards(); // ordered by std_num
        foreach (var std in standards)
        {
            string label = string.IsNullOrWhiteSpace(std.std_num)
                ? $"Std {std.std_id}"
                : $"Std {std.std_num}";
            MakeButton(label, std.std_id);
        }

        void MakeButton(string text, int stdId)
        {
            var go = Instantiate(standardButtonPrefab, contentArea);
            _spawned.Add(go);

            var btn = go.GetComponent<Button>();
            var label = go.GetComponentInChildren<TMP_Text>(true);
            if (label) label.text = text;

            btn.onClick.AddListener(() => OnStandardSelected(stdId));
        }
    }

    private void OnStandardSelected(int stdId)
    {
        AppSession.I.SetStandard(stdId);
        // hide this page, show Manage Student
        if (standardsPanelRoot != null) standardsPanelRoot.SetActive(false);
        if (manageStudentPanelRoot != null) manageStudentPanelRoot.SetActive(true);

        // filter the list
        if (studentListUI != null)
        {
            if (stdId == 0) studentListUI.ClearStandardFilter();
            else studentListUI.ShowForStandard(stdId);
        }
    }
}
