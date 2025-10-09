using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TeacherRowUI : MonoBehaviour
{
    public TMP_Text indexText;     // “1.”, “2.” …
    public TMP_Text nameText;      // “xyz”
    public Button editButton;      // green pen
    public Button deleteButton;    // red cross

    Teacher _data;

    public void Bind(int index, Teacher data, System.Action onEdit, System.Action onDelete)
    {
        _data = data;
        if (indexText) indexText.text = index.ToString() + ".";
        if (nameText)  nameText.text  = data.name;

        editButton.onClick.RemoveAllListeners();
        deleteButton.onClick.RemoveAllListeners();

        editButton.onClick.AddListener(() => onEdit?.Invoke());
        deleteButton.onClick.AddListener(() => onDelete?.Invoke());
    }
}
