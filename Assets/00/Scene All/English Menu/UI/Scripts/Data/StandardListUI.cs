using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;

public class StandardListUI : MonoBehaviour
{
    public Transform listParent;      // Content
    public GameObject rowPrefab;      // Row with StandardRowUI
    public Button addButton;
    public GameObject managePanel, addPanel, editPanel;
    public ScrollRect scrollRect;     // ← assign the Scroll View here
    List<Standard> _cache = new List<Standard>();

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

        // fetch and sort in ascending order by standard number
        _cache = Queries.GetStandards();
        _cache = _cache.OrderBy(s => s.std_num).ToList();
        int i = 1;
        foreach (var s in _cache)
        {
            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<StandardRowUI>();

            var localS = s; // <-- capture once per-iteration

            row.Bind(i++, localS,
                onEdit: () => OpenEdit(localS),
                onDelete: () =>
                {
                    UIMessageManager.Instance.ShowConfirm(
                        $"Delete Standard '{localS.std_num}'?\n(Related subjects and practicals will be removed)",
                        onYes: () => { Queries.DeleteStandard(localS.std_id); Refresh(); }
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

    void ConfirmDelete(int standardId, string stdNum)
    {
        // super simple confirmation; replace with your popup if you have one
        bool ok = true; // set from popup result if using a UI dialog
        if (!ok) return;

        Queries.DeleteStandard(standardId);
        Refresh();
    }

    void OpenAdd()
    {
        managePanel.SetActive(false);
        addPanel.SetActive(true);
        var form = addPanel.GetComponent<StandardFormUI>();
        form.SetupForAdd(onDone: () => { addPanel.SetActive(false); managePanel.SetActive(true); Refresh(); });
    }

    void OpenEdit(Standard s)
    {
        managePanel.SetActive(false);
        editPanel.SetActive(true);
        var form = editPanel.GetComponent<StandardFormUI>();
        form.SetupForEdit(s, onDone: () => { editPanel.SetActive(false); managePanel.SetActive(true); Refresh(); });
    }
}
