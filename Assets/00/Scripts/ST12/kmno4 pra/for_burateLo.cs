using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_burateLo : MonoBehaviour
{
    public GameObject Location_obj;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coil") && other.GetComponent<Rigidbody>().useGravity)
        {
            other.transform.position = Location_obj.transform.position;
            other.transform.rotation = Quaternion.identity;
        }
    }
}
