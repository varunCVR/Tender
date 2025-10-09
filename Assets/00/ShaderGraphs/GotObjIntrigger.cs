using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotObjIntrigger : MonoBehaviour
{

    GameObject targetObj;
    public BoxCollider coll;
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<AudioHolder>())
        {
            if (targetObj == null)
            {
                other.GetComponent<AudioHolder>().Play();
                targetObj = other.gameObject;
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<AudioHolder>())
        {
            if (targetObj != null)
            {
                other.GetComponent<AudioHolder>().Stop();
                targetObj = null;
            }


        }


    }
}
