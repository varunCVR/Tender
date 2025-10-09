using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIRSTlIQtRIGGER : MonoBehaviour
{
    public bool pipetEnter;
    public bool naoh;

    [Space]
    public SkinnedMeshRenderer fillArea;
    public Transform bickerLiq;
    public float fillP=100;
    public float reduceSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S") && !naoh)
        {
            pipetEnter = true;
            fillArea.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (pipetEnter && !naoh)
        {
            if (fillP > 75) {
                fillP -= Time.deltaTime * 10;
                Vector3 localScale = bickerLiq.transform.localScale;
                localScale = new Vector3(localScale.x,
                    localScale.y-Time.deltaTime * reduceSpeed, localScale.z);
                bickerLiq.transform.localScale = localScale;
            }
            
            if (fillP <= 75) {
                naoh = true;
            }
            fillArea.SetBlendShapeWeight(0,fillP);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("S"))
        {
            pipetEnter = false;
        }
    }
}
