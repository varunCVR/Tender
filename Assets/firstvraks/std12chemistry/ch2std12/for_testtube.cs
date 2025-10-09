using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_testtube : MonoBehaviour
{
    public ParticleSystem ParticleSystem_nh4oh;
    private bool trufasle;
    public Color updatecolor;

    [Space]
    private float i;
    private Color lerpBlue;
    public Renderer owncolor;
    public waterShaderReset fillR;


    private int framesCounter;
    //dropper Area
    [Space] 
    public Transform dropper;

    [HideInInspector] public bool endBool;

    private void Start()
    {
        lerpBlue = owncolor.material.GetColor("_SideColor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ParticleSystem_nh4oh.Play();
            trufasle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           ParticleSystem_nh4oh.Stop();
           trufasle = false;
        }
    }

    private void Update()
    {
        if (trufasle)
        {

            if (dropper.localScale.y > 0 && fillR.fill < 0.58f)
            {
                dropper.localScale = new Vector3(dropper.localScale.x, dropper.localScale.y - Time.deltaTime * 0.08f, dropper.localScale.z);
                fillR.fill += Time.deltaTime * 0.001f;
            }

            if (fillR.fill >= 0.58f || dropper.localScale.y <= 0)
            {
                ParticleSystem_nh4oh.Stop();
            }

            if (i < 1)
            {
                if (framesCounter <= 60)
                {
                    i += Time.deltaTime * 0.01f;
                    framesCounter++;
                }
                else
                {
                    i += Time.deltaTime * 0.03f;
                }
                
                lerpBlue = Color.Lerp(lerpBlue,updatecolor,i);
                owncolor.material.SetColor("_SideColor",lerpBlue);
                owncolor.material.SetColor("_TopColor",lerpBlue);
                
                Debug.Log("The i Value: "+ i);
            }

            if (i>=1 && !endBool)
            {
                endBool = true;
            }
        }
    }
}
