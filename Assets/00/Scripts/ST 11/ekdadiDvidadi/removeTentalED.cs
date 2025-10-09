using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeTentalED : MonoBehaviour
{
    public float entTime;
    public bool enterd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SmallCut")
        {
            enterd = true;
            other.GetComponent<abhiranJit>().abhiranJitB = true;
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "SmallCut")
        {
            enterd = false;
        }
    }
}
