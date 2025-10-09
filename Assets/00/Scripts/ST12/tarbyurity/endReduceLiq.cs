using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endReduceLiq : MonoBehaviour
{
    public Renderer waterRend;
    public ParticleSystem waterPS;
    public Renderer lastFillrd;
    public bool fillEnd;
    public float redSpeed;

    [Header("Activation Area")] 
    public GameObject fakeOne;
    public GameObject RightOne;

    public GameObject createdFillfake;
    public GameObject createdFillReal;

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player2")) {
            if (lastFillrd.material.GetFloat("_Fill") < 0.557 && waterRend.material.GetFloat("_Fill") > 0.5f)
            {
                if (waterPS.isStopped) {   
                    waterPS.Play();
                }

                float fill1 = lastFillrd.material.GetFloat("_Fill") + Time.deltaTime * redSpeed;
                lastFillrd.material.SetFloat("_Fill",fill1);

                float fill2 = waterRend.material.GetFloat("_Fill") - Time.deltaTime * redSpeed;
                waterRend.material.SetFloat("_Fill",fill2);
            }

            if (lastFillrd.material.GetFloat("_Fill") >= 0.557 && !fillEnd)
            {
                waterPS.Stop();
                fillEnd = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            waterPS.Stop();
        }
    }

    private void Update()
    {
        if (fillEnd && !createdFillReal.activeInHierarchy)
        {
            fakeOne.SetActive(false);
            RightOne.SetActive(true);
            createdFillfake.SetActive(false);
            createdFillReal.SetActive(true);
        }
    }
}
