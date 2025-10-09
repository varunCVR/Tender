using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platinumgol : MonoBehaviour
{
    public GameObject golbhag;
    public GameObject paste;

    GameObject Wire;

    bool isTrue;

    private void Start()
    {
        Wire = golbhag.transform.parent.gameObject;
    }

    private void Update()
    {
        if(isTrue)
        {
            if(Wire.GetComponent<Rigidbody>().collisionDetectionMode == CollisionDetectionMode.ContinuousDynamic)
            {
                transform.GetComponent<Renderer>().enabled = false;
                golbhag.SetActive(true);
                paste.SetActive(true);
                transform.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FC")
        {
            isTrue = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FC")
        {
            isTrue = false;
        }
    }
}

