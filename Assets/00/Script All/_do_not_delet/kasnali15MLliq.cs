using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasnali15MLliq : MonoBehaviour
{
    public Renderer kasnaliRend;

    public bool startMethod;
    public bool updateMethod;

    [Range(0, 15)]
    public float fillp;

    private void Start()
    {
        if (startMethod) counterML100();
    }

    private void Update()
    {
        if (updateMethod) counterML100();
    }

    private void counterML100()
    {

        var filler = 0.0053333333333333f;
        var realFill = fillp * filler;
        kasnaliRend.material.SetFloat("_Fill", realFill);
        
    }
}
