using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockTargetObj : MonoBehaviour
{
    private float xClamp;
    private Vector3 pos;

    private void Awake()
    {
        pos = transform.localPosition;
    }

    void Update()
    {
        float yclmp = Mathf.Clamp(transform.localPosition.y,-0.01f,.01f);
        float zclmp = Mathf.Clamp(transform.localPosition.z,-0.01f,0.01f);
        float xclamp = Mathf.Clamp(transform.localPosition.x, -1, 1);
        
        transform.localPosition = new Vector3(xclamp, yclmp, zclmp);
       
        transform.rotation = Quaternion.identity;
    }
}
