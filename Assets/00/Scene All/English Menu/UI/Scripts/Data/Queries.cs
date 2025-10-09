using System;
using System.Collections.Generic;
using System.Linq;

public static class Queries
{
    static SQLite.SQLiteConnection db => Database.Conn;

    // ---------- Auth ----------
    public static Student FindStudent(string email) =>
        db.Table<Student>().FirstOrDefault(s => s.email == email);

    public static Teacher FindTeacher(string email) =>
        db.Table<Teacher>().FirstOrDefault(t => t.email == email);

    public static Admin   FindAdmin(string username) =>
        db.Table<Admin>().FirstOrDefault(a => a.username == username);

    // Teacher Login (by name)
    public static Teacher FindTeacherByName(string name)
    {
        return db.Table<Teacher>().FirstOrDefault(t => t.name == name);
    }

    // Student Login (by roll number)
    public static Student FindStudentByRoll(string rollNumber)
    {
        return db.Table<Student>().FirstOrDefault(s => s.roll_number == rollNumber);
    }

    // ---------- Catalog ----------
    public static List<Subject> GetSubjectsForStandard(int stdId)
    {
        var pairs = db.Table<SubjectStandard>().Where(ss => ss.std_id == stdId).ToList();
        var ids = pairs.Select(p => p.subject_id).ToArray();
        return db.Table<Subject>().Where(s => ids.Contains(s.subject_id)).OrderBy(s => s.subject_name).ToList();
    }

    public static List<Practical> GetAllowedPracticals(int stdId, int? subjectId = null)
    {
        var q = db.Table<Practical>().Where(p => p.std_id == stdId && p.is_allowed == 1);
        if (subjectId.HasValue) q = q.Where(p => p.subject_id == subjectId.Value);
        return q.OrderBy(p => p.title).ToList();
    }

    public static void SetPracticalAllowed(int practicalId, bool allowed)
    {
        var p = db.Table<Practical>().FirstOrDefault(x => x.practical_id == practicalId);
        if (p == null) return;
        p.is_allowed = allowed ? 1 : 0;
        db.Update(p);
    }

    // ---------- Logs ----------
    public static void AddLog(int studentId, int practicalId, bool completed)
    {
        var now = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        db.Insert(new PracticalLog {
            student_id = studentId,
            practical_id = practicalId,
            date_time = now,
            completion_status = completed ? "COMPLETED" : "PENDING"
        });
    }
    
// ========== TEACHER QUERIES ==========

// Get all teachers
public static List<Teacher> GetTeachers()
{
    return db.Table<Teacher>().OrderBy(t => t.name).ToList();
}

// Add a new teacher
public static int AddTeacher(string name, string email, string passwordHash)
{
    var teacher = new Teacher
    {
        name = name,
        email = email,
        password_hash = passwordHash
    };
    return db.Insert(teacher);
}


// Update existing teacher
public static void UpdateTeacher(int teacherId, string name, string email, string passwordHash = null)
{
    var teacher = db.Table<Teacher>().FirstOrDefault(t => t.teacher_id == teacherId);
    if (teacher == null) return;

    teacher.name = name;
    teacher.email = email;
    if (!string.IsNullOrEmpty(passwordHash))
        teacher.password_hash = passwordHash;

    db.Update(teacher);
}

// Delete teacher
public static void DeleteTeacher(int teacherId)
{
    var teacher = db.Table<Teacher>().FirstOrDefault(t => t.teacher_id == teacherId);
    if (teacher != null)
        db.Delete(teacher);
}

    public static List<PracticalLog> GetLogsForStudent(int studentId) =>
        db.Table<PracticalLog>().Where(l => l.student_id == studentId)
          .OrderByDescending(l => l.log_id).ToList();

    // Useful: get joined info for teacher reports
    public struct LogView {
        public int log_id;
        public string student_name;
        public string practical_title;
        public string date_time;
        public string completion_status;
    }

    public static List<LogView> GetLogsJoined()
    {
        var logs = db.Table<PracticalLog>().ToList();
        var students = db.Table<Student>().ToDictionary(s => s.student_id, s => s.name);
        var practicals = db.Table<Practical>().ToDictionary(p => p.practical_id, p => p.title);

        var joined = new List<LogView>(logs.Count);
        foreach (var l in logs) {
            joined.Add(new LogView {
                log_id = l.log_id,
                student_name = students.TryGetValue(l.student_id, out var sn) ? sn : "?",
                practical_title = practicals.TryGetValue(l.practical_id, out var pt) ? pt : "?",
                date_time = l.date_time,
                completion_status = l.completion_status
            });
        }
        return joined;
    }
}
