using UnityEngine;
using System.Collections;

namespace VLB
{
    [ExecuteInEditMode]
    [HelpURL(Consts.Help.UrlSkewingHandle)]
    public class SkewingHandle : MonoBehaviour
    {
        public VolumetricLightBeam volumetricLightBeam = null;
        public bool shouldUpdateEachFrame = false;

#if UNITY_EDITOR
        private void Update()
        {
            if (!Application.isPlaying && CanSetSkewingVector())
                SetSkewingVector();
        }
#endif

        public bool IsAttachedToSelf()
        {
            return volumetricLightBeam != null && volumetricLightBeam.gameObject == gameObject;
        }

        public bool CanSetSkewingVector()
        {
            return volumetricLightBeam != null && volumetricLightBeam.canHaveMeshSkewing;
        }

        public bool CanUpdateEachFrame()
        {
            return CanSetSkewingVector() && volumetricLightBeam.trackChangesDuringPlaytime;
        }

        private bool ShouldUpdateEachFrame()
        {
            return shouldUpdateEachFrame && CanUpdateEachFrame();
        }

        private void OnEnable()
        {
            if (CanSetSkewingVector())
                SetSkewingVector();
        }

        private void Start()
        {
            if (Application.isPlaying && ShouldUpdateEachFrame()) StartCoroutine(CoUpdate());
        }

        private IEnumerator CoUpdate()
        {
            while (ShouldUpdateEachFrame())
            {
                SetSkewingVector();
                yield return null;
            }
        }

        private void SetSkewingVector()
        {
            Debug.Assert(CanSetSkewingVector());
            var vec = volumetricLightBeam.transform.InverseTransformPoint(transform.position);
            volumetricLightBeam.skewingLocalForwardDirection = vec;
        }
    }
}