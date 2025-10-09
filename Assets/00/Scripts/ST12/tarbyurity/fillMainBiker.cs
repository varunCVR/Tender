using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class fillMainBiker : MonoBehaviour
{
    [Header("Conformation")]
    public poreLiqHex hexConf;
    public poreLiqHyd hydConf;
    [Space]
    public GameObject mainLiq;
    public float reduceSpeed;
    public float increaseSped;
    [Header("Hex Area")] public Renderer hexLiq;
    public ParticleSystem psHex;

    [Header("hyd Area")] public Renderer hydLiq;
    public ParticleSystem psHyd;

    
    [HideInInspector]public bool hydred, hexted;
    public Grabbable waterGrb;

    [Header("to add 90_ml Water")] 
    public Renderer waterLiq;
    public ParticleSystem waterPs;
    public bool waterED;
    [Header("Ender")] public Grabbable lastPipet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water2") || other.CompareTag("water3") && !mainLiq.activeInHierarchy)
        {
            mainLiq.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("water2") && hexConf.hexPored) 
        {
            if (hydLiq.material.GetFloat("_Fill") > 0.5f) 
            {
                if (psHyd.isStopped)
                {
                    psHyd.Play();
                }
                float fill = hydLiq.material.GetFloat("_Fill") - Time.deltaTime * reduceSpeed;
                hydLiq.material.SetFloat("_Fill",fill);

                Vector3 localScale = mainLiq.transform.localScale;
                localScale = new Vector3(localScale.x,
                    localScale.y + Time.deltaTime * increaseSped, localScale.z);
                mainLiq.transform.localScale = localScale;
            }
            else if( hydLiq.material.GetFloat("_Fill") <= 0.5f) 
            {
                if (psHyd.isPlaying)
                {
                    hydred = true;
                    psHyd.Stop();
                }
            }
        }

        if (other.CompareTag("water3") && hydConf.hydPored)
        {
            if (hexLiq.material.GetFloat("_Fill") > 0.5f)
            {
                if (psHex.isStopped)
                {
                    psHex.Play();
                }
                float fill = hexLiq.material.GetFloat("_Fill") - Time.deltaTime * reduceSpeed;
                hexLiq.material.SetFloat("_Fill",fill);
                
                Vector3 localScale = mainLiq.transform.localScale;
                localScale = new Vector3(localScale.x,
                    localScale.y + Time.deltaTime * increaseSped, localScale.z);
                mainLiq.transform.localScale = localScale;
            }
            else if( hexLiq.material.GetFloat("_Fill") <= 0.5f) 
            {
                if (psHex.isPlaying)
                {
                    hexted = true;
                    psHex.Stop();
                }
            }
        }

        if (other.CompareTag("water4"))
        {
            if (waterLiq.material.GetFloat("_Fill") > 0.5f)
            {
                if (waterPs.isStopped)
                {
                    waterPs.Play();
                }
                float fill = waterLiq.material.GetFloat("_Fill") - Time.deltaTime * reduceSpeed / 2;
                waterLiq.material.SetFloat("_Fill",fill);

                if (mainLiq.transform.localScale.y < 0.12f) {
                    
                    mainLiq.transform.localScale = new Vector3(mainLiq.transform.localScale.x,
                        mainLiq.transform.localScale.y + Time.deltaTime * reduceSpeed, mainLiq.transform.localScale.z);
                }
            }
            else if (waterLiq.material.GetFloat("_Fill") <= 0.5f)
            {
                if (waterPs.isPlaying)
                {
                    waterED = true;
                    waterPs.Stop();
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water2"))
        {
            psHyd.Stop();
        }

        if (other.CompareTag("water3"))
        {
            psHex.Stop();
        }
    }


    private void Update()
    {
        if (hydred && hexted && !waterGrb.enabled)
        {
            waterGrb.enabled = true;
        }

        if (waterED && !lastPipet.enabled)
        {
            lastPipet.enabled = true;
        }
    }
}
