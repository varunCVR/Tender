using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lrpointSet3Times : MonoBehaviour
{
    public Transform midPos;
    public Transform endPos;

    private LineRenderer lr;

    public Material lrMat;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material=lrMat;
    }

    void Update()
    {
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,midPos.position);
        lr.SetPosition(2,endPos.position);
    }
}
