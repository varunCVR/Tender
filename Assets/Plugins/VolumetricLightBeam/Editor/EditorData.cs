#if UNITY_EDITOR
using UnityEngine;

namespace VLB
{
    public class EditorData : ScriptableObject
    {
        [SerializeField] private Texture2D buttonAddDustParticles = null;
        [SerializeField] private Texture2D buttonAddDynamicOcclusion = null;
        [SerializeField] private Texture2D buttonAddTriggerZone = null;
        [SerializeField] private Texture2D buttonAddEffect = null;
        [SerializeField] private Texture2D buttonFromSpotLight = null;

        public GUIContent contentAddDustParticles =>
            new GUIContent(Instance.buttonAddDustParticles, EditorStrings.Beam.ButtonAddDustParticles);

        public GUIContent contentAddDynamicOcclusion => new GUIContent(Instance.buttonAddDynamicOcclusion,
            EditorStrings.Beam.ButtonAddDynamicOcclusion);

        public GUIContent contentAddTriggerZone =>
            new GUIContent(Instance.buttonAddTriggerZone, EditorStrings.Beam.ButtonAddTriggerZone);

        public GUIContent contentAddEffect =>
            new GUIContent(Instance.buttonAddEffect, EditorStrings.Beam.ButtonAddEffect);

        public GUIContent contentFromSpotLight =>
            new GUIContent(Instance.buttonFromSpotLight, EditorStrings.Beam.FromSpotLight);

        private static EditorData ms_Instance = null;

        public static EditorData Instance
        {
            get
            {
                if (ms_Instance == null)
                {
                    ms_Instance = Resources.Load<EditorData>("VLBEditorData");
                    Debug.Assert(ms_Instance != null,
                        "Failed to find asset 'VLBEditorData', please reinstall the 'Volumetric Light Beam' plugin.");
                }

                return ms_Instance;
            }
        }
    }
}
#endif