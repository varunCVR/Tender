using System;
using BNG;
using TMPro;
using UnityEngine;
public class endResults : MonoBehaviour
{
    public onoffSwitchCas caseCondition;

    public Transform positionFix;
    private bool occupied;
    private Transform colObj;
    
    [Header("EnterExit trigger")] 
    public bool _enterWater;
    public bool _enterSail;
    public bool _enterUnknown;
    
    [Header("SmallButtons")] 
    public GameObject left_button;
    public GameObject right_button;
    
    [Header("reset Bools")] 
    public bool water_0;
    public bool soil_0;

    [Header("grabbing Obj")] 
    public Grabbable soil_grab;
    public Grabbable unknown_grab;

    [Header("Text Area")] 
    public TextMeshProUGUI _textReader;

    public int steps;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !occupied)
        {
            colObj = other.gameObject.transform;
            occupied = true;
            _enterWater = true;

            left_button.GetComponent<Collider>().enabled = true;
        }
        if (other.CompareTag("Salt") && !occupied)
        {
            colObj = other.gameObject.transform;
            occupied = true;
            _enterSail = true;

            right_button.GetComponent<Collider>().enabled = true;
        }
        if (other.CompareTag("Coconut") && !occupied)
        {
            colObj = other.gameObject.transform;
            occupied = true;
            _enterUnknown = true;
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water") && occupied)
        {
            occupied = false;
            _enterWater = false;
        }

        if (other.CompareTag("Salt") && occupied)
        {
            occupied = false;
            _enterSail = false;
        }

        if (other.CompareTag("Coconut") && occupied)
        {
            occupied = false;
            _enterUnknown = false;
        }
    }

    private void Update()
    {
       enableGrabble();
       
       if (_enterWater && left_button.GetComponent<smallButtonTB>().clickSign && !caseCondition.cCondition && steps == 0)
       {
           steps = 1;
       }
       if (_enterSail && right_button.GetComponent<smallButtonTB>().clickSign && !caseCondition.cCondition && steps == 1)
       {
           steps = 2;
       }
       readerUpdate();
    }

    private void readerUpdate()
    {
        if (steps == 0)
        {
            if (_enterWater)
            {
                _textReader.text = "05.3" ;
            }
            else
            {
                _textReader.text = "---" ;

            }
        }
        if (steps == 1)
        {
            if (_enterWater)
            {
                _textReader.text = "0.00";
            }

            if (_enterSail)
            {
                _textReader.text = "034";
            }
            else
            {
                _textReader.text = "---" ;
            }
        }
        if (steps ==2)
        {
            if (_enterWater)
            {
                _textReader.text = "0.00";
            }
            if (_enterSail)
            {
                _textReader.text = "040";
            }
            if (_enterUnknown)
            {
                _textReader.text = "062";
            }
            else
            {
                _textReader.text = "---" ;
            }
        }
    }

    private void enableGrabble()
    {
        if (steps==1 && !occupied) {
            soil_grab.enabled = true;
        }

        if (steps==2 && !occupied) {
            unknown_grab.enabled = true;
        }
    }


    /*
    public onoffSwitchCas mainSignal;

    // justEnterance
    public bool waterEnterd;
    public bool clEnterd;
    public bool unknownCoco;
    
    [Header("Reset Signal")]
    public bool water_0;      
    public bool salty_0;      
    public bool unknown_0;      

    [Header("ButtonArea")]
    public smallButtonTB buttonLeft;
    public smallButtonTB buttonRight;

    [Header("Text Area")] 
    public TextMeshProUGUI ReaderText;

    private int steps;*/
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water"))
        {
            waterEnterd = true;
            buttonLeft.enabled = true;
        }

        if (other.CompareTag("Salt"))
        {
            clEnterd = true;
            buttonRight.enabled = true;

        }
        if (other.CompareTag("Coconut"))
        {
            unknownCoco = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water")) {
            waterEnterd = false;
        }
        if (other.CompareTag("water")&& water_0) {
            slaty.enabled = true;
        }
        
        if (other.CompareTag("Salt")) {
            clEnterd = false;
        }
        if (other.CompareTag("Salt") && salty_0) {
            unknownGrabber.enabled = true;
        }
        
        if (other.CompareTag("Coconut")) {
            unknownCoco = true;
        } 
    }

    [Header("Grabble")]
    public Grabbable slaty;
    public Grabbable unknownGrabber;
    */
    /*private void readerObj()
    {
        if (steps == 0)
        {
            if (waterEnterd) {
                ReaderText.text = "05.3";
            }
            else { 
                ReaderText.text = "-0.00";
            }
        }
        else if (steps == 1)
        {
            if (waterEnterd) {
                ReaderText.text = "0.00";
            }
            else if (clEnterd) {
                ReaderText.text = "034";
            }
            else {
                ReaderText.text = "371";
            }
        }
        else if (steps == 2)
        {
            if (waterEnterd) {
                ReaderText.text = "0.00";
            }
            if (clEnterd) {
                ReaderText.text = "040";
            }
            if (unknownCoco) {
                ReaderText.text = "27.0";
            }
            else {
                ReaderText.text = "0.00";
            }
        }
    }*/
}
