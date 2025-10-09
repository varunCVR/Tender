using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slatEnt : MonoBehaviour
{
    public GameObject slatObj;
    public bool salty;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("iceall") && !salty)
        {
            slatObj.SetActive(true);
            salty = true;
        }
    }
}
