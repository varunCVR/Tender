using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pencilecolor : MonoBehaviour
{
    public Renderer wtr;
    public Color desiredColor;

    private void Start()
    {
        wtr.material.SetColor("waterColor", desiredColor);
    }
    
}