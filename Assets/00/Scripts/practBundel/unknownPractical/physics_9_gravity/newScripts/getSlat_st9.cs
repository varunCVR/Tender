using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSlat_st9 : MonoBehaviour
{
    public bool salty;
    public GameObject slatObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !salty)
        {   
            slatObj.SetActive(true);
            salty = true;
        }
    }
}
