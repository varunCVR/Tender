using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_phinolphtheline_in_pippet : MonoBehaviour
{
    private bool trufalse;
    public GameObject in_pippet;
    public GameObject in_bikker;

    public fill_hcl_in_pippet pp;

    public bool finolfEnd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pp.happyEnding)
        {
            trufalse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && pp.happyEnding)
        {
            trufalse = false;
        }
    }
    private void Update()
    {
        if (trufalse && !finolfEnd)
        {
            if (in_bikker.transform.localScale.y > 0.3200095f) {
                in_bikker.transform.localScale = new Vector3(in_bikker.transform.localScale.x,
                    in_bikker.transform.localScale.y - Time.deltaTime * 0.033f,
                    in_bikker.transform.localScale.z);
                
                if (in_pippet.transform.localScale.y < 0.4367715f)
                {
                    in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,
                        in_pippet.transform.localScale.y + Time.deltaTime * 0.2f,
                        in_pippet.transform.localScale.z);
                } if (in_pippet.transform.localScale.y >= 0.4367715f)
                {
                    finolfEnd = true;
                }
            }
        }
    }
}
