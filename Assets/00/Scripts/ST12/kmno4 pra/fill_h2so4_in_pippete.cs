using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_h2so4_in_pippete : MonoBehaviour
{
    private bool trufalse;
    public GameObject in_pippet;
    public GameObject in_bikker;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trufalse = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trufalse = false;
        }
    }
    private void Update()
    {
        if (trufalse)
        {
            if (in_bikker.transform.localScale.y >0.6200095f) {
                in_bikker.transform.localScale = new Vector3(in_bikker.transform.localScale.x,
                    in_bikker.transform.localScale.y - Time.deltaTime * 0.033f,
                    in_bikker.transform.localScale.z);
                
                if (in_pippet.transform.localScale.y <0.8367715f)
                {
                    in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,
                        in_pippet.transform.localScale.y + Time.deltaTime * 0.2f,
                        in_pippet.transform.localScale.z);
                }
            }
            
            
        }
    } 
}
