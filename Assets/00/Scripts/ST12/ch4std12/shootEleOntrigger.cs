using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEleOntrigger : MonoBehaviour
{
    public GameObject ele;
    public Transform spownPoint;
    public Transform eleStorage;

    public FORSPIN spinEle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            spinEle.reacherFollower.Stop();
            other.transform.localPosition = new Vector3(0, other.transform.localPosition.y, other.transform.localPosition.z);
            spinEle.helper = 0;
            Instantiate(ele, spownPoint.position, spownPoint.rotation, eleStorage);
        }
    }
}
