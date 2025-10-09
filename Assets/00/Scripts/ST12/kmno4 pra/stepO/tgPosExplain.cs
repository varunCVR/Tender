using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tgPosExplain : MonoBehaviour
{
    public Transform real;
    private bool confirm;
    public Vector3 ccd;
    public Vector3 cc1;

    public bool block;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == this.name)
        {
            confirm = true;
        }
    }

    private void Update()
    {
        if (confirm)
        {
            if (block)
            {            real.position = transform.position;

            }
            else
            {
                real.localPosition = transform.localPosition;

            }
            ccd = real.position;
            cc1 = real.localPosition;
        }
    }
}
