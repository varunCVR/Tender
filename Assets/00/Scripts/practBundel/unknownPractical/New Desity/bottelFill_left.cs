using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottelFill_left : MonoBehaviour
{
    public fillResetDS rightBicker;
    public bool Kenter;
    public bool Xenter;
    public ParticleSystem bottleWater;
    public ParticleSystem bottleWaterX;

    [Header("Deactivate")] 
    public DEST_waterScript waveEff;
    
    [Space]
    public GameObject rightFirst;
    public GameObject rightSec;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("K"))
        {
            waveEff.gameObject.SetActive(false);        
            Kenter = true;
        }
        if (other.CompareTag("X"))
        {
            waveEff.gameObject.SetActive(false);
            Xenter = true;
        }
    }

    private void Update()
    {
        if (Kenter)
        {
            if (rightBicker.fillPoint < 0.15f)
            {
                if (bottleWater.isStopped)
                {
                    bottleWater.Play();
                }
                rightBicker.fillPoint += Time.deltaTime * 0.01f;
            }

            if (rightBicker.fillPoint >= 0.15f)
            {
                bottleWater.Stop();
                rightFirst.SetActive(false);
                rightSec.SetActive(true);
                gameObject.SetActive(false);
            }
        }
        if (Xenter)
        {
            if (rightBicker.fillPoint < 0.15f)
            {
                if (bottleWaterX.isStopped)
                {
                    bottleWaterX.Play();
                }
                rightBicker.fillPoint += Time.deltaTime * 0.02f;
            }

            if (rightBicker.fillPoint > 0.15f)
            {
                bottleWaterX.Stop();
                rightFirst.SetActive(false);
                rightSec.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("K"))
        {
            bottleWater.Stop();
            Kenter = false;
        }
        if (other.CompareTag("X"))
        {
            bottleWaterX.Stop();
            Xenter = false;
        }
    }
}
