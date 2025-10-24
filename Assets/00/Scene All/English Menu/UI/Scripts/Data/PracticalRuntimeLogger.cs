using UnityEngine;

public class PracticalRuntimeLogger : MonoBehaviour
{
    public int studentId;    // set from your session
    public int practicalId;  // set before loading or via scene param

    // Call this when the final trigger fires
    public void MarkCompleted()
    {
        Queries.AddLog(studentId, practicalId, completed: true);
        Debug.Log($"Practical completed: student={studentId}, practical={practicalId}");
    }
}
