using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reseterED : MonoBehaviour
{
    private Renderer rd;

    public Color desCol;

    public float fill = 1;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        rd.material.SetFloat("_Fill",fill);
        rd.material.SetColor("_SideColor",desCol);
        rd.material.SetColor("_TopColor",desCol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
