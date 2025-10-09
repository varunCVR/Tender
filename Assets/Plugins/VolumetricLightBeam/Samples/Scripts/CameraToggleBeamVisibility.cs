using UnityEngine;

namespace VLB_Samples
{
    [RequireComponent(typeof(Camera))]
    public class CameraToggleBeamVisibility : MonoBehaviour
    {
        [SerializeField] private KeyCode m_KeyCode = KeyCode.Space;

        private void Update()
        {
            if (Input.GetKeyDown(m_KeyCode))
            {
                var cam = GetComponent<Camera>();

                var layerID = VLB.Config.Instance.geometryLayerID;
                var layerMask = 1 << layerID;
                if ((cam.cullingMask & layerMask) == layerMask)
                    cam.cullingMask &= ~layerMask;
                else
                    cam.cullingMask |= layerMask;
            }
        }
    }
}