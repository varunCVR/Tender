using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class StandardFormUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField standardNumberInput;

    [Header("Buttons")]
    public Button saveButton;
    public Button backButton;

    System.Action _onDone;
    int _editingStandardId = -1;

    void OnEnable()
    {
        if (saveButton) saveButton.onClick.RemoveAllListeners();
        if (backButton)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => _onDone?.Invoke());
        }
    }

    // -------------------- ADD --------------------
    public void SetupForAdd(System.Action onDone)
    {
        _onDone = onDone;
        _editingStandardId = -1;
        if (standardNumberInput) standardNumberInput.text = "";
        if (saveButton) saveButton.onClick.AddListener(SaveAdd);
    }

    void SaveAdd()
    {
        string stdNum = (standardNumberInput ? standardNumberInput.text : "").Trim();

        // Validate input
        if (string.IsNullOrEmpty(stdNum))
        {
            UIMessageManager.Instance.ShowWarning("Please enter a standard number.");
            return;
        }

        // Additional validation for standard number format
        if (stdNum.Length < 1 || stdNum.Length > 50)
        {
            UIMessageManager.Instance.ShowWarning("Standard number must be between 1 and 50 characters.");
            return;
        }

        // Check for invalid characters (optional - adjust based on your requirements)
        if (stdNum.Contains("'") || stdNum.Contains("\"") || stdNum.Contains(";"))
        {
            UIMessageManager.Instance.ShowWarning("Standard number contains invalid characters.");
            return;
        }

        // Check if standard number already exists (case-insensitive comparison)
        var existing = Queries.GetStandards().FirstOrDefault(s => 
            string.Equals(s.std_num, stdNum, System.StringComparison.OrdinalIgnoreCase));
        if (existing != null)
        {
            UIMessageManager.Instance.ShowError($"Standard number '{stdNum}' already exists. Please choose a different number.");
            return;
        }

        try
        {
            Queries.AddStandard(stdNum);
            UIMessageManager.Instance.ShowSuccess($"Standard '{stdNum}' added successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            UIMessageManager.Instance.ShowError("Could not add standard. Please try again.");
            Debug.LogWarning($"[Admin] AddStandard failed: {ex.Message}");
        }
    }

    // -------------------- EDIT --------------------
    public void SetupForEdit(Standard s, System.Action onDone)
    {
        _onDone = onDone;
        _editingStandardId = s.std_id;

        if (standardNumberInput) standardNumberInput.text = s.std_num;
        if (saveButton) saveButton.onClick.AddListener(SaveEdit);
    }

    void SaveEdit()
    {
        string stdNum = (standardNumberInput ? standardNumberInput.text : "").Trim();

        // Validate input
        if (string.IsNullOrEmpty(stdNum))
        {
            UIMessageManager.Instance.ShowWarning("Please enter a standard number.");
            return;
        }

        // Additional validation for standard number format
        if (stdNum.Length < 1 || stdNum.Length > 50)
        {
            UIMessageManager.Instance.ShowWarning("Standard number must be between 1 and 50 characters.");
            return;
        }

        // Check for invalid characters (optional - adjust based on your requirements)
        if (stdNum.Contains("'") || stdNum.Contains("\"") || stdNum.Contains(";"))
        {
            UIMessageManager.Instance.ShowWarning("Standard number contains invalid characters.");
            return;
        }

        // Check if another standard uses this number (case-insensitive comparison)
        var existing = Queries.GetStandards().FirstOrDefault(s => 
            string.Equals(s.std_num, stdNum, System.StringComparison.OrdinalIgnoreCase) && 
            s.std_id != _editingStandardId);
        if (existing != null)
        {
            UIMessageManager.Instance.ShowError($"Another standard already uses the number '{stdNum}'. Please choose a different number.");
            return;
        }

        try
        {
            Queries.UpdateStandard(_editingStandardId, stdNum);
            UIMessageManager.Instance.ShowSuccess($"Standard '{stdNum}' updated successfully!");
            _onDone?.Invoke();
        }
        catch (System.Exception ex)
        {
            UIMessageManager.Instance.ShowError("Could not update standard. Please try again.");
            Debug.LogWarning($"[Admin] UpdateStandard failed: {ex.Message}");
        }
    }
}
