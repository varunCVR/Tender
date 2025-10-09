using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillResetDS : MonoBehaviour
{
    private Renderer rd;
    public float fillPoint;
    public Color desiredColor;
    
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetColor("sColor",desiredColor);
        rd.material.SetColor("lColor",desiredColor);
        rd.material.SetColor("fColor",desiredColor);
    }

    // Update is called once per frame
    void Update()
    {
        rd.material.SetFloat("FillArea",fillPoint);
    }
}
