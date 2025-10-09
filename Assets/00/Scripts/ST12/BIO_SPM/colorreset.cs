using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorreset : MonoBehaviour
{
    private Renderer rd;
    public Color col;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetColor("_Basecolor",col);
    }
}
