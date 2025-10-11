using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TeacherListUI : MonoBehaviour
{
    public Transform listParent;      // Content
    public GameObject rowPrefab;      // Row with TeacherRowUI
    public Button addButton;
    public GameObject managePanel, addPanel, editPanel;
    public ScrollRect scrollRect;     // ← assign the Scroll View here
    List<Teacher> _cache = new List<Teacher>();

    void OnEnable()
    {
        addButton.onClick.RemoveAllListeners();
        addButton.onClick.AddListener(OpenAdd);
        Refresh();
    }

    public void Refresh()
    {
        // clear old
        foreach (Transform c in listParent) Destroy(c.gameObject);

        // fetch
        // Inside TeacherListUI.Refresh(), where you build rows
        _cache = Queries.GetTeachers();
        int i = 1;
        foreach (var t in _cache)
        {
            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<TeacherRowUI>();

            var localT = t; // <-- capture once per-iteration

            row.Bind(i++, localT,
                onEdit: () => OpenEdit(localT),
                onDelete: () =>
                {
                    UIMessageManager.Instance.ShowConfirm(
                        $"Delete '{localT.name}'?",
                        onYes: () => { Queries.DeleteTeacher(localT.teacher_id); Refresh(); }
                    );
                }
            );
        }


        // force layout rebuild THEN snap to top
        var rt = listParent as RectTransform;
        LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
        Canvas.ForceUpdateCanvases();
        if (scrollRect != null)
        {
            // y=1 is top in Unity
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }
    void ConfirmDelete(int teacherId, string name)
    {
        // super simple confirmation; replace with your popup if you have one
        bool ok = true; // set from popup result if using a UI dialog
        if (!ok) return;

        Queries.DeleteTeacher(teacherId);
        Refresh();
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
