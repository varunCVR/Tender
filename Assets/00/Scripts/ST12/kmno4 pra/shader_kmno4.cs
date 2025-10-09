using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shader_kmno4 : MonoBehaviour
{
    private Renderer rd;
    public float fillPoint;
    public Color desiredColor;
    public Color desiredColor2;
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetFloat("FillArea",fillPoint);
        rd.material.SetColor("lColor",desiredColor);
        rd.material.SetColor("sColor",desiredColor);
        rd.material.SetColor("fColor",desiredColor2);
    }
}
