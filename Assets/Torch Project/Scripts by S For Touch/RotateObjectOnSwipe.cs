using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOnSwipe : MonoBehaviour
{
   private Touch touch;
   private Vector2 touchPosition;
   private Quaternion rotationY;

   public float rotateSpeedMult = 0.2f;


   private void Start()
   {
      
   }

   private void Update()
   {
      if (Input.touchCount > 0)
      {
         touch = Input.GetTouch(0);
         if (touch.phase == TouchPhase.Moved)
         {
            rotationY = Quaternion.Euler(0,-touch.deltaPosition.x*rotateSpeedMult,0);
            transform.rotation = rotationY * transform.rotation;
         }
      }
   }
}
