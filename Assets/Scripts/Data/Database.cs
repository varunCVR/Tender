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
        try {
            SQLitePCL.Batteries_V2.Init();
            _conn = new SQLiteConnection(DbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            _conn.Execute("PRAGMA foreign_keys = ON;");

            // Create tables
            _conn.CreateTable<Admin>();
            _conn.CreateTable<Teacher>();
            _conn.CreateTable<Student>();
            _conn.CreateTable<Standard>();
            _conn.CreateTable<Subject>();
            _conn.CreateTable<SubjectStandard>();
            _conn.CreateTable<TeacherSubject>();
            _conn.CreateTable<Practical>();
            _conn.CreateTable<PracticalLog>();

            SeedIfEmpty();
            Debug.Log($"[DB] EduVerse XR ready at: {DbPath}");
        }
        catch (Exception ex) {
            Debug.LogError($"[DB] Init error: {ex}");
        }
    }

    static void SeedIfEmpty()
    {
        if (_conn.Table<Standard>().Count() == 0) {
            _conn.InsertAll(new[] {
                new Standard{ std_num="9" },
                new Standard{ std_num="10" },
                new Standard{ std_num="11" },
                new Standard{ std_num="12" },
            });
        }

        if (_conn.Table<Subject>().Count() == 0) {
            var physicsId   = _conn.Insert(new Subject{ subject_name="Physics" });
            var chemistryId = _conn.Insert(new Subject{ subject_name="Chemistry" });
            var biologyId   = _conn.Insert(new Subject{ subject_name="Biology" });
            var mathId      = _conn.Insert(new Subject{ subject_name="Mathematics" });

            int s11 = _conn.Table<Standard>().First(s => s.std_num=="11").std_id;
            int s12 = _conn.Table<Standard>().First(s => s.std_num=="12").std_id;
            int s10 = _conn.Table<Standard>().First(s => s.std_num=="10").std_id;
            int s9  = _conn.Table<Standard>().First(s => s.std_num=="9").std_id;

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

            // Minimal users for quick testing
            _conn.Insert(new Teacher{ name="Dr. Smith", email="smith@school.edu", password_hash="hash" });
            _conn.Insert(new Student{ name="Alice", email="alice@school.edu", password_hash="hash", roll_number="R001", std_id=s11 });
        }
    }
}
