using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetColor1 : MonoBehaviour
{
    private Renderer rd;

    public float fillPouint;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetColor("sColor", Color.white);
        rd.material.SetColor("lColor", Color.white);
        rd.material.SetColor("fColor", Color.white);
    }
    void Update()
    {      
        rd.material.SetFloat("FillArea",fillPouint);
    }
}
