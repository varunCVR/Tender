using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class lastTriggerEnter : MonoBehaviour
{
    public bool enters;
    public GameObject col;
    public Transform pos;
    public Collider buttonCol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S"))
        {
            enters = true;
        }
    }

    private void Update()
    {
        if (enters && col.GetComponent<Rigidbody>().useGravity) {
            col.transform.localPosition =
                Vector3.MoveTowards(col.transform.localPosition, pos.localPosition, Time.deltaTime);
            col.transform.rotation = Quaternion.Lerp(col.transform.rotation, pos.rotation, Time.deltaTime*10);
        }

        if (col.transform.localPosition == pos.localPosition && !buttonCol.enabled) {
            buttonCol.enabled = true;
        }

        if (col.transform.localPosition != pos.localPosition && buttonCol.enabled) {
            buttonCol.enabled = false;
        }

    } 

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("S"))
        {
            enters = false;
        }
    }
}
