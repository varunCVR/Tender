using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltExit : MonoBehaviour
{
    public GameObject saltObj;
    public slatEnt boolS;
    public ParticleSystem psBrust;
    [HideInInspector] public bool slatyAll;
    
    
    [Space]
    public bottelFill_right rightFill;

    [Header("scriptSwiper")]
    public GameObject tgTrigw;
    public GameObject tgTrigs;
    
 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("iceall") && boolS.salty)
        {
            /*slatyAll = true;
            boolS.salty = false;
            saltObj.SetActive(false);
            psBrust.Play();*/
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("iceall") && boolS.salty)
        {
            if (other.transform.eulerAngles.x >=340)
            {
                slatyAll = true;
                boolS.salty = false;
                saltObj.SetActive(false);
                psBrust.Play();
            }
        }
    }

    private void Update()
    {
        if (slatyAll && !rightFill.enabled)
        {
            tgTrigw.GetComponent<enter_wtr>().onoff = false;
            tgTrigw.SetActive(false);
            tgTrigs.SetActive(true);
            
            
            rightFill.enabled = true;
        }
    }
}
