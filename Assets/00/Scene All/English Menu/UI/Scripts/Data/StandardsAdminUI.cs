using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class StandardsAdminUI : MonoBehaviour
{
    public Transform listParent;
    public GameObject rowPrefab;
    public TMP_InputField stdInput;     // e.g., "9","10","11","12"
    public Button addBtn, updateBtn, deleteBtn;

    int selectedId = -1;

    void OnEnable() { Refresh(); Wire(); }

    void Wire()
    {
        addBtn.onClick.RemoveAllListeners();
        updateBtn.onClick.RemoveAllListeners();
        deleteBtn.onClick.RemoveAllListeners();

        addBtn.onClick.AddListener(() =>
        {
            var v = stdInput.text.Trim(); if (v == "") return;
            Queries.AddStandard(v); stdInput.text = ""; Refresh();
        });
        updateBtn.onClick.AddListener(() =>
        {
            if (selectedId < 0) return;
            var v = stdInput.text.Trim(); if (v == "") return;
            Queries.UpdateStandard(selectedId, v); Refresh();
        });
        deleteBtn.onClick.AddListener(() =>
        {
            if (selectedId < 0) return;
            UIMessageManager.Instance.ShowConfirm(
    "Delete this standard? (Practicals and links will also be removed)",
    onYes: () =>
    {
        Queries.DeleteStandard(selectedId);
        selectedId = -1;
        stdInput.text = "";
        UIMessageManager.Instance.ShowSuccess("Standard deleted.");
        Refresh();
    }
);

        });
    }   

    public void Refresh()
    {
        foreach (Transform c in listParent) Destroy(c.gameObject);
        var list = Queries.GetStandards();
        int i = 1;
        foreach (var s in list)
        {
            var go = Instantiate(rowPrefab, listParent);
            var row = go.GetComponent<SimpleRowUI>();
            row.Bind(i++, s.std_num, () => { selectedId = s.std_id; stdInput.text = s.std_num; });
        }
        var rt = (RectTransform)listParent;
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
        Canvas.ForceUpdateCanvases();
    }

    public int GetSelectedStandardId() => selectedId;
}
