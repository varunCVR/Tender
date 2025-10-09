using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class connectWire : MonoBehaviour
{
    public bool defineRight;
    public bool wCon;
    private GameObject oth;
    private void OnTriggerEnter(Collider other)
    {
        if (defineRight) {
            if (other.CompareTag("water3")) {
                other.GetComponent<Grabbable>().enabled = false;
                Destroy(other.GetComponent<Rigidbody>());
                Destroy(other.GetComponent<Collider>());
                oth = other.gameObject;
                wCon = true;

            }
           
        }
        if (!defineRight) {
            if (other.CompareTag("water2")) {  
                other.GetComponent<Grabbable>().enabled = false; 
                Destroy(other.GetComponent<Rigidbody>());
                Destroy(other.GetComponent<Collider>());
                oth = other.gameObject;
                wCon = true;
            }
        }
    }

    private void Update()
    {
        if (wCon) {
            if (oth.transform.position!= transform.position) {
                oth.transform.position = transform.position;
            }
        }
    }
}
