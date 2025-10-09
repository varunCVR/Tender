using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_fix_cleaner : MonoBehaviour
{
    public bool confirm;
    public GameObject realFunal;
    public GameObject funalLocation;

    [HideInInspector] public bool xxx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("X"))
        {
            confirm = true;
        }
    }
    
    private void Update()
    {
        if (confirm && realFunal.GetComponent<Rigidbody>().useGravity)
        {
            realFunal.transform.position = funalLocation.transform.position;
            realFunal.transform.eulerAngles = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("X"))
        {
            xxx = true;
            confirm = false;
        }
    }
}
