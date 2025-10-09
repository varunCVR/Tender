using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class for_saltwtr : MonoBehaviour
{
    public bool onoff;

    public bool entrd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            onoff = true;
            entrd = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            onoff = false;
        }
    }
}
