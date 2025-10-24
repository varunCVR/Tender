using UnityEngine;

public class PassthroughController : MonoBehaviour
{
    [Header("Meta Passthrough")]
    public OVRPassthroughLayer passthroughLayer; // from camera rig (Building Blocks)

    [Header("Scene Groups")]
    public GameObject labRoot;      // everything you want hidden in MR
    public GameObject[] keepRoots;  // table, instruction canvases, etc. that should stay

    [Header("Camera (optional masks)")]
    public Camera xrCamera;         // center eye camera if you want culling masks
    public LayerMask normalMask;    // default (all layers you normally render)
    public LayerMask passthroughMask; // only layers of your keepRoots (optional)

    bool _isPassthrough;

    public void TogglePassthrough()
    {
        SetPassthrough(!_isPassthrough);
    }

    public void SetPassthrough(bool on)
    {
        _isPassthrough = on;

        // Turn on/off passthrough
        if (passthroughLayer) passthroughLayer.enabled = on;

        // Hide the lab; keep selected roots on
        if (labRoot) labRoot.SetActive(!on);
        if (keepRoots != null)
        {
            foreach (var go in keepRoots)
                if (go) go.SetActive(true); // always visible in both modes
        }

        // Optional: tighten what the camera renders when in passthrough
        if (xrCamera)
            xrCamera.cullingMask = on ? (int)passthroughMask : (int)normalMask;

        // Optional: make sure background is transparent for URP/BIRP
        if (xrCamera && on)
        {
            xrCamera.clearFlags = CameraClearFlags.SolidColor;
            var c = xrCamera.backgroundColor; c.a = 0f;
            xrCamera.backgroundColor = c;
        }
    }
}
