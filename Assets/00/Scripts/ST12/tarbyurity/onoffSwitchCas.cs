using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoffSwitchCas : MonoBehaviour
{
    [Header("switch")]
    public GameObject transOn;
    public GameObject transOff;
    [Space]
    public bool sCondition; 

    [Header("Case")] 
    public Transform caseopen;
    public Transform caseclose;
    public Transform caseTrans;
    [Space] 
    public bool cCondition;
    [Space] public AudioSource clickSound; 

    private void OnTriggerEnter(Collider other)
    {
        clickSound.Play();
        sCondition = !sCondition;
    }

    private void Update()
    {
        if (sCondition)
        {
            if (transOff.activeInHierarchy)
            {
                transOn.SetActive(true);
                transOff.SetActive(false); 
            }
            caseTrans.rotation = Quaternion.Lerp(caseTrans.rotation, caseopen.rotation,Time.deltaTime * 10);
        }
        else
        {
            if (!transOff.activeInHierarchy)
            {
                transOn.SetActive(false);
                transOff.SetActive(true);
            }
            caseTrans.rotation = Quaternion.Lerp(caseTrans.rotation, caseclose.rotation, Time.deltaTime * 10);
        }

        if (caseTrans.rotation == caseopen.rotation)
        {
            cCondition = true;
        }

        if (caseTrans.rotation == caseclose.rotation)
        {
            cCondition = false; 
        }
    }
    
}
