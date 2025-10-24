using System.IO;
using System.Linq;
using System;
using SQLite;
using UnityEngine;

public static class Database
{
    static SQLiteConnection _conn;
    public static SQLiteConnection Conn => _conn;

    public static string DbPath => Path.Combine(Application.persistentDataPath, "eduversexr.db3");

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        try
        {
            SQLitePCL.Batteries_V2.Init();
            _conn = new SQLiteConnection(DbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            _conn.Execute("PRAGMA foreign_keys = ON;");

            // Tables
            _conn.CreateTable<Admin>();
            _conn.CreateTable<Teacher>();
            _conn.CreateTable<Student>();
            _conn.CreateTable<Standard>();
            _conn.CreateTable<Subject>();
            _conn.CreateTable<SubjectStandard>();
            _conn.CreateTable<TeacherSubject>();
            _conn.CreateTable<Practical>();
            _conn.CreateTable<PracticalLog>();

            // NEW: lightweight migrations (columns / indexes)
            RunMigrations();
            CreateIndexes();

            SeedIfEmpty();

            // NEW: ensure scene keys for your 8 Eng practical scenes (non-destructive)
            SeedSceneKeysIfMissing();

            Debug.Log($"[DB] EduVerse XR ready at: {DbPath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[DB] Init error: {ex}");
        }
    }

    // NEW: add columns etc. (safe to call every startup)
    static void RunMigrations()
    {
        try
        {
            // Add scene_key to Practical if it doesn't exist
            _conn.Execute("ALTER TABLE Practical ADD COLUMN scene_key TEXT");
        }
        catch
        {
            // ignore if column already exists
        }
    }

    // NEW: helpful indexes (idempotent)
    static void CreateIndexes()
    {
        // practical lookups & filtering
        _conn.Execute("CREATE INDEX IF NOT EXISTS ix_practical_std_sub ON Practical(std_id, subject_id, is_allowed)");
        _conn.Execute("CREATE UNIQUE INDEX IF NOT EXISTS ux_practical_scene_key ON Practical(scene_key)");

        // student filtering
        _conn.Execute("CREATE INDEX IF NOT EXISTS ix_student_std ON Student(std_id)");

        // bridge uniqueness (avoid duplicates)
        _conn.Execute("CREATE UNIQUE INDEX IF NOT EXISTS ux_subjectstandard ON SubjectStandard(subject_id, std_id)");
        _conn.Execute("CREATE UNIQUE INDEX IF NOT EXISTS ux_teachersubject ON TeacherSubject(teacher_id, subject_id)");

        // logs (teacher reports)
        _conn.Execute("CREATE INDEX IF NOT EXISTS ix_log_student ON PracticalLog(student_id)");
        _conn.Execute("CREATE INDEX IF NOT EXISTS ix_log_practical ON PracticalLog(practical_id)");
        _conn.Execute("CREATE INDEX IF NOT EXISTS ix_log_datetime ON PracticalLog(date_time)");
    }

    static void SeedIfEmpty()
    {
        if (_conn.Table<Standard>().Count() == 0)
        {
            _conn.InsertAll(new[] {
                new Standard{ std_num="9" },
                new Standard{ std_num="10" },
                new Standard{ std_num="11" },
                new Standard{ std_num="12" },
            });
        }

        if (_conn.Table<Subject>().Count() == 0)
        {
            var physicsId = _conn.Insert(new Subject { subject_name = "Physics" });
            var chemistryId = _conn.Insert(new Subject { subject_name = "Chemistry" });
            var biologyId = _conn.Insert(new Subject { subject_name = "Biology" });
            var mathId = _conn.Insert(new Subject { subject_name = "Mathematics" });

            int s11 = _conn.Table<Standard>().First(s => s.std_num == "11").std_id;
            int s12 = _conn.Table<Standard>().First(s => s.std_num == "12").std_id;
            int s10 = _conn.Table<Standard>().First(s => s.std_num == "10").std_id;
            int s9 = _conn.Table<Standard>().First(s => s.std_num == "9").std_id;

            _conn.InsertAll(new[] {
                new SubjectStandard{ subject_id = physicsId,   std_id = s11 },
                new SubjectStandard{ subject_id = physicsId,   std_id = s12 },
                new SubjectStandard{ subject_id = chemistryId, std_id = s11 },
                new SubjectStandard{ subject_id = biologyId,   std_id = s9  },
                new SubjectStandard{ subject_id = mathId,      std_id = s10 },
            });

            _conn.InsertAll(new[] {
                new Practical{ subject_id=physicsId,   std_id=s11, title="Ohm's Law",                    is_allowed=1 },
                new Practical{ subject_id=physicsId,   std_id=s12, title="Refraction of Light",          is_allowed=1 },
                new Practical{ subject_id=chemistryId, std_id=s11, title="Acid-Base Titration",          is_allowed=1 },
                new Practical{ subject_id=biologyId,   std_id=s9,  title="Plant Cell Observation",       is_allowed=0 },
                new Practical{ subject_id=mathId,      std_id=s10, title="Probability Simulation",       is_allowed=1 },
            });

            // Minimal users for quick testing (NOW hashed-only)
            EnsureAdmin("v", "v@v.com", "hash"); // will store SHA-256("hash")
            _conn.Insert(new Teacher { name = "SmithMehta", email = "smith@school.edu", password_hash = Queries.HashPassword("hash") });
            _conn.Insert(new Student { name = "Alice", email = "alice@school.edu", password_hash = Queries.HashPassword("hash"), roll_number = "R001", std_id = s11 });

            Debug.Log("[DB] Path: " + DbPath);
            Debug.Log("[DB] Admin count: " + _conn.Table<Admin>().Count());
            foreach (var a in _conn.Table<Admin>()) Debug.Log("[DB] Admin row: " + a.username);
        }
    }

    // NEW: attach stable scene keys to your Eng 1..8 practicals (non-destructive)
    static void SeedSceneKeysIfMissing()
    {
        // helper
        void UpsertSceneKey(string titleLike, string key)
        {
            // only set when missing or different
            _conn.Execute("UPDATE Practical SET scene_key = ? WHERE (scene_key IS NULL OR scene_key='') AND title LIKE ?", key, titleLike);
        }

        // Map your 8 Eng scenes; adjust LIKE patterns if your titles differ
        UpsertSceneKey("Eng 1%", "eng_1_equivalent_proportions");
        UpsertSceneKey("Eng 2%", "eng_2_frictional_pulley");
        UpsertSceneKey("Eng 3%", "eng_3_identify_acid_base");
        UpsertSceneKey("Eng 4%", "eng_4_heart");
        UpsertSceneKey("Eng 5%", "eng_5_light_reflection_refraction");
        UpsertSceneKey("Eng 6%", "eng_6_eye_defects_correction");
        UpsertSceneKey("Eng 7%", "eng_7_cuso4_solution_nh2oh");
        UpsertSceneKey("Eng 8%", "eng_8_cyclotron");
    }

    // UPDATED: hashed-only admin (matches your decision to drop plain-text login)
    static void EnsureAdmin(string username, string email, string rawPassword)
    {
        try
        {
            var existing = _conn.Table<Admin>().FirstOrDefault(a => a.username == username);
            var pwdHash = Queries.HashPassword(rawPassword);

            if (existing == null)
            {
                _conn.Insert(new Admin { username = username, email = email, password_hash = pwdHash });
                Debug.Log("[DB] Admin created: " + username);
            }
            else
            {
                existing.password_hash = pwdHash;
                _conn.Update(existing);
                Debug.Log("[DB] Admin ensured (updated hash): " + username);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("[DB] EnsureAdmin error: " + ex);
        }
    }
}
