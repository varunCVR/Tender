using UnityEngine;

namespace VLB_Samples
{
    public class FeaturesNotSupportedMessage : MonoBehaviour
    {
        private void Start()
        {
            if (!VLB.Noise3D.isSupported)
                Debug.LogWarning(VLB.Noise3D.isNotSupportedString);
        }
    }
}