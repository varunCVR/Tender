using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSecondCuso : MonoBehaviour
{
    public SkinnedMeshRenderer blueMesh;
    public Transform bickerLiq;
    public bool cuso4;

    [Space] public float reduceSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S") && !cuso4)
        {
            blueMesh.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("S"))
        {
            if (blueMesh.GetBlendShapeWeight(0)>85)
            {
                float fillP = blueMesh.GetBlendShapeWeight(0) - Time.deltaTime * 15;
                
                Vector3 localScale = bickerLiq.transform.localScale;
                localScale = new Vector3(localScale.x, localScale.y-Time.deltaTime * reduceSpeed, localScale.z); 
                bickerLiq.transform.localScale = localScale;
                
                blueMesh.SetBlendShapeWeight(0,fillP);
                if (fillP <= 85) {
                    cuso4 = true;
                }
            }
        }
    }
}
