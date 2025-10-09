using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lenceEnter : MonoBehaviour
{
    public bool inner;
    public bool outter;

    private GameObject colobj;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N")  && !outter && !inner)
        {
            colobj = other.gameObject;
            inner = true;

        }
        if (other.CompareTag("S") && !outter && !inner) {
            colobj = other.gameObject;
            outter = true;
        }
    }


    private void Update()
    {
        if (inner && colobj.GetComponent<Rigidbody>().useGravity)
        {
            colobj.transform.localPosition =
                Vector3.MoveTowards(colobj.transform.localPosition, transform.localPosition, Time.deltaTime/10);
            colobj.transform.rotation = Quaternion.Lerp(colobj.transform.rotation, transform.rotation, Time.deltaTime * 10);
        }
        if (outter && colobj.GetComponent<Rigidbody>().useGravity)
        {
            colobj.transform.localPosition =
                Vector3.MoveTowards(colobj.transform.localPosition, transform.localPosition, Time.deltaTime/10);
            colobj.transform.rotation = Quaternion.Lerp(colobj.transform.rotation, transform.rotation, Time.deltaTime * 10);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N")) {
            inner = false;            
        }
        if (other.CompareTag("S")) {
            outter = false;            
        }
    }
}
