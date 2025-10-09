using UnityEngine;
using SQLite;
using System.IO;

public class SQLiteSmokeTest : MonoBehaviour
{
    class TestUser
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    void Start()
    {
        try
        {
            SQLitePCL.Batteries_V2.Init();

            string path = Path.Combine(Application.persistentDataPath, "smoke_test.db3");
            var conn = new SQLiteConnection(path);
            conn.CreateTable<TestUser>();

            conn.Insert(new TestUser { Name = "Alice" });
            int count = conn.Table<TestUser>().Count();

            Debug.Log($"✅ SQLite works! Row count: {count}, DB Path: {path}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"❌ SQLite error: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
