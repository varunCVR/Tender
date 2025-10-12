using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubjectRowUI : MonoBehaviour
{
    public TMP_Text indexText;    // "1."
    public TMP_Text nameText;     // "Biology"
    public TMP_Text teacherText;  // "Smith"
    public TMP_Text stdText;      // "05"
    public Button editButton;     // green pen
    public Button deleteButton;   // red cross

    public void Bind(
        int index, string name, string teacher, string std,
        System.Action onEdit, System.Action onDelete)
    {
        if (indexText)  indexText.text  = index + ".";
        if (nameText)   nameText.text   = name;
        if (teacherText)teacherText.text= teacher ?? "-";
        if (stdText)    stdText.text    = std ?? "-";

        editButton.onClick.RemoveAllListeners();
        deleteButton.onClick.RemoveAllListeners();
        editButton.onClick.AddListener(() => onEdit?.Invoke());
        deleteButton.onClick.AddListener(() => onDelete?.Invoke());
    }
}
