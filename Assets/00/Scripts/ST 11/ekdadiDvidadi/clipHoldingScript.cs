using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class clipHoldingScript : MonoBehaviour
{
    public GameObject stickPosition;
    GameObject stickObj;
    
    [HideInInspector]
    public bool isPos, isCheck;

    private void Update()
    {
        if (isPos && isCheck)
        {
            Destroy(stickObj.GetComponent<Rigidbody>());
            stickObj.transform.parent = stickPosition.transform;
            stickObj.transform.position = stickPosition.transform.position;
            stickObj.transform.rotation = stickPosition.transform.rotation;
        }
        else
        {
            if(stickObj)
            {
                if (!stickObj.GetComponent<Rigidbody>())
                {
                    stickObj.AddComponent<Rigidbody>();
                    stickObj.GetComponent<Rigidbody>().mass = .1f;
                    stickObj.GetComponent<Rigidbody>().linearDamping = 10;
                    stickObj.GetComponent<Rigidbody>().angularDamping = 20;
                }
                stickObj.transform.parent = null;
                stickObj.transform.position = stickObj.transform.position;
                stickObj.transform.rotation = stickObj.transform.rotation;
            }      
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spoon")
        {
            stickObj = other.gameObject;
            isCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spoon")
        {
            isCheck = false;
        }
    }
        //17.696f z 
}
