using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipett25ML : MonoBehaviour
{
    public Renderer pipetRend;

    public bool startMethod;
    public bool updateMethod;

    [Range(-1.2f, 25)]
    public float fillp;

    private void Start()
    {
       if (startMethod) counterML25();
    }

    private void Update()
    {
        if (updateMethod) counterML25();
    }
    private void counterML25()
    {
        if (fillp <= -1.2f && pipetRend.enabled)
        {
            pipetRend.enabled = false;
        }

        if (fillp > -1.2f && !pipetRend.enabled)
        {
            pipetRend.enabled = true;
        }

        var filler = 0.006164f;
        var realFill = fillp * filler;
        pipetRend.material.SetFloat("_Fill", realFill);
    }
}
