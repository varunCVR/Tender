using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using System.Text;

public class TeacherFormUI : MonoBehaviour
{
    [Header("Inputs")]
    public TMP_InputField nameInput;     // label can say "Username" in your UI, value maps to Teacher.name
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    [Header("Buttons")]
    public Button saveButton;
    public Button backButton;            // the circular back in your screenshots

    System.Action _onDone;
    int _editingTeacherId = -1;          // <0 = Add mode, >=0 = Edit mode

    void OnEnable()
    {
        saveButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();

        backButton.onClick.AddListener(() => _onDone?.Invoke());
    }

    // ---------- Public APIs ----------
    public void SetupForAdd(System.Action onDone)
    {
        _onDone = onDone;
        _editingTeacherId = -1;
        nameInput.text = ""; emailInput.text = ""; passwordInput.text = "";
        saveButton.onClick.AddListener(SaveAdd);
    }

    public void SetupForEdit(Teacher t, System.Action onDone)
    {
        _onDone = onDone;
        _editingTeacherId = t.teacher_id;
        nameInput.text = t.name;
        emailInput.text = t.email;
        passwordInput.text = "";   // leave empty unless admin wants to change it
        saveButton.onClick.AddListener(SaveEdit);
    }

    // ---------- Save handlers ----------
    void SaveAdd()
    {
        if (!Validate(out string n, out string e, out string p)) return;
        // store either raw or hashed; keep consistent with your LoginController.Verify
        // var hash = Sha256(p);
        var hash = p;
        Queries.AddTeacher(n, e, hash);
        _onDone?.Invoke();
    }

    void SaveEdit()
    {
        if (!Validate(out string n, out string e, out string p, allowEmptyPassword:true)) return;
        string hash = string.IsNullOrEmpty(p) ? null : p; // or Sha256(p)
        Queries.UpdateTeacher(_editingTeacherId, n, e, hash);
        _onDone?.Invoke();
    }

    // ---------- Helpers ----------
    bool Validate(out string n, out string e, out string p, bool allowEmptyPassword = false)
    {
        n = nameInput.text.Trim();
        e = emailInput.text.Trim();
        p = passwordInput.text;

        if (string.IsNullOrEmpty(n)) { Debug.LogWarning("Enter teacher name."); return false; }
        if (string.IsNullOrEmpty(e)) { Debug.LogWarning("Enter email.");       return false; }
        if (!allowEmptyPassword && string.IsNullOrEmpty(p)) { Debug.LogWarning("Enter password."); return false; }
        return true;
    }

    string Sha256(string s)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
        return System.BitConverter.ToString(bytes).Replace("-", "").ToLowerInvariant();
    }
}
