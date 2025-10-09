using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillTrigger : MonoBehaviour
{
    private bool entr;
    public int fillpoint;

    private int fli;
    public LiqfillEffect loater;
    public float fillSped;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            entr = true;
        }
    }

    private void Update()
    {
        if (entr)
        {
            if (loater.fillFloat_250ml < fillpoint)
            {
               
                loater.fillFloat_250ml += Time.deltaTime * fillSped ;
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            entr = false;
        }
    }
}
