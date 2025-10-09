using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class for_making_Y : MonoBehaviour
{
    [Header("Main Liquid")] 
    public Renderer mainYLiq;
    
    [Header("water2")] 
    public Renderer liq_water2;
    public ParticleSystem ps_water2;
    [HideInInspector]public bool wb2;

    [Header("water3")] 
    public Renderer liq_water3;
    public ParticleSystem ps_water3;
    [HideInInspector]public bool wb3;

    [Header("water4")]
    public Renderer liq_water4;
    public ParticleSystem ps_water4;
    [HideInInspector]public bool wb4;

    [Header("Speed")] public float reduceSpeed;
    public float increaseSpeed;

    [Header("ending")] 
    public GameObject RealYglass;
    public GameObject fakeYglass;


    [Space]
    public AudioSource player;
    private int i;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn2"))
        {
            if (liq_water2.material.GetFloat("_Fill") > 0.5069f)
            {
                if (i != 1)
                {
                    player.PlayOneShot(player.clip);
                    i = 1;
                }
                if (ps_water2.isStopped)
                {
                    ps_water2.Play();
                }
                float fillP = liq_water2.material.GetFloat("_Fill") - Time.deltaTime  * reduceSpeed;
                liq_water2.material.SetFloat("_Fill",fillP);

                if (mainYLiq.material.GetFloat("_Fill") < 0.5599f)
                {
                    float fillM = mainYLiq.material.GetFloat("_Fill") + Time.deltaTime * increaseSpeed;
                    mainYLiq.material.SetFloat("_Fill",fillM);
                }
            }
            
            else if(liq_water2.material.GetFloat("_Fill") <= 0.5069f)
            {
                wb2 = true;
                if (ps_water2.isPlaying) {
                    player.Stop();
                    ps_water2.Stop();
                }
            }
        }
        if (other.CompareTag("Respawn3"))
        {

            if (liq_water3.material.GetFloat("_Fill") > 0.5069f)
            {
                if (i != 1)
                {
                    player.PlayOneShot(player.clip);
                    i = 1;
                }
                if (ps_water3.isStopped)
                {
                    ps_water3.Play();
                }
                float fillP = liq_water3.material.GetFloat("_Fill") - Time.deltaTime  * reduceSpeed;
                liq_water3.material.SetFloat("_Fill",fillP);

                if (mainYLiq.material.GetFloat("_Fill") < 0.5599f)
                {
                    float fillM = mainYLiq.material.GetFloat("_Fill") + Time.deltaTime * increaseSpeed;
                    mainYLiq.material.SetFloat("_Fill",fillM);
                }
            }
            
            else if(liq_water3.material.GetFloat("_Fill") <= 0.5069f)
            {
                wb3 = true;
                if (ps_water3.isPlaying) {
                    player.Stop();
                    ps_water3.Stop();
                }
            }
        }
        if (other.CompareTag("Respawn4"))
        {
            if (liq_water4.material.GetFloat("_Fill") > 0.5069f)
            {
                if (i != 1)
                {
                    player.PlayOneShot(player.clip);
                    i = 1;
                }
                if (ps_water4.isStopped)
                {
                    ps_water4.Play();
                }
                float fillP = liq_water4.material.GetFloat("_Fill") - Time.deltaTime  * reduceSpeed;
                liq_water4.material.SetFloat("_Fill",fillP);

                if (mainYLiq.material.GetFloat("_Fill") < 0.5599f)
                {
                    float fillM = mainYLiq.material.GetFloat("_Fill") + Time.deltaTime * increaseSpeed;
                    mainYLiq.material.SetFloat("_Fill",fillM);
                }
            }
            
            else if(liq_water4.material.GetFloat("_Fill") <= 0.5069f)
            {
                wb4 = true;

                if (ps_water4.isPlaying) {
                    player.Stop();
                    ps_water4.Stop();
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn2"))
        {
            if (i != 0)
            {
                player.Stop();
                i = 0;
            }
            ps_water2.Stop();
        }
        if (other.CompareTag("Respawn3"))
        {
            if (i != 0)
            {
                player.Stop();
                i = 0;
            }
            ps_water3.Stop();
        }
        if (other.CompareTag("Respawn4"))
        {
            if (i != 0)
            {
                player.Stop();
                i = 0;
            }
            ps_water4.Stop();
        }
    }

    private void Update()
    {
        if (wb2 && wb3 && wb4 && fakeYglass.activeInHierarchy)
        {
            RealYglass.SetActive(true);
            fakeYglass.SetActive(false);
            GetComponent<for_making_Y>().enabled = false;
        }
    }
}
