using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knifeCutED : MonoBehaviour
{
    public Transform parObj;
    public GameObject cutObj;
    public bool cuted;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N") && !cuted)
        {
            cutObj.transform.SetParent(parObj);
            cutObj.SetActive(true);
            cuted = true;
        }
    }
}
