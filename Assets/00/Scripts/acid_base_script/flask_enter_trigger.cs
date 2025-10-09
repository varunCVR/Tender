using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flask_enter_trigger : MonoBehaviour
{
    private bool finalH2so4;
    public bool h2so4;
    public GameObject in_pippet;
    public ParticleSystem is_pippet;

    [Space, HideInInspector] 
    public bool fistOut;
    public fill_h2so4_in_pippete getFill1;

    [Space] 
    public GameObject Real;
    public GameObject fake;


    [Space]
    public fill_phinolphtheline_in_pippet phinolf;
    public bool finol;
    public bool last;

    [Space] public Renderer rend;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !h2so4)
        {
            finalH2so4 = true;
            is_pippet.Play();
        }
        if (other.CompareTag("Player") && phinolf.finolfEnd)
        {
            finol = true;
            is_pippet.Play();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !h2so4)
        {
            finalH2so4 = false;
            is_pippet.Stop();
        }
        if (other.CompareTag("Player") && phinolf.finolfEnd)
        {
            finol = false;
            is_pippet.Stop();
        }
    }
    private void Update()
    {
        if (finalH2so4 && !h2so4)
        {
            if (in_pippet.transform.localScale.y > 0)
            {
                in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,
                    in_pippet.transform.localScale.y - Time.deltaTime * 0.5f,
                    in_pippet.transform.localScale.z);
                if (rend.material.GetFloat("FillArea") < -0.015f)
                {
                    float fill = rend.material.GetFloat("FillArea") + Time.deltaTime * 0.01f;
                    rend.material.SetFloat("FillArea",fill);
                }
            }

            if (in_pippet.transform.localScale.y <= 0 && !h2so4)
            {
                is_pippet.Stop();
                h2so4 = true;
                finalH2so4 = false;
            }
        }

        if (finol && !last)
        {
            if (in_pippet.transform.localScale.y > 0)
            {
                in_pippet.transform.localScale = new Vector3(in_pippet.transform.localScale.x,
                    in_pippet.transform.localScale.y - Time.deltaTime * 0.5f,
                    in_pippet.transform.localScale.z);
                if (rend.material.GetFloat("FillArea") < -0.02f)
                {
                    float fill = rend.material.GetFloat("FillArea") + Time.deltaTime * 0.01f;
                    rend.material.SetFloat("FillArea",fill);
                }
            }
            if (in_pippet.transform.localScale.y <=0)
            {
                is_pippet.Stop();
                    Real.SetActive(true);
                    fake.SetActive(false);
                    last = true;
            }
        }
    }
}
