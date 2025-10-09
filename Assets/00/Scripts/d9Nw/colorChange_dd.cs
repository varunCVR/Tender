using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange_dd : MonoBehaviour
{
    public Renderer rend;
    public Color desiredColor;

    public bool updateM;

    private void Start()
    {
        rend.material.SetColor("_LCol",desiredColor);
        rend.material.SetColor("_SCol",desiredColor);
    }

    private void Update()
    {
        if (updateM)
        {
            rend.material.SetColor("_LCol",desiredColor);
            rend.material.SetColor("_SCol",desiredColor);
        }
    }
}
