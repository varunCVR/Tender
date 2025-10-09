using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPressScript_d9 : MonoBehaviour
{
    public flaskSETTrigger setSignal;

    public bool butPress;
    public Transform target;
    public Transform presed;
    public Transform un_presed;
    public float pressSpeed;

    public ParticleSystem one_Drop;
    [Space] 
    public burate25MLFill burateFill;
    public float stopPoint;
    public float dropSpeed;
    [Space]
    public Color endResultColor;
    public Renderer colorChange;
    public GameObject endResult;
    private void OnTriggerEnter(Collider other)
    {
        butPress = true;
    }

    private void Update()
    {
       transButtons();
       if (butPress && setSignal)
       {
           if (burateFill.bFill < stopPoint)
           {
               burateFill.bFill += Time.deltaTime * dropSpeed;
               if (!one_Drop.isPlaying)
               {
                   one_Drop.Play();
               }
               color_Changed();
           }

           if (burateFill.bFill >= stopPoint)
           {
               if (!one_Drop.isStopped)
               {
                   endResult.SetActive(true);
                   one_Drop.Stop();
               }
           }
       }

       if (!butPress || !setSignal)
       {
           one_Drop.Stop();
       }
    }

    void color_Changed()
    {
        
        Color a = colorChange.material.GetColor("sColor");
        Color b = Color.Lerp(a, endResultColor, Time.deltaTime * 0.13f);
        colorChange.material.SetColor("sColor",b);
        colorChange.material.SetColor("fColor",b);
        colorChange.material.SetColor("lColor",b);
    }

    private void transButtons()
    {
        if (butPress)
        {
            target.position = Vector3.MoveTowards(target.position, presed.position, Time.deltaTime * pressSpeed);
        }
        else
        {
            target.position = Vector3.MoveTowards(target.position, un_presed.position, Time.deltaTime * pressSpeed);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        butPress = false;
    }
}
