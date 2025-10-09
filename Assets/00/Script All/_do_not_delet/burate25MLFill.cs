using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burate25MLFill : MonoBehaviour
{
    public Renderer burateLiq;

    public bool startMethod;
    public bool updateMethod;

    [Range(1, 57f)]
    public float bFill;
    public float changer;
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
        if (bFill > 56.6f && burateLiq.enabled)
        {
            burateLiq.enabled = false;
        }

        if (bFill < 56.6f && !burateLiq.enabled)
        {
            burateLiq.enabled = true;
        }
        
        changer = 51 - bFill;
        var filler = 0.00601f;
        var realFill = changer * filler;
        burateLiq.material.SetFloat("_Fill", realFill);
    }
}