using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flaskSETTrigger : MonoBehaviour
{
    public GameObject flaskOrg;
    public Transform flaskLocation;
    public bool flaskenter;

    [Space] 
    public bool setFlask;

    [Space] public Collider buttonCOL;

    [HideInInspector] public bool firstSet;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            firstSet = true;
            buttonCOL.enabled = true;
            flaskenter = true;
        }
    }

    private void Update()
    {
        if (flaskenter && flaskOrg.GetComponent<Rigidbody>().useGravity)
        {
            flaskOrg.transform.position =
                Vector3.MoveTowards(flaskOrg.transform.position, flaskLocation.position, Time.deltaTime);
            flaskOrg.transform.rotation = Quaternion.identity;
        }

        if (flaskOrg.transform.position == flaskLocation.position && !setFlask)
        {
            setFlask = true;
        }
        else if (flaskOrg.transform.position != flaskLocation.position && setFlask)
        {
            setFlask = false;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            buttonCOL.enabled = false;
            flaskenter = false;
        }
    }
}
