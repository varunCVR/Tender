using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if ADDRESSABLES
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
#endif

public class PracticalLauncher : MonoBehaviour
{
    [Header("Scene Map (optional if you use scene_key == sceneName)")]
    public PracticalSceneMap sceneMap;   // assign if you use a ScriptableObject map

    [Header("UI (optional)")]
    public GameObject loadingOverlay;    // spinner / overlay GO
    public TMP_Text loadingLabel;        // "Loading ..." text

    /// <summary>
    /// Launch a practical by its DB id for a specific student.
    /// Call this from your student list row/button.
    /// </summary>
    public void LaunchByPracticalId(int practicalId, int studentId)
    {
        var p = Queries.GetPracticalById(practicalId);
        if (p == null)
        {
            Debug.LogError($"[Launcher] Practical not found: id={practicalId}");
            return;
        }

        // scene_key is required (we added it earlier)
        var key = p.scene_key;
        if (string.IsNullOrEmpty(key))
        {
            Debug.LogError($"[Launcher] Missing scene_key for Practical id={practicalId}, title={p.title}");
            return;
        }

        // Start session (writes PENDING log)
        EnsureSession().Begin(studentId, practicalId);

        // UI
        SetLoading(true, $"Loading: {p.title}");

        // Resolve to addressable key or scene name
        string addressableKey = null;
        string sceneName = null;

        if (sceneMap != null && sceneMap.TryGet(key, out var entry))
        {
            addressableKey = entry.addressableKey;
            sceneName = entry.sceneName;
        }
        else
        {
            // fallback: assume scene_key == sceneName
            sceneName = key;
        }

#if ADDRESSABLES
        if (!string.IsNullOrEmpty(addressableKey))
        {
            Addressables.LoadSceneAsync(addressableKey, LoadSceneMode.Single).Completed += op =>
            {
                SetLoading(false);
                if (op.Status != AsyncOperationStatus.Succeeded)
                    Debug.LogError($"[Launcher] Addressable load failed: {addressableKey}");
            };
            return;
        }
#endif
        if (!string.IsNullOrEmpty(sceneName))
        {
            var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            op.completed += _ => SetLoading(false);
        }
        else
        {
            SetLoading(false);
            Debug.LogError($"[Launcher] No valid mapping for key={key}");
        }
    }

    PracticalSession EnsureSession()
    {
        if (PracticalSession.Instance != null) return PracticalSession.Instance;
        var go = new GameObject("PracticalSession");
        return go.AddComponent<PracticalSession>();
    }

    void SetLoading(bool on, string label = null)
    {
        if (loadingOverlay) loadingOverlay.SetActive(on);
        if (loadingLabel && !string.IsNullOrEmpty(label)) loadingLabel.text = label;
    }
}
