using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSalt_st9 : MonoBehaviour
{
    public enter_wtr waterEff;
    public for_saltwtr saltEff;
    public getSlat_st9 slatBool;
    public ParticleSystem saltyPs;
    public GameObject saltDispar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && slatBool.salty)
        {
            slatBool.salty = false;
            saltyPs.Play();
            saltDispar.SetActive(false);
            waterEff.enabled = false;
            saltEff.enabled = true;
        }
    }
}
    