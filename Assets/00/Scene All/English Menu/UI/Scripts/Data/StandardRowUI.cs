using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StandardRowUI : MonoBehaviour
{
    public TMP_Text indexText;     // "1.", "2." ...
    public TMP_Text numberText;    // "9", "10", "11", "12"
    public Button editButton;      // green pen
    public Button deleteButton;    // red cross

    Standard _data;

    public void Bind(int index, Standard data, System.Action onEdit, System.Action onDelete)
    {
        _data = data;
        if (indexText) indexText.text = index.ToString() + ".";
        if (numberText) numberText.text = data.std_num;

        editButton.onClick.RemoveAllListeners();
        deleteButton.onClick.RemoveAllListeners();

        editButton.onClick.AddListener(() => onEdit?.Invoke());
        deleteButton.onClick.AddListener(() => onDelete?.Invoke());
    }
}
