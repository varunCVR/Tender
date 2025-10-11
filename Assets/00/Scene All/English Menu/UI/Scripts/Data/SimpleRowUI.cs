using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleRowUI : MonoBehaviour
{
    public TMP_Text indexText;
    public TMP_Text labelText;
    public Button selectButton;

    public void Bind(int index, string label, System.Action onSelect)
    {
        if (indexText) indexText.text = index + ".";
        if (labelText) labelText.text = label;
        selectButton.onClick.RemoveAllListeners();
        selectButton.onClick.AddListener(() => onSelect?.Invoke());
    }
}
