 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_Onoof : MonoBehaviour
{
   
   public Transform downpos;
   public bool confirm;
   public float clickSpeed;
   public Transform getpos;

   private void OnTriggerEnter(Collider other)
   {
      confirm =! confirm;
   }
   private void Update()
   {
      if (confirm)
      {
         transform.localPosition = Vector3.MoveTowards(transform.localPosition,downpos.localPosition,Time.deltaTime * clickSpeed);
      }
      else
      {
         transform.localPosition = Vector3.MoveTowards(transform.localPosition,getpos.localPosition,Time.deltaTime * clickSpeed);
      }
   }
}
