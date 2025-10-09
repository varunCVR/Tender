using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class leftSetPosForAll : MonoBehaviour
{
 
    public Transform Leafloc;
    private GameObject grbObj;
    public bool EnterTime;
    [Space] 
    public treeTimming boolT;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enterd");
        
        
        if (other.CompareTag("water2") || other.CompareTag("water3") || other.CompareTag("water4"))
        {
            
            if (!EnterTime && !boolT.timeOver && other.GetComponent<Rigidbody>().mass == 2 && other.GetComponent<Rigidbody>().linearDamping == 2)
            {
                
                Debug.Log("enterd");

                grbObj = other.gameObject;
                EnterTime = true;
                other.GetComponent<Rigidbody>().useGravity = false;

                other.GetComponent<Grabbable>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }

    private void Update()
    {
        if (EnterTime)
        {
                grbObj.transform.position = Leafloc.position;
                grbObj.transform.rotation = Leafloc.rotation;

        }
    }
}
