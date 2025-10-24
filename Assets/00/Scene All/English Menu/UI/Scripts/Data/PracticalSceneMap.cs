using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EduVerseXR/Practical Scene Map")]
public class PracticalSceneMap : ScriptableObject
{
    [Serializable]
    public class Entry
    {
        public string sceneKey;       // matches Practical.scene_key
        public string addressableKey; // if using Addressables
        public string sceneName;      // SceneManager fallback
    }

    public List<Entry> entries = new();

    private Dictionary<string, Entry> _dict;

    void OnEnable()
    {
        _dict = new Dictionary<string, Entry>(StringComparer.OrdinalIgnoreCase);
        foreach (var e in entries)
        {
            if (!string.IsNullOrWhiteSpace(e.sceneKey) && !_dict.ContainsKey(e.sceneKey))
                _dict[e.sceneKey] = e;
        }
    }

    public bool TryGet(string sceneKey, out Entry entry)
    {
        if (_dict == null) OnEnable();
        return _dict.TryGetValue(sceneKey ?? "", out entry);
    }
}
