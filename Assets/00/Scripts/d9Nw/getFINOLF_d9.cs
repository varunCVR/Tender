using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFINOLF_d9 : MonoBehaviour
{
    public bool finolfFill;
    public bool finolf_full;
    [Space] 
    public pipet10MLliq pipetFillp;
    public float finolfFillPoint;
    public float fillSpeed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            finolfFill = true;
        }
    }

    private void Update()
    {
        if (finolfFill && !finolf_full)
        {
            if (pipetFillp.fillp < finolfFillPoint)
            {
                pipetFillp.fillp += Time.deltaTime * fillSpeed;
            }

            else if (pipetFillp.fillp > finolfFillPoint)
            {
                GetComponent<Collider>().enabled = false;
                Destroy(GetComponent<Rigidbody>());
                finolf_full = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            finolfFill = false;
        }
    }
}
