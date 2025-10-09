using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
   private float olderEulerAngles;

   public Transform eulerObj;

   private float difference;
   private float oldDifference;

   public Rigidbody rb;
   private float counter;

   public galvanoRoter needleRotationScript;


   public generatorActivate red, blue;

   public ParticleSystem MagneticFieldParticleOne, MagneticFieldParticleTwo;
   void Start()
   {
       olderEulerAngles = eulerObj.eulerAngles.z;
       oldDifference = difference;
   }

   private void Update()
   {
       if (difference > oldDifference)
       {
           oldDifference = difference;
       }
       

       if (eulerObj.eulerAngles.z > olderEulerAngles)
       {
           counter += Time.deltaTime;
           Debug.Log(counter+"Rotating Right Side");
       }else if (eulerObj.eulerAngles.z < olderEulerAngles)
       {
           counter -= Time.deltaTime;
       }
       else
       {
           counter = 0;
       }

       if (counter > 3)
       {
           red.ActivateParticles();
           blue.ActivateParticles();
           MagneticFieldParticleOne.Play();
           needleRotationScript.rotateRightSide = true;
       }
       else
       {
           needleRotationScript.rotateRightSide = false;
           needleRotationScript.backToCenter = true;
           red.DisableBloods();
           blue.DisableBloods();
           MagneticFieldParticleOne.Stop();
       }

       if (counter < -3)
       {
           red.ActivateParticles();
           blue.ActivateParticles();
           MagneticFieldParticleTwo.Play();
           needleRotationScript.rotateLeftSide = true;
       }
       else
       {
           needleRotationScript.rotateLeftSide = false;
           needleRotationScript.backToCenter = true;
           MagneticFieldParticleTwo.Stop();
           red.DisableBloods();
           blue.DisableBloods();
       }
       //Debug.Log(oldDifference+ " Difference...");
       difference = olderEulerAngles - eulerObj.eulerAngles.z;
       olderEulerAngles = eulerObj.eulerAngles.z;
       //Debug.Log(rb.rotation);
   }
}
