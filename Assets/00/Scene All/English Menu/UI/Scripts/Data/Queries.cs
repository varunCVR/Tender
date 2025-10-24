using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class Queries
{
    static SQLite.SQLiteConnection db => Database.Conn;

    // ---------- Auth ----------
    public static Student FindStudent(string email) =>
        db.Table<Student>().FirstOrDefault(s => s.email == email);

    public static Teacher FindTeacher(string email) =>
        db.Table<Teacher>().FirstOrDefault(t => t.email == email);
    public static Admin FindAdmin(string username) =>
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
        db.Insert(new PracticalLog
        {
            student_id = studentId,
            practical_id = practicalId,
            date_time = now,
            completion_status = completed ? "COMPLETED" : "PENDING"
        });
    }

    // ========== TEACHER QUERIES ==========

    // Get all teachers


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
    // ---- Teacher existence checks ----
    public static bool TeacherEmailExists(string email)
    {
        email = email.Trim();
        return db.Table<Teacher>().Any(t => t.email == email);
    }

    public static bool TeacherEmailExistsForAnother(int teacherId, string email)
    {
        email = email.Trim();
        return db.Table<Teacher>().Any(t => t.email == email && t.teacher_id != teacherId);
    }

    public static bool TeacherNameExists(string name)
    {
        name = name.Trim();
        return db.Table<Teacher>().Any(t => t.name == name);
    }

    public static bool TeacherNameExistsForAnother(int teacherId, string name)
    {
        name = name.Trim();
        return db.Table<Teacher>().Any(t => t.name == name && t.teacher_id != teacherId);
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
    //public struct LogView
    //{
    //    public int log_id;
    //    public string student_name;
    //    public string practical_title;
    //    public string date_time;
    //    public string completion_status;
    //}

    //public static List<LogView> GetLogsJoined()
    //{
    //    var logs = db.Table<PracticalLog>().ToList();
    //    var students = db.Table<Student>().ToDictionary(s => s.student_id, s => s.name);
    //    var practicals = db.Table<Practical>().ToDictionary(p => p.practical_id, p => p.title);

    //    var joined = new List<LogView>(logs.Count);
    //    foreach (var l in logs)
    //    {
    //        joined.Add(new LogView
    //        {
    //            log_id = l.log_id,
    //            student_name = students.TryGetValue(l.student_id, out var sn) ? sn : "?",
    //            practical_title = practicals.TryGetValue(l.practical_id, out var pt) ? pt : "?",
    //            date_time = l.date_time,
    //            completion_status = l.completion_status
    //        });
    //    }
    //    return joined;
    //}
    // -------- Subjects --------
    public static List<Subject> GetSubjects() =>
        db.Table<Subject>().OrderBy(s => s.subject_name).ToList();

    public static int AddSubject(string name)
        => db.Insert(new Subject { subject_name = name.Trim() });

    // Get Admin by id
    public static Admin FindAdminById(int adminId)
    {
        return db.Table<Admin>().FirstOrDefault(a => a.admin_id == adminId);
    }

    // Get Teacher by id
    public static Teacher GetTeacherById(int teacherId)
    {
        return db.Table<Teacher>().FirstOrDefault(t => t.teacher_id == teacherId);
    }

    // Return all practicals sorted by standard → subject → title
    public static List<Practical> GetAllPracticalsOrdered()
    {
        return db.Table<Practical>()
            .OrderBy(p => p.std_id)
            .ThenBy(p => p.subject_id)
            .ThenBy(p => p.title)
            .ToList();
    }

    // Return practicals only for a given standard, sorted by subject → title
    public static List<Practical> GetPracticalsForStandard(int stdId)
    {
        return db.Table<Practical>()
            .Where(p => p.std_id == stdId)
            .OrderBy(p => p.subject_id)
            .ThenBy(p => p.title)
            .ToList();
    }


    public static bool SubjectNameExists(string name)
        => db.Table<Subject>().Any(s => s.subject_name.ToLower() == name.Trim().ToLower());

    public static bool SubjectNameExistsForAnother(int subjectId, string name)
        => db.Table<Subject>().Any(s => s.subject_name.ToLower() == name.Trim().ToLower()
                                        && s.subject_id != subjectId);

    public static void UpdateSubject(int id, string name)
    {
        var s = db.Table<Subject>().FirstOrDefault(x => x.subject_id == id);
        if (s == null) return;
        s.subject_name = name.Trim();
        db.Update(s);
    }

    // public static void DeleteSubjectCascade(int id) // remove bridges + practicals
    // {
    //     foreach (var ts in db.Table<TeacherSubject>().Where(x => x.subject_id == id).ToList()) db.Delete(ts);
    //     foreach (var ss in db.Table<SubjectStandard>().Where(x => x.subject_id == id).ToList()) db.Delete(ss);
    //     foreach (var p in db.Table<Practical>().Where(x => x.subject_id == id).ToList()) db.Delete(p);
    //     var s = db.Table<Subject>().FirstOrDefault(x => x.subject_id == id);
    //     if (s != null) db.Delete(s);
    // }

    // -------- Standards --------
    public static List<Standard> GetStandards() =>
        db.Table<Standard>().OrderBy(s => s.std_num).ToList();

    public static int AddStandard(string stdNum) =>
        db.Insert(new Standard { std_num = stdNum });

    public static void UpdateStandard(int id, string stdNum)
    {
        var s = db.Table<Standard>().FirstOrDefault(x => x.std_id == id);
        if (s == null) return;
        s.std_num = stdNum; db.Update(s);
    }

    public static void DeleteStandard(int id)
    {
        foreach (var b in db.Table<SubjectStandard>().Where(ss => ss.std_id == id).ToList()) db.Delete(b);
        foreach (var p in db.Table<Practical>().Where(p => p.std_id == id).ToList()) db.Delete(p);
        var s = db.Table<Standard>().FirstOrDefault(x => x.std_id == id);
        if (s != null) db.Delete(s);
    }
    // ---------- TEACHER DROPDOWN ----------
    public static List<Teacher> GetTeachers()
        => db.Table<Teacher>().OrderBy(t => t.name).ToList();

    // ---------- TEACHER↔SUBJECT bridge ----------
    public static void LinkTeacherSubject(int teacherId, int subjectId)
    {
        bool exists = db.Table<TeacherSubject>()
            .Any(x => x.teacher_id == teacherId && x.subject_id == subjectId);
        if (!exists) db.Insert(new TeacherSubject { teacher_id = teacherId, subject_id = subjectId });
    }

    public static void UnlinkAllTeachersFromSubject(int subjectId)
    {
        foreach (var r in db.Table<TeacherSubject>().Where(x => x.subject_id == subjectId).ToList())
            db.Delete(r);
    }
    public static void UnlinkAllStandardsFromSubject(int subjectId)
    {
        foreach (var r in db.Table<SubjectStandard>().Where(x => x.subject_id == subjectId).ToList())
            db.Delete(r);
    }

    public static int? GetFirstTeacherIdForSubject(int subjectId)
    {
        var link = db.Table<TeacherSubject>().FirstOrDefault(x => x.subject_id == subjectId);
        return link?.teacher_id;
    }
    public static int? GetFirstStdIdForSubject(int subjectId)
    {
        var link = db.Table<SubjectStandard>().FirstOrDefault(x => x.subject_id == subjectId);
        return link?.std_id;
    }
    public static void LinkSubjectStandard(int subjectId, int stdId)
    {
        bool exists = db.Table<SubjectStandard>().Any(x => x.subject_id == subjectId && x.std_id == stdId);
        if (!exists) db.Insert(new SubjectStandard { subject_id = subjectId, std_id = stdId });
    }
    // -------- Subject–Standard bridge --------
    public static void AddSubjectStandard(int subjectId, int stdId)
    {
        var exists = db.Table<SubjectStandard>().Any(x => x.subject_id == subjectId && x.std_id == stdId);
        if (!exists) db.Insert(new SubjectStandard { subject_id = subjectId, std_id = stdId });
    }

    public static void DeleteSubjectStandard(int subjectId, int stdId)
    {
        var row = db.Table<SubjectStandard>().FirstOrDefault(x => x.subject_id == subjectId && x.std_id == stdId);
        if (row != null) db.Delete(row);
    }
    public static void DeleteSubjectCascade(int id)
    {
        // Raw deletes avoid needing PKs on bridge tables
        db.Execute("DELETE FROM TeacherSubject WHERE subject_id = ?", id);
        db.Execute("DELETE FROM SubjectStandard WHERE subject_id = ?", id);
        db.Execute("DELETE FROM Practical WHERE subject_id = ?", id);
        db.Execute("DELETE FROM Subject WHERE subject_id = ?", id);
    }
    // ---------- STUDENT QUERIES ----------
    public static Student GetStudentById(int studentId) =>
        db.Table<Student>().FirstOrDefault(s => s.student_id == studentId);

    public static List<Student> GetStudents() =>
        db.Table<Student>().OrderBy(s => s.name).ToList();

    public static List<Student> GetStudentsForStandard(int stdId) =>
        db.Table<Student>().Where(s => s.std_id == stdId).OrderBy(s => s.name).ToList();

    public static int AddStudent(string name, string email, string rollNumber, int stdId = 0, string passwordHash = "")
    {
        var student = new Student
        {
            name = name?.Trim(),
            email = email?.Trim(),
            roll_number = rollNumber?.Trim(),
            std_id = stdId,
            // ensure NOT NULL column always has a value
            password_hash = passwordHash ?? ""
        };
        return db.Insert(student);
    }

    public static void UpdateStudent(int studentId, string name, string email, string rollNumber, int stdId = 0, string passwordHash = null)
    {
        var student = db.Table<Student>().FirstOrDefault(s => s.student_id == studentId);
        if (student == null) return;

        student.name = name?.Trim();
        student.email = email?.Trim();
        student.roll_number = rollNumber?.Trim();
        student.std_id = stdId;

        // only update password_hash when caller explicitly provides a non-null value
        if (passwordHash != null)
        {
            student.password_hash = passwordHash;
        }

        db.Update(student);
    }

    public static void DeleteStudent(int studentId)
    {
        var student = db.Table<Student>().FirstOrDefault(s => s.student_id == studentId);
        if (student != null) db.Delete(student);
    }

    // ---- Student existence checks ----
    public static bool StudentEmailExists(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        email = email.Trim();
        return db.Table<Student>().Any(s => s.email == email);
    }

    public static bool StudentEmailExistsForAnother(int studentId, string email)
    {
        if (string.IsNullOrEmpty(email)) return false;
        email = email.Trim();
        return db.Table<Student>().Any(s => s.email == email && s.student_id != studentId);
    }

    public static bool StudentRollExists(string rollNumber)
    {
        if (string.IsNullOrEmpty(rollNumber)) return false;
        rollNumber = rollNumber.Trim();
        return db.Table<Student>().Any(s => s.roll_number == rollNumber);
    }

    public static bool StudentRollExistsForAnother(int studentId, string rollNumber)
    {
        if (string.IsNullOrEmpty(rollNumber)) return false;
        rollNumber = rollNumber.Trim();
        return db.Table<Student>().Any(s => s.roll_number == rollNumber && s.student_id != studentId);
    }

    // Convenience: use standards as "classes" for UI dropdowns
    public static List<Standard> GetClasses() => GetStandards();

    public static Standard GetStandardById(int stdId) =>
        db.Table<Standard>().FirstOrDefault(s => s.std_id == stdId);

    // Return the subjects a teacher is assigned to (via TeacherSubject)
    public static List<Subject> GetSubjectsForTeacher(int teacherId)
    {
        var links = db.Table<TeacherSubject>().Where(ts => ts.teacher_id == teacherId).ToList();
        var subjectIds = links.Select(x => x.subject_id).ToArray();
        return db.Table<Subject>().Where(s => subjectIds.Contains(s.subject_id))
                 .OrderBy(s => s.subject_name).ToList();
    }

    // Get ALL practicals for a standard+subject (regardless of is_allowed)
    public static List<Practical> GetPracticalsFor(int stdId, int subjectId)
    {
        return db.Table<Practical>()
                 .Where(p => p.std_id == stdId && p.subject_id == subjectId)
                 .OrderBy(p => p.title)
                 .ToList();
    }
    public static Practical GetPracticalById(int id) =>
    db.Table<Practical>().FirstOrDefault(p => p.practical_id == id);
   

    // All standards that intersect with that teacher's subjects
    public static List<Standard> GetStandardsForTeacher(int teacherId)
    {
        var links = db.Table<TeacherSubject>().Where(ts => ts.teacher_id == teacherId).ToList();
        var sids = links.Select(l => l.subject_id).Distinct().ToArray();
        var stdIds = db.Table<SubjectStandard>().Where(ss => sids.Contains(ss.subject_id))
                       .Select(ss => ss.std_id).Distinct().ToArray();
        return db.Table<Standard>().Where(st => stdIds.Contains(st.std_id))
                 .OrderBy(st => st.std_num).ToList();
    }

    // Practical logs joined + filtered
    // ---- Logs View (unified type used everywhere) ----
    public struct LogView
    {
        public int log_id;
        public string student_name;
        public string std_label;        // e.g., "9"
        public string roll_no;
        public string practical_title;
        public string date_time;        // "yyyy-MM-dd HH:mm:ss"
        public string completion_status;
    }

    // Unfiltered joined view (new version using the unified LogView)
    public static List<LogView> GetLogsJoined()
    {
        var logs = db.Table<PracticalLog>().ToList();
        var students = db.Table<Student>().ToList();
        var practicals = db.Table<Practical>().ToList();
        var standards = db.Table<Standard>().ToList();

        var studById = students.ToDictionary(s => s.student_id);
        var pracById = practicals.ToDictionary(p => p.practical_id);
        var stdById = standards.ToDictionary(s => s.std_id);

        var joined = new List<LogView>(logs.Count);
        foreach (var l in logs)
        {
            if (!studById.TryGetValue(l.student_id, out var s)) continue;
            if (!pracById.TryGetValue(l.practical_id, out var p)) continue;

            joined.Add(new LogView
            {
                log_id = l.log_id,
                student_name = s.name,
                std_label = stdById.TryGetValue(s.std_id, out var st) ? st.std_num : "?",
                roll_no = s.roll_number,
                practical_title = p.title,
                date_time = l.date_time,
                completion_status = l.completion_status
            });
        }

        // newest first
        joined.Sort((a, b) => string.Compare(b.date_time, a.date_time, StringComparison.Ordinal));
        return joined;
    }

    // Filter by (stdId, subjectId). Pass 0 to ignore a filter.
    public static List<LogView> GetLogsJoinedFiltered(int stdId, int subjectId)
    {
        // pull tables once
        var logs = db.Table<PracticalLog>().ToList();
        var students = db.Table<Student>().ToList();
        var practicals = db.Table<Practical>().ToList();
        var standards = db.Table<Standard>().ToList();

        // index for fast lookup
        var studById = students.ToDictionary(s => s.student_id);
        var pracById = practicals.ToDictionary(p => p.practical_id);
        var stdById = standards.ToDictionary(s => s.std_id);

        var result = new List<LogView>(logs.Count);

        foreach (var l in logs)
        {
            if (!studById.TryGetValue(l.student_id, out var s)) continue;
            if (!pracById.TryGetValue(l.practical_id, out var p)) continue;

            // apply optional filters
            if (stdId != 0 && s.std_id != stdId) continue;
            if (subjectId != 0 && p.subject_id != subjectId) continue;

            result.Add(new LogView
            {
                log_id = l.log_id,
                student_name = s.name,
                std_label = stdById.TryGetValue(s.std_id, out var st) ? st.std_num : "?",
                roll_no = s.roll_number,
                practical_title = p.title,
                date_time = l.date_time,
                completion_status = l.completion_status
            });
        }

        // newest first
        result.Sort((a, b) => string.Compare(b.date_time, a.date_time, StringComparison.Ordinal));
        return result;
    }

    public static string HashPassword(string plain)
    {
        if (string.IsNullOrEmpty(plain)) return "";
        using (var sha = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(plain);
            var hash = sha.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }

}
