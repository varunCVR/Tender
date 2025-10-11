using UnityEngine;
using System.IO;
using SQLite;
using System.Linq;

public class DbDoctor : MonoBehaviour
{
    void Start()
    {
        // Debug.Log("=== DB DOCTOR START ===");

        // // 1) Confirm path + existence
        // var path = Database.DbPath;
        // Debug.Log("[DB] Path: " + path);
        // Debug.Log("[DB] Exists: " + File.Exists(path));

        // // 2) Ensure connection and list tables
        // var db = Database.Conn;
        // var tables = db.Query<Sc>("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;");
        // Debug.Log("[DB] Tables: " + string.Join(", ", tables.Select(t => t.name)));

        // // 3) Count admins
        // int adminCount = 0;
        // try { adminCount = db.Table<Admin>().Count(); } catch (System.Exception ex) { Debug.LogError("[DB] Count Admin failed: " + ex); }
        // Debug.Log("[DB] Admin count BEFORE ensure: " + adminCount);

        // // 4) Force an admin row with a RAW SQL insert (bypasses ORM)
        // try
        // {
        //     //db.Execute("INSERT INTO Admin (username,email,password_hash) VALUES (?,?,?)", "v", "v@v.com", "hash");
        //     Debug.Log("[DB] Raw INSERT into Admin done.");
        // }
        // catch (System.Exception ex)
        // {
        //     Debug.LogWarning("[DB] Raw INSERT failed (maybe duplicate already?): " + ex.Message);
        // }

        // // 5) Read back admins
        // var admins = db.Table<Admin>().ToList();
        // Debug.Log("[DB] Admin rows NOW: " + admins.Count);
        // foreach (var a in admins)
        //     Debug.Log($"[DB] Admin row -> username='{a.username}', email='{a.email}'");

        // Debug.Log("=== DB DOCTOR END ===");
    }

    // class Sc { public string name { get; set; } }
}
