using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class fixposition : MonoBehaviour
{
  public Transform getpos;
  public Transform downpos;
  public bool confirm;
  public float clickSpeed;
  public ParticleSystem is_buarette;
  
  [Space] public Renderer shaderDown;
  public Renderer flaskLiq;
  public Color pinkisColor;
  public Color pinkisColorDark;


  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player"))
    {
      confirm = true;
      is_buarette.Play();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (!other.CompareTag("Player"))
    {
      confirm = false;
      is_buarette.Stop();
    }
   
  }
  private void Update()
  {
    if (confirm)
    {
      transform.localPosition = Vector3.MoveTowards(transform.localPosition,downpos.position,Time.deltaTime * clickSpeed);

      if (shaderDown.material.GetFloat("FillArea")> -0.11f) {
        float fill = shaderDown.material.GetFloat("FillArea") - Time.deltaTime * 0.01f;
        shaderDown.material.SetFloat("FillArea",fill);
        
        Color a = Color.Lerp(flaskLiq.material.GetColor("sColor"), pinkisColor, Time.deltaTime/100);
        flaskLiq.material.SetColor("sColor",a);
        Color c = Color.Lerp(flaskLiq.material.GetColor("lColor"), pinkisColor, Time.deltaTime/100);
        flaskLiq.material.SetColor("lColor",c);
        Color b = Color.Lerp(flaskLiq.material.GetColor("fColor"), pinkisColorDark, Time.deltaTime/100);
        flaskLiq.material.SetColor("fColor",b);
      }

    }
    else
    {
      transform.localPosition = Vector3.MoveTowards(transform.localPosition,getpos.position,Time.deltaTime * clickSpeed);
      
    }
  }
}
