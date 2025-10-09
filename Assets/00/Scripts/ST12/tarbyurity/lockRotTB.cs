using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockRotTB : MonoBehaviour
{
    private Vector3 rotL;

    private void Start()
    {
        rotL = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = Vector3.zero;
    }
}
