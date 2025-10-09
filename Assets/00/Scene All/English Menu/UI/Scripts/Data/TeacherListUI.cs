using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TeacherListUI : MonoBehaviour
{
    [Header("List")]
    public Transform listParent;           // ScrollView Content
    public GameObject rowPrefab;           // prefab with name text + edit + delete buttons

    [Header("Panels")]
    public GameObject managePanel;         // this panel
    public GameObject addPanel;            // "Add Teacher" panel
    public GameObject editPanel;           // same UI as add, reused in edit mode

    [Header("Buttons")]
    public Button addButton;
    public Button backButton;              // optional

    List<Teacher> _cache = new List<Teacher>();

    void OnEnable()
    {
        addButton.onClick.RemoveAllListeners();
        addButton.onClick.AddListener(OpenAdd);

        if (backButton) {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => { managePanel.SetActive(false); });
        }

        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform c in listParent) Destroy(c.gameObject);

        _cache = Queries.GetTeachers();
        int idx = 1;
        foreach (var t in _cache)
        {
            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<TeacherRowUI>();
            row.Bind(idx++, t,
                onEdit:   () => OpenEdit(t),
                onDelete: () => { Queries.DeleteTeacher(t.teacher_id); Refresh(); }
            );
        }
    }

    void OpenAdd()
    {
        managePanel.SetActive(false);
        addPanel.SetActive(true);

        var form = addPanel.GetComponent<TeacherFormUI>();
        form.SetupForAdd(onDone: () => { addPanel.SetActive(false); managePanel.SetActive(true); Refresh(); });
    }

    void OpenEdit(Teacher t)
    {
        managePanel.SetActive(false);
        editPanel.SetActive(true);

        var form = editPanel.GetComponent<TeacherFormUI>();
        form.SetupForEdit(t, onDone: () => { editPanel.SetActive(false); managePanel.SetActive(true); Refresh(); });
    }
}
