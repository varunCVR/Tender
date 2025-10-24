using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PracticalRowUI_Assign : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text indexText;        // "1."
    public TMP_Text titleText;        // "Prac. Name"
    public Button allowButton;        // green 
    public Button denyButton;         // red

    private Practical _data;
    private System.Action _onChanged; // optional callback to parent

    public void Bind(int index, Practical p, System.Action onChanged = null)
    {
        _data = p;
        _onChanged = onChanged;

        if (indexText) indexText.text = index.ToString() + ".";
        if (titleText) titleText.text = string.IsNullOrWhiteSpace(p.title) ? $"Practical {p.practical_id}" : p.title;

        allowButton.onClick.RemoveAllListeners();
        denyButton.onClick.RemoveAllListeners();

        allowButton.onClick.AddListener(() => SetAllowed(true));
        denyButton.onClick.AddListener(() => SetAllowed(false));

        RefreshVisual();
    }

    void SetAllowed(bool allowed)
    {
        if (_data == null) return;
        if ((_data.is_allowed == 1) == allowed) return; // no-op

        Queries.SetPracticalAllowed(_data.practical_id, allowed);
        _data.is_allowed = allowed ? 1 : 0;
        RefreshVisual();
        _onChanged?.Invoke();
    }

    void RefreshVisual()
    {
        // No color-state needed; just enable/disable which button is “active”.
        // When allowed => disable  (already active), enable
        // When not allowed => enable , disable 
        bool allowed = _data.is_allowed == 1;

        if (allowButton) allowButton.interactable = !allowed;
        if (denyButton) denyButton.interactable = allowed;
    }
}
