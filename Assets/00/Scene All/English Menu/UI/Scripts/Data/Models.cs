using SQLite;

#region Core Users
public class Admin {
    [PrimaryKey, AutoIncrement] public int admin_id { get; set; }
    [Unique, NotNull] public string username { get; set; }
    [Unique] public string email { get; set; }
    [NotNull] public string password_hash { get; set; }
}

public class Teacher {
    [PrimaryKey, AutoIncrement] public int teacher_id { get; set; }
    [NotNull] public string name { get; set; }
    [Unique, NotNull] public string email { get; set; }
    [NotNull] public string password_hash { get; set; }
}

public class Student {
    [PrimaryKey, AutoIncrement] public int student_id { get; set; }
    [NotNull] public string name { get; set; }
    [Unique, NotNull] public string email { get; set; }
    [NotNull] public string password_hash { get; set; }
    [Unique] public string roll_number { get; set; }
    [Indexed, NotNull] public int std_id { get; set; }
}
#endregion

#region Catalog
public class Standard {
    [PrimaryKey, AutoIncrement] public int std_id { get; set; }
    [NotNull] public string std_num { get; set; } // e.g., "9","10","11","12"
}

public class Subject {
    [PrimaryKey, AutoIncrement] public int subject_id { get; set; }
    [NotNull] public string subject_name { get; set; }
}

// Bridge between Subject and Standard (many-to-many)
[Table("TeacherSubject")]
public class TeacherSubject {
    [PrimaryKey, AutoIncrement] public int id { get; set; }
    [Indexed] public int teacher_id { get; set; }
    [Indexed] public int subject_id { get; set; }
}

[Table("SubjectStandard")]
public class SubjectStandard {
    [PrimaryKey, AutoIncrement] public int id { get; set; }
    [Indexed] public int subject_id { get; set; }
    [Indexed] public int std_id { get; set; }
}

#endregion

#region Practicals & Logs
public class Practical {
    [PrimaryKey, AutoIncrement] public int practical_id { get; set; }
    [Indexed] public int subject_id { get; set; }
    [Indexed] public int std_id { get; set; }
    [NotNull] public string title { get; set; }
    // use 0/1 so it's SQLite-friendly
    [NotNull] public int is_allowed { get; set; } = 1; 
}

public class PracticalLog {
    [PrimaryKey, AutoIncrement] public int log_id { get; set; }
    [Indexed] public int student_id { get; set; }
    [Indexed] public int practical_id { get; set; }
    // store ISO timestamps as string to keep it simple across platforms
    public string date_time { get; set; } 
    // "PENDING" or "COMPLETED"
    public string completion_status { get; set; } 
}
#endregion
