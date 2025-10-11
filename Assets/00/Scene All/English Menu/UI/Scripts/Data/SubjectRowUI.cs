using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubjectRowUI : MonoBehaviour
{
    public TMP_Text indexText;
    public TMP_Text nameText;    // e.g., "Physics (Dr. Smith)"
    public Button editButton;    // green pen
    public Button deleteButton;  // red cross

    public void Bind(int index, string label, System.Action onEdit, System.Action onDelete)
    {
        if (indexText) indexText.text = index + ".";
        if (nameText)  nameText.text  = label;

        editButton.onClick.RemoveAllListeners();
        deleteButton.onClick.RemoveAllListeners();
        editButton.onClick.AddListener(() => onEdit?.Invoke());
        deleteButton.onClick.AddListener(() => onDelete?.Invoke());
    }
}
