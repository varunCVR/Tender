using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class LoginController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField usernameInput;   // Admin.username / Teacher.name / Student.roll_number
    public TMP_InputField passwordInput;
    public TMP_Dropdown roleDropdown;
    public Button loginButton;

    [Header("Panels to Toggle")]
    public GameObject loginPanel;
    public GameObject adminPanel;
    public GameObject teacherPanel;
    public GameObject studentPanel;

    [Header("Message Popups (Optional)")]
    public GameObject successMessage;
    public GameObject errorMessage;
    public TMP_Text errorText;

    void Start()
    {
        loginButton.onClick.AddListener(OnLoginClicked);
    }

    void OnLoginClicked()
    {
        string id = usernameInput.text.Trim();
        string pw = passwordInput.text;
        int roleIndex = roleDropdown.value;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowError("Please fill in both fields.");
            return;
        }

        switch (roleIndex)
        {
            case 1: LoginAdmin(id, pw); break;   // username
            case 2: LoginTeacher(id, pw); break; // name
            case 3: LoginStudent(id, pw); break; // roll_number
            default: ShowError("Select a valid role."); break;
        }
    }

    // ---------------- ADMIN LOGIN ----------------
    void LoginAdmin(string username, string password)
    {
        var a = Queries.FindAdmin(username);
        if (a == null) { ShowError("Admin not found."); return; }

        if (Verify(password, a.password_hash))
            OnLoginSuccess(Role.Admin, a.admin_id);
        else
            ShowError("Invalid admin password.");
    }

    // ---------------- TEACHER LOGIN ----------------
    void LoginTeacher(string teacherName, string password)
    {
        var t = Queries.FindTeacherByName(teacherName);
        if (t == null) { ShowError("Teacher not found."); return; }

        if (Verify(password, t.password_hash))
            OnLoginSuccess(Role.Teacher, t.teacher_id);
        else
            ShowError("Invalid teacher password.");
    }

    // ---------------- STUDENT LOGIN ----------------
    void LoginStudent(string rollNumber, string password)
    {
        var s = Queries.FindStudentByRoll(rollNumber);
        if (s == null) { ShowError("Student not found."); return; }

        if (Verify(password, s.password_hash))
            OnLoginSuccess(Role.Student, s.student_id);
        else
            ShowError("Invalid student password.");
    }

    // ---------------- PASSWORD CHECK ----------------
    bool Verify(string plain, string storedHash)
    {
        // For now, allow plain text OR SHA256 hash match
        return storedHash == plain || storedHash == Sha256(plain);
    }

    string Sha256(string s)
    {
        using (var sha = System.Security.Cryptography.SHA256.Create())
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(s);
            var hash = sha.ComputeHash(bytes);
            return System.BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }

    // ---------------- LOGIN SUCCESS ----------------
    void OnLoginSuccess(Role role, int userId)
    {
        Session.CurrentRole = role;
        Session.UserId = userId;

        loginPanel.SetActive(false);
        adminPanel.SetActive(role == Role.Admin);
        teacherPanel.SetActive(role == Role.Teacher);
        studentPanel.SetActive(role == Role.Student);

        // Set AppSession based on role
        switch (role)
        {
            case Role.Admin:
                var admin = Queries.FindAdminById(userId);
                if (admin != null)
                    AppSession.I.LoginAsAdmin(admin.admin_id, admin.username);
                break;

            case Role.Teacher:
                var teacher = Queries.GetTeacherById(userId);
                if (teacher != null)
                    AppSession.I.LoginAsTeacher(teacher.teacher_id, teacher.name);
                break;

            case Role.Student:
                var student = Queries.GetStudentById(userId);
                if (student != null)
                    AppSession.I.LoginAsStudent(student.student_id, student.name, student.std_id);
                break;
        }

        if (successMessage) successMessage.SetActive(true);
        if (errorMessage) errorMessage.SetActive(false);

        Debug.Log($" Login Successful → {role} (ID: {userId})");
    }


    void ShowError(string msg)
    {
        if (errorText) errorText.text = msg;
        if (errorMessage) errorMessage.SetActive(true);
        if (successMessage) successMessage.SetActive(false);
        Debug.LogWarning(msg);
    }
}

public enum Role { Admin, Teacher, Student }

public static class Session
{
    public static Role CurrentRole;
    public static int UserId;
}
