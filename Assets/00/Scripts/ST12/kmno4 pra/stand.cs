using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stand : MonoBehaviour
{
    public GameObject flask;
    private bool enter;
    public float rotationSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            enter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            enter = false;
        } 
    }
    private void Update()
    {
        if (enter)
        {
           flask.transform.Rotate(0,1* Time.deltaTime * rotationSpeed,0); 
        }
    }
}
