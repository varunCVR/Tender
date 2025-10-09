using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVrCameras : MonoBehaviour
{
    public Camera centerEye, leftEye, rightEye;

    private void Start()
    {
        StartCoroutine(DisableCameras());
    }

    IEnumerator DisableCameras()
    {
        yield return new WaitForSeconds(5f);
        centerEye.enabled = false;

        yield return new WaitForSeconds(5f);
        centerEye.enabled = true;
        leftEye.enabled = false;

        yield return new WaitForSeconds(3f);
        leftEye.enabled = true;
    }
}
