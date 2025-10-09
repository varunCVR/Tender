using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_button : MonoBehaviour
{
  public Transform getpos;
  public Transform downpos;
  public bool confirm;
  public float clickSpeed;
  public ParticleSystem is_buarette;
  public GameObject enter_trigger;
  
  [Space] 
  public Renderer shaderDown;
  public Renderer flaskLiq;
  public Color pinkisColor;
  public Color pinkisColorDark;

  [HideInInspector] public bool the_end;
  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player"))
    {
      confirm = true;
      is_buarette.Play();
    }
    enter_trigger.SetActive(true);
  }
  private void OnTriggerExit(Collider other)
  {
    if (!other.CompareTag("Player"))
    {
      confirm = false;
      is_buarette.Stop();
    }
    enter_trigger.SetActive(false);
  }
  
  private void Update()
  {
    if (confirm)
    {
        transform.position = Vector3.MoveTowards(transform.position, downpos.position, Time.deltaTime * clickSpeed);

        if (shaderDown.material.GetFloat("FillArea") > 0.318f) {
          float fill = shaderDown.material.GetFloat("FillArea") - Time.deltaTime * 0.01f;
          shaderDown.material.SetFloat("FillArea",fill);
        
          Color a = Color.Lerp(flaskLiq.material.GetColor("sColor"), pinkisColor, Time.deltaTime/9);
          flaskLiq.material.SetColor("sColor",a);
          Color c = Color.Lerp(flaskLiq.material.GetColor("lColor"), pinkisColor, Time.deltaTime/9);
          flaskLiq.material.SetColor("lColor",c);
          Color b = Color.Lerp(flaskLiq.material.GetColor("fColor"), pinkisColorDark, Time.deltaTime/9);
          flaskLiq.material.SetColor("fColor",b);
        }
        
        if (shaderDown.material.GetFloat("FillArea")<= 0.318f)
        {
          the_end = true;
          is_buarette.Stop();
        }
    }
    if (!confirm)
    {
        transform.position = Vector3.MoveTowards(transform.position, getpos.position, Time.deltaTime * clickSpeed);
        is_buarette.Stop();
    }
  }
}