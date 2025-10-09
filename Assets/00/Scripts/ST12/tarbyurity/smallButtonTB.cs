using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallButtonTB : MonoBehaviour
{
    public bool clickSign;
    private bool reflactSign;
    public Transform clicked;
    [Space] public Transform targer;
    [Space] public AudioSource clickSound;
    private Vector3 postOrg;


    float sec;
    bool count;
    private void Start()
    {
        postOrg = transform.position;
    }
    
    private void OnTriggerEnter(Collider other)
    {
          clickSound.Play();
            clickSign = true;
            reflactSign = true;
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        reflactSign = false;
    }

    private void Update()
    {
   
        if (reflactSign)
        {
            if (targer.position != clicked.position)
            {
                targer.position = Vector3.MoveTowards(targer.position, clicked.position, Time.deltaTime * 3);
            }
        }
        else
        {
             if (targer.position != postOrg)
             {
                 targer.position = Vector3.MoveTowards(targer.position, postOrg, Time.deltaTime * 3);
             }
        }
    }
}
