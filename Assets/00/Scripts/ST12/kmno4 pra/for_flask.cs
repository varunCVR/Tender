using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_flask : MonoBehaviour
{
    private bool final;
    public GameObject in_pippet;
    public ParticleSystem is_pippet;

    [Space, HideInInspector] 
    public bool fistOut;
    public fill_h2so4_in_pippete getFill1;

    [Space] 
    public GameObject Real;
    public GameObject fake;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            final = true;
            is_pippet.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            final = false;
            is_pippet.Stop();
        }
    }
    private void Update()
    {
        if (final)
        {
            if (in_pippet.transform.localScale.y > 0)
            {
                in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,
                    in_pippet.transform.localScale.y - Time.deltaTime * 0.5f,
                    in_pippet.transform.localScale.z);
            }
            else
            {
                is_pippet.Stop();
                if (!fistOut && getFill1)
                {
                    Real.SetActive(true);
                    fake.SetActive(false);
                    fistOut = true;
                }
            }
        }
    }
}
