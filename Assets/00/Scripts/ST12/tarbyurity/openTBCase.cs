using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTBCase : MonoBehaviour
{

    void Update()
    {
        transform.localPosition = Vector3.zero;
            

        if (transform.localEulerAngles.y !=0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
        }

        if (transform.localEulerAngles.z !=0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, 0);
        }
    }

}
