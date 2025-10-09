using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_rotterr : MonoBehaviour
{
    public float rotationSpeed;
    private void Update()
    {
        transform.Rotate(1* Time.deltaTime * rotationSpeed,0,0);
    }
}
