using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take_phenolph : MonoBehaviour
{
   private bool trufalse;
   public GameObject in_pippet;
   public GameObject in_bikker;

   public bool dropFilled;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player")) {
         trufalse = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Player")) {
         trufalse = false;
      }
   }
   private void Update()
   {
      if (trufalse && !dropFilled)
      {
         if (in_pippet.transform.localScale.y <0.8367715f) {
            in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,in_pippet.transform.localScale.y + Time.deltaTime * 0.25f, in_pippet.transform.localScale.z);
            
            if (in_bikker.transform.localScale.y > 0.2631482f) {
               in_bikker.transform.localScale = new Vector3(in_bikker.transform.localScale.x,in_bikker.transform.localScale.y - Time.deltaTime * 0.04f ,in_bikker.transform.localScale.z);
            }
         }

         if (in_pippet.transform.localScale.y >= 0.8367715f) {
            dropFilled = true;
         }
      }
   }
}
