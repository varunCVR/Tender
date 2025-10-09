using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class supDiff : MonoBehaviour
{
    public DEST_saltScript scpt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("K"))
        {
            scpt.enabled = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("K"))
        {

            scpt.enabled = true;

        }
    }
}
