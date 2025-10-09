using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experimentingWithRotation : MonoBehaviour
{
    public float speed;

    private float tt;
    private void FixedUpdate()
    {
        tt += Time.deltaTime;
        if (tt <= 2)
            transform.Rotate(-Vector3.right * speed);
    }
}
