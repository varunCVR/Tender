using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;
public class SubjectsAdminUI : MonoBehaviour
{
    [Header("List")]
    public Transform listParent;      // ScrollView/Viewport/Content
    public GameObject rowPrefab;      // SubjectRowUI
    public ScrollRect scrollRect;

    [Header("Panels")]
    public GameObject managePanel;    // this panel
    public GameObject addEditPanel;   // panel with SubjectFormUI
    public Button addButton;

    List<Subject> _cache = new List<Subject>();

    void OnEnable()
    {
        addButton.onClick.RemoveAllListeners();
        addButton.onClick.AddListener(OpenAdd);
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform c in listParent) Destroy(c.gameObject);

        var teachers = Queries.GetTeachers();
        var standards = Queries.GetStandards();
        _cache = Queries.GetSubjects();

        int i = 1;
        foreach (var s in _cache)
        {
            // resolve teacher & standard names (first link if multiple not supported)
            string teacherName = "-";
            string stdLabel = "-";

            var tid = Queries.GetFirstTeacherIdForSubject(s.subject_id);
            if (tid.HasValue)
            {
                var t = teachers.FirstOrDefault(x => x.teacher_id == tid.Value);
                if (t != null) teacherName = t.name;
            }

            var sid = Queries.GetFirstStdIdForSubject(s.subject_id);
            if (sid.HasValue)
            {
                var st = standards.FirstOrDefault(x => x.std_id == sid.Value);
                if (st != null) stdLabel = st.std_num;
            }

            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<SubjectRowUI>();
            var localS = s;
            row.Bind(i++, s.subject_name, teacherName, stdLabel,
                onEdit: () => OpenEdit(localS),
                onDelete: () => UIMessageManager.Instance.ShowConfirm(
                    $"Delete '{localS.subject_name}'?\n(Links & practicals will be removed)",
                    onYes: () => { Queries.DeleteSubjectCascade(localS.subject_id); Refresh(); }
                )
            );
        }

        // layout + snap to top
        var rt = (RectTransform)listParent;
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
        Canvas.ForceUpdateCanvases();
        if (scrollRect) scrollRect.verticalNormalizedPosition = 1f;
    }

    void OpenAdd()
    {
        managePanel.SetActive(false);
        addEditPanel.SetActive(true);
        addEditPanel.GetComponent<SubjectFormUI>().SetupForAdd(
            onDone: () => { addEditPanel.SetActive(false); managePanel.SetActive(true); Refresh(); }
        );
    }

    void OpenEdit(Subject s)
    {
        managePanel.SetActive(false);
        addEditPanel.SetActive(true);
        addEditPanel.GetComponent<SubjectFormUI>().SetupForEdit(s,
            onDone: () => { addEditPanel.SetActive(false); managePanel.SetActive(true); Refresh(); }
        );
    }
}