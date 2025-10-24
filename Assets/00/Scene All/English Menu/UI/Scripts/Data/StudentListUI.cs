using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class StudentListUI : MonoBehaviour
{
    public Transform listParent;      // Content
    public GameObject rowPrefab;      // Row with StudentRowUI
    public Button addButton;
    public GameObject managePanel, addPanel, editPanel;
    public ScrollRect scrollRect;     // assign the Scroll View here

    // currently selected standard filter (0 = all)
    int _currentStdId = 0;

    List<Student> _cache = new List<Student>();

    void OnEnable()
    {
        if (addButton != null)
        {
            addButton.onClick.RemoveAllListeners();
            addButton.onClick.AddListener(OpenAdd);
        }
        // Show all by default
        _currentStdId = 0;
        Refresh();
    }

    /// <summary>
    /// Call this to show students for a specific standard (stdId). Use 0 to clear filter.
    /// </summary>
    public void ShowForStandard(int stdId)
    {
        _currentStdId = stdId;
        Refresh();
    }

    /// <summary>
    /// Clears any standard filter and shows all students.
    /// </summary>
    public void ClearStandardFilter()
    {
        _currentStdId = 0;
        Refresh();
    }
    public void RefreshCurrent() => Refresh();

    public void Refresh()
    {
        // clear old
        if (listParent != null)
        {
            foreach (Transform c in listParent) Destroy(c.gameObject);
        }

        // fetch
        _cache = Queries.GetStudents();

        int i = 1;
        foreach (var s in _cache)
        {
            // apply standard filter if set
            if (_currentStdId != 0 && s.std_id != _currentStdId) continue;

            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<StudentRowUI>();

            var localS = s; // capture per-iteration

            row.Bind(i++, localS,
                onEdit: () => OpenEdit(localS),
                onDelete: () =>
                {
                    UIMessageManager.Instance.ShowConfirm(
                        $"Delete student '{localS.name}' (Roll: {localS.roll_number})?",
                        onYes: () =>
                        {
                            Queries.DeleteStudent(localS.student_id);
                            Refresh();
                        }
                    );
                }
            );
        }

        // force layout rebuild THEN snap to top
        if (listParent is RectTransform rt)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
            Canvas.ForceUpdateCanvases();
            if (scrollRect != null)
            {
                scrollRect.verticalNormalizedPosition = 1f;
            }
        }
    }

    void OpenAdd()
    {
        if (managePanel == null || addPanel == null) return;

        managePanel.SetActive(false);
        addPanel.SetActive(true);
        var form = addPanel.GetComponent<StudentFormUI>();
        if (form != null)
        {
            form.SetupForAdd(onDone: () =>
            {
                addPanel.SetActive(false);
                managePanel.SetActive(true);
                Refresh();
            });
        }
    }

    void OpenEdit(Student s)
    {
        if (managePanel == null || editPanel == null) return;

        managePanel.SetActive(false);
        editPanel.SetActive(true);
        var form = editPanel.GetComponent<StudentFormUI>();
        if (form != null)
        {
            form.SetupForEdit(s, onDone: () =>
            {
                editPanel.SetActive(false);
                managePanel.SetActive(true);
                Refresh();
            });
        }
    }
}
