using UnityEngine;
using System;

public class PracticalSession : MonoBehaviour
{
    public static PracticalSession Instance { get; private set; }

    public int StudentId { get; private set; }
    public int PracticalId { get; private set; }
    public DateTime StartedUtc { get; private set; }
    public bool IsActive { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>Call before scene load. Logs PENDING.</summary>
    public void Begin(int studentId, int practicalId)
    {
        StudentId = studentId;
        PracticalId = practicalId;
        StartedUtc = DateTime.UtcNow;
        IsActive = true;

        // create a PENDING log row
        Queries.AddLog(StudentId, PracticalId, completed: false);
    }

    /// <summary>Call from your final trigger. Updates log as COMPLETED.</summary>
    public void MarkCompleted()
    {
        if (!IsActive) return;
        Queries.AddLog(StudentId, PracticalId, completed: true);
        IsActive = false;
    }

    /// <summary>Optional: call when backing out without finishing.</summary>
    public void Abort()
    {
        IsActive = false;
        // We already wrote a PENDING entry at Begin; keep it as history.
    }
}
