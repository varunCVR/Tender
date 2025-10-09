using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_Yliq : MonoBehaviour
{
    
    public Renderer y_glassRend;
    public ParticleSystem y_glassPS;
    public Renderer _fask_Main;

    [Header("Speed Space")] 
    public float reduceSped;
    public float increaSpd;

    [Space]
    public bool yLiqEnding;

    public GameObject glassXR;
    public GameObject glassXF;


    [Space]
    public AudioSource player;
    private int i;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Event") && !yLiqEnding)
        {
            if (y_glassRend.material.GetFloat("_Fill") > 0.5069f)
            {
                if (i != 1)
                {
                    player.PlayOneShot(player.clip);
                    i = 1;
                }
                if (y_glassPS.isStopped)
                { 
                    y_glassPS.Play();
                }
                float fillPoint = y_glassRend.material.GetFloat("_Fill") - Time.deltaTime * reduceSped;
                y_glassRend.material.SetFloat("_Fill",fillPoint);
                
                if (_fask_Main.material.GetFloat("_Fill") < 0.515f)
                {
                    float fillPoint1 = _fask_Main.material.GetFloat("_Fill") + Time.deltaTime * increaSpd;
                    _fask_Main.material.SetFloat("_Fill",fillPoint1);
                }
            }

            if (y_glassRend.material.GetFloat("_Fill") < 0.5069f)
            {
                y_glassRend.material.SetFloat("_Fill",-1);
                y_glassPS.Stop();
                yLiqEnding = true;
                if (i != 0)
                {
                    player.Stop();
                    i = 0;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            if (i != 0)
            {
                player.Stop();
                i = 0;
            }
            y_glassPS.Stop();
        }
    }

    private void Update()
    {
        if (yLiqEnding && glassXF.activeInHierarchy)
        {
            glassXR.SetActive(true);
            glassXF.SetActive(false);
        }
    }
}
