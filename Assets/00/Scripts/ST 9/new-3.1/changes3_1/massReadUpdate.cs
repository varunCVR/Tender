using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class massReadUpdate : MonoBehaviour
{
   public bool enterBool;
   public changerWhite whiteSign;
   public TextMeshProUGUI textRead;
   [HideInInspector]
   public bool sign; 
   public bool sign1; 
   private void OnTriggerEnter(Collider other) 
   {
      if (other.CompareTag("Eve_1")) {
         enterBool = true;
         other.GetComponent<ReadAngleBetwenTwoObj>().enabled = false;
         sign = true;
         if (whiteSign.changed)
         {
            sign1 = true;
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Eve_1")) {
         enterBool = false;
      }
   }

   private void Update()
   {
      if (enterBool)
      {
         textRead.text = "165.4";
      }
      else
      {
         textRead.text = "00";
      }
   }
}
//165.4