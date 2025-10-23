using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class StudentRowUI : MonoBehaviour
{
    public TextMeshProUGUI idxText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI rollText;
    public TextMeshProUGUI classText;
    public Button editButton;
    public Button deleteButton;

    public void Bind(int index, Student student, Action onEdit, Action onDelete)
    {
        if (idxText != null) idxText.text = index.ToString();
        if (nameText != null) nameText.text = student != null ? student.name : "<no name>";
        if (rollText != null) rollText.text = student != null ? student.roll_number : "";

        if (classText != null)
        {
            if (student != null && student.std_id != 0)
            {
                var std = Queries.GetStandardById(student.std_id);
                classText.text = std != null ? std.std_num : "-";
            }
            else classText.text = "-";
        }

        if (editButton != null)
        {
            editButton.onClick.RemoveAllListeners();
            editButton.onClick.AddListener(() => onEdit?.Invoke());
        }

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() => onDelete?.Invoke());
        }
    }
}
