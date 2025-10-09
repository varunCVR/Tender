using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enter_liq_flask : MonoBehaviour
{
    public bool flaskSet;
    public Collider cdd;
    
    [Space] 
    public Transform target;
    public Transform location;

    [HideInInspector] public bool ttt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            ttt = true;
            flaskSet = true;
            cdd.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            flaskSet = false;
        }
    }

    private void Update()
    {
        if (flaskSet && target.gameObject.GetComponent<Rigidbody>().useGravity)
        {
            target.position = Vector3.MoveTowards(target.position, location.position, Time.deltaTime * 0.1f);
        }
        
        if (target.position == location.position && !cdd.enabled)
            cdd.enabled = true;
        else if (target.position!=location.position && cdd.enabled)
            cdd.enabled = false;
    }
}
