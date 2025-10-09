using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using TMPro;
using UnityEngine;

public class newTbmetr : MonoBehaviour
{
    public bool w;
    public bool s;
    public bool c;

    [Header("Collider")]
    public Collider setZeroButton;
    public Collider calibButton;

    [Header("caseObj")] 
    public onoffSwitchCas caseC;

    [Header("Script")]
    public smallButtonTB setZeroSign;
    public smallButtonTB calibSign;

    [Header("Grabber")] 
    public Grabbable slatGrab;
    public Grabbable unknownGrab;
    
    [Space] public TextMeshProUGUI TextReader;

    [HideInInspector] public bool lastB;


    [Space] public int i;

    public bool fst1;
    public bool sec1;
    public bool ukn1;
    
    public bool fst2;
    public bool sec2;
    public bool ukn2;
    
    public bool fst3;
    public bool sec3;
    public bool ukn3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !s && !c)
        {
            w = true;
        }
        if (other.CompareTag("Salt") && !w && !c)
        {
            s = true;
        }
        if (other.CompareTag("Coconut") && !s && !w)
        {
            lastB = true;
            c = true;
        }
    }  
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            w = false;
        }
        if (other.CompareTag("Salt"))
        {
            s = false;
        }
        if (other.CompareTag("Coconut"))
        {
            c = false;
        }
    }

    private void Update()
    {
        if (w && caseC.cCondition && !setZeroButton.enabled)
        {
            setZeroButton.enabled = true;
        }

        if (w && caseC.cCondition && setZeroSign.clickSign && !unknownGrab.enabled)
        {
            slatGrab.enabled = true;
        }

        if (s && caseC.cCondition && !calibButton.enabled)
        {
            calibButton.enabled = true;
        }

        if (s && caseC.cCondition && calibSign.clickSign && !unknownGrab.enabled)
        {
            unknownGrab.enabled = true;
        }
        readerUpdate();
    }


    public void readerUpdate()
    {
        if (w && setZeroSign.clickSign)
        {
            if (i==0) {
                i = 1;
            }
            TextReader.text = "00.00";
        }

        if (s && !setZeroSign.clickSign)
        {
            TextReader.text = "29.37";
        }

        if (c && !setZeroSign.clickSign)
        {
            TextReader.text = "25.40";
        }
        
        if (w && !setZeroSign.clickSign) {
            TextReader.text = "05.30";
        }
        
        
        
        if (s && calibSign.clickSign && setZeroSign.clickSign) {
            if (i==1) {
                i = 2;
            }
            TextReader.text = "40.00";
        }
        if (s && !calibSign.clickSign && setZeroSign.clickSign) {
            TextReader.text = "35.00";
        }

        if (c && !calibSign.clickSign && setZeroSign.clickSign)
        {
            TextReader.text = "26.25";
        }
        
        if (c && calibSign.clicked && setZeroSign.clickSign) {
            TextReader.text = "27.00";
        }

        
        
        
        
        
        
        if (!w && !s && !c)
        {
            TextReader.text = "--";
        }
    }
}
