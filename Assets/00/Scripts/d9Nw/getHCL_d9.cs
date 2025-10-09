using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHCL_d9 : MonoBehaviour
{
    public bool hclFill;
    public bool HCLfull;
    [Space] 
    public pipet10MLliq pipetFillp;
    public float hclFillPoint;
    public float fillSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            hclFill = true;
        }
    }

    private void Update()
    {
        if (hclFill && !HCLfull)
        {
            if (pipetFillp.fillp < hclFillPoint)
            {
                pipetFillp.fillp += Time.deltaTime * fillSpeed;
            }

            else if (pipetFillp.fillp > hclFillPoint)
            {
                GetComponent<Collider>().enabled = false;
                Destroy(GetComponent<Rigidbody>());
                HCLfull = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            hclFill = false;
        }
    }
}
