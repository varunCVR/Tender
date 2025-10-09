 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enter_wtr : MonoBehaviour
{
//    public GameObject _300gmObj;
    public Text reader_weight;
    public bool onoff;


    [HideInInspector]public bool firstTime;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            onoff = true;
            firstTime = true;
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
