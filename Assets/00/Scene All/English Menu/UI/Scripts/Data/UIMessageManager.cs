using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Collections;

public class UIMessageManager : MonoBehaviour
{
    public static UIMessageManager Instance;

    [Header("Toast Cards")]
    public GameObject successCard;
    public GameObject errorCard;
    public GameObject warningCard;

    public TMP_Text successText;
    public TMP_Text errorText;
    public TMP_Text warningText;

    [Header("Confirm Dialog (Yes/No)")]
    public GameObject confirmCard;          // a dedicated confirm panel
    public TMP_Text confirmText;
    public Button confirmYesButton;
    public Button confirmNoButton;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    // --------- TOASTS ---------
    public void ShowSuccess(string msg, float autoHide = 2f)  => ShowToast(successCard, successText, msg, autoHide);
    public void ShowError(string msg, float autoHide = 3f)    => ShowToast(errorCard,   errorText,   msg, autoHide);
    public void ShowWarning(string msg, float autoHide = 3f)  => ShowToast(warningCard, warningText, msg, autoHide);

    void ShowToast(GameObject card, TMP_Text label, string msg, float autoHide)
    {
        if (!card) return;
        card.SetActive(true);
        if (label) label.text = msg;
        if (autoHide > 0) StartCoroutine(HideAfter(card, autoHide));
    }

    IEnumerator HideAfter(GameObject go, float t)
    {
        yield return new WaitForSeconds(t);
        if (go) go.SetActive(false);
    }

    // --------- CONFIRM (YES/NO) ---------
    public void ShowConfirm(string message, Action onYes, Action onNo = null)
    {
        if (!confirmCard) { Debug.LogWarning("Confirm dialog not assigned."); onYes?.Invoke(); return; }

        confirmCard.SetActive(true);
        if (confirmText) confirmText.text = message;

        // reset listeners
        confirmYesButton.onClick.RemoveAllListeners();
        confirmNoButton.onClick.RemoveAllListeners();

        confirmYesButton.onClick.AddListener(() => {
            confirmCard.SetActive(false);
            onYes?.Invoke();
        });

        confirmNoButton.onClick.AddListener(() => {
            confirmCard.SetActive(false);
            onNo?.Invoke();
        });
    }
}
