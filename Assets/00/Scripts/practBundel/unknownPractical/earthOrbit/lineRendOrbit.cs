using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineRendOrbit : MonoBehaviour
{
    public Transform endTarg;
    private LineRenderer lr;
    public Material lineColor;
    public float width;
    private void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        lr = GetComponent<LineRenderer>();
        lr.material = lineColor;
    }

    void Update()
    {
        lr.widthMultiplier = width;
        lr.SetPosition(0,transform.position);
        lr.SetPosition(1,endTarg.position);
    }
}
