using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microscopeTrigger : MonoBehaviour
{
    public Transform slide2;
    public Transform slide2loc;

    public bool lastS;
    public GameObject display;

    public Renderer gl1;
    public Renderer gl2;
    public Material rootMat;
     private void OnTriggerEnter(Collider other)
     {
        if (other.CompareTag("Player2"))
        {
            lastS = true;
        }
     }

     private void Update()
     {
         if (lastS)
         {
             slide2.position = slide2loc.position;
             slide2.rotation = slide2loc.rotation;
         }

         if (lastS && !display.activeInHierarchy)
         {
             gl1.material = rootMat;
             gl2.material = rootMat;
             display.SetActive(true);
         }
     }
}
