// File: AppSession.cs
using System;
using UnityEngine;

public enum UserRole { None, Admin, Teacher, Student }

public class AppSession : MonoBehaviour
{
    public static AppSession I { get; private set; }

    // Who is logged in?
    public UserRole Role { get; private set; } = UserRole.None;
    public int AdminId { get; private set; }
    public int TeacherId { get; private set; }
    public int StudentId { get; private set; }

    // Common context used across panels
    public int CurrentStdId { get; private set; }
    public int? CurrentSubjectId { get; private set; }

    public string DisplayName { get; private set; }
    public event Action OnSessionChanged; // notify listeners

    void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    // ---- Login helpers ----
    public void LoginAsAdmin(int adminId, string nameOrUser)
    {
        Clear();
        Role = UserRole.Admin;
        AdminId = adminId;
        DisplayName = nameOrUser;
        Changed();
    }

    public void LoginAsTeacher(int teacherId, string name)
    {
        Clear();
        Role = UserRole.Teacher;
        TeacherId = teacherId;
        DisplayName = name;
        Changed();
    }

    public void LoginAsStudent(int studentId, string name, int stdId)
    {
        Clear();
        Role = UserRole.Student;
        StudentId = studentId;
        DisplayName = name;
        CurrentStdId = stdId; // student’s class from DB
        Changed();
    }

    // ---- Context setters ----
    public void SetStandard(int stdId) { CurrentStdId = stdId; Changed(); }
    public void SetSubject(int? subjectId) { CurrentSubjectId = subjectId; Changed(); }

    public void Logout() { Clear(); Changed(); }

    void Clear()
    {
        Role = UserRole.None;
        AdminId = TeacherId = StudentId = 0;
        CurrentStdId = 0;
        CurrentSubjectId = null;
        DisplayName = null;
    }

    void Changed() => OnSessionChanged?.Invoke();

    // Convenience checks
    public bool IsAdmin => Role == UserRole.Admin;
    public bool IsTeacher => Role == UserRole.Teacher;
    public bool IsStudent => Role == UserRole.Student;
}
