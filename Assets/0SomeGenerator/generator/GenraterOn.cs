using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenraterOn : MonoBehaviour
{
    public GameObject Genrator;

    public bool isOn;
    public float speed = 0100f;

    public GameObject handle, backPipe;
    public GameObject actualObj;
    private bool callItOnce;

    private void Awake()
    {
        actualObj.SetActive(false);
    }

    void Update()
    {
        if(isOn)
        {
            //Genrator.transform.localEulerAngles = new Vector3(0, 0, Genrator.transform.localEulerAngles.z + Time.deltaTime * speed);
            //Debug.Log("Gene is On.......");

            if (!callItOnce)
            {
                Debug.Log("I am calling out");
                handle.SetActive(false);
                backPipe.SetActive(false);
                actualObj.SetActive(true);
                callItOnce = true;
            }
        }
    }
}
