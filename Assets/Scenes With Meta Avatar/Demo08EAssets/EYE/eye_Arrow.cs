using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye_Arrow : MonoBehaviour
{
    public Transform target;
    public Transform parLoc;
    public Renderer rd;
    public float value;


    public Material middleMat;
    public Material guruMat;
    public Material laguMat;
    private void Update()
    {
        float xpoint = parLoc.localPosition.x;

        if (xpoint < 0)
        {
            rd.material = laguMat;
        }

        if (xpoint > 0)
        {
            rd.material = guruMat;
        }

        if (xpoint == 0)
        {
            rd.material = middleMat;
        }


        float xWave = Mathf.Sin(Time.time * 5)*1;
        value = xWave;
        Vector3 set = new Vector3(xWave, 0, 0);
        target.localPosition = set;
    }
}
