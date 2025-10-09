using System;
using BNG;
using UnityEngine;

public class coverScriptMiddle : MonoBehaviour
{ 
    public SetMagnetUpAndDown _rightWire; 
    public SetMagnetUpAndDown _leftWire;
    public GameObject cover;
    public GameObject hc_ocillus;
    [Space] public GameObject lastActivationObjs;
    public GameObject lastCanvas;
    [Space]
    public SetMagnetUpAndDown lastJoint;

    public SetMagnetUpAndDown hcObj;

    public Collider switchTrigger;
    private void Update()
    {
        if (_rightWire.Connected && _leftWire.Connected && !cover.activeInHierarchy)
        {
            hc_ocillus.SetActive(true);
            cover.SetActive(true);
        }

        if (lastJoint.Connected && hcObj.Connected && !switchTrigger.enabled)
        {
            lastCanvas.SetActive(false);
                lastActivationObjs.SetActive(true);
            switchTrigger.enabled = true;
            gameObject.SetActive(false);

        }
    }
}
