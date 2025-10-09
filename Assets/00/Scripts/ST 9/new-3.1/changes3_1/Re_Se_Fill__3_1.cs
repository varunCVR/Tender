using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Re_Se_Fill__3_1 : MonoBehaviour
{
    private Renderer rd;
    public float fillPoint;

    public Color Reset;

    private void Start()
    {
        rd = this.GetComponent<Renderer>();
        rd.material.SetFloat("_Fill",fillPoint);
        rd.material.SetColor("_SideColor",Reset);
        rd.material.SetColor("_TopColor",Reset);
    }

}
