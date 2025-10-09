using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidTrigger : MonoBehaviour
{
    public bool waterF;
    public bool sC;

    public GameObject waterSDrop;
    public GameObject smallcut;
    public GameObject flatDrop;
    public GameObject sliceGrabber;

    public GameObject real1;
    public GameObject real2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glow") && !waterF)
        {
            waterSDrop.SetActive(true);
            waterF = true;
        }

        if (other.CompareTag("Spoon") && other.GetComponent<abhiranJit>().abhiranJitB && waterF && !sC)
        {
            other.gameObject.SetActive(false);
            smallcut.SetActive(true);
            sC = true;
        }

        if (other.CompareTag("S") && sC)
        {
            waterSDrop.SetActive(false);
            flatDrop.SetActive(true);
            sliceGrabber.SetActive(false);
            
            real1.SetActive(false);
            real2.SetActive(true);
        }
    }
}
