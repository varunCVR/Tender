using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBliqRset : MonoBehaviour
{
    public float fillPoint;
    private Renderer rd;

    public bool resetColor;
    public Color col;
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetFloat("_Fill",fillPoint);
        if (resetColor)
        {
            rd.material.SetColor("_SideColor",col);
            rd.material.SetColor("_TopColor",col);
        }
    }
}
