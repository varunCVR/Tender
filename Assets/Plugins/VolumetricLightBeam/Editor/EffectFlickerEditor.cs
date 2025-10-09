#if UNITY_EDITOR
using UnityEditor;

namespace VLB
{
    [CustomEditor(typeof(EffectFlicker))]
    [CanEditMultipleObjects]
    public class EffectFlickerEditor : EffectAbstractBaseEditor<EffectFlicker>
    {
        private SerializedProperty performPauses = null;
        private SerializedProperty flickeringDuration = null;
        private SerializedProperty pauseDuration = null;
        private SerializedProperty frequency = null;
        private SerializedProperty intensityAmplitude = null;
        private SerializedProperty smoothing = null;

        protected override void DisplayChildProperties()
        {
            if (FoldableHeader.Begin(this, EditorStrings.Effects.HeaderTimings))
            {
                EditorGUILayout.PropertyField(frequency, EditorStrings.Effects.FrequencyFlicker);

                EditorGUILayout.PropertyField(performPauses, EditorStrings.Effects.PerformPauses);

                if (m_Targets.HasAtLeastOneTargetWith((EffectFlicker comp) => { return comp.performPauses == true; }))
                {
                    EditorGUILayout.PropertyField(flickeringDuration, EditorStrings.Effects.FlickeringDuration);
                    EditorGUILayout.PropertyField(pauseDuration, EditorStrings.Effects.PauseDuration);
                }
            }

            FoldableHeader.End();

            if (FoldableHeader.Begin(this, EditorStrings.Effects.HeaderVisual))
            {
                EditorGUILayout.PropertyField(intensityAmplitude, EditorStrings.Effects.IntensityAmplitude);
                EditorGUILayout.PropertyField(smoothing, EditorStrings.Effects.Smoothing);
            }

            FoldableHeader.End();
        }
    }
}
#endif