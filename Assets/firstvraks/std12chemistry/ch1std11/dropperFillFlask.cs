using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropperFillFlask : MonoBehaviour
{
   public Renderer flaskRend;
   public take_phenolph dropperObj;

   public bool falskEnding;
   private void OnTriggerStay(Collider other)
   {
      if (other.CompareTag("Player") && dropperObj.dropFilled)
      {
         if (flaskRend.material.GetFloat("FillArea") < -0.02f)
         {
            float fill = flaskRend.material.GetFloat("FillArea") + Time.deltaTime * 0.005f;
            flaskRend.material.SetFloat("FillArea",fill);
            
            if (in_pippet.transform.localScale.y > 0) {
               in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,in_pippet.transform.localScale.y - Time.deltaTime * 0.28f
                  ,in_pippet.transform.localScale.z);
            }
            else {
               is_pippet.Stop();
            }
         }

         if (flaskRend.material.GetFloat("FillArea")>=-0.02f && !falskEnding)
         {
            falskEnding = true;
         }
      }
   }

   private bool final;
   public GameObject in_pippet;
   public ParticleSystem is_pippet;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player")) {
         final = true;
         is_pippet.Play();
      }
   }
   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Player")) {
         final = false;
         is_pippet.Stop();
      }
   }
}