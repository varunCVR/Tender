using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hexaAdderTB : MonoBehaviour
{
    public GameObject hexaAll;
    public bool hexa;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N") && other.GetComponent<Rigidbody>().mass == 1)
        {
            hexaAll.SetActive(true);
            hexa = true;
        }
    }
}
