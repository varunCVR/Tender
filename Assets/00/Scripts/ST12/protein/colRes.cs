using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colRes : MonoBehaviour
{
    private Renderer rd;
    public Color pinkish;
    private void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetColor("sColor", pinkish);
        rd.material.SetColor("lColor", pinkish);
        rd.material.SetColor("fColor", pinkish);
        rd.material.SetFloat("FillArea",0.025f);
    }
}
