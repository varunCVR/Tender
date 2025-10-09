using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterShaderReset : MonoBehaviour
{
    private Renderer rd;

    public Color rest;

    public float fill;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        
        //rd.material.SetColor("_SideColor",rest);
        //rd.material.SetColor("_Topolor",rest);
    }

    // Update is called once per frame
    void Update()
    {
        rd.material.SetFloat("_Fill",fill);
    }
}
