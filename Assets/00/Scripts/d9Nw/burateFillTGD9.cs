using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burateFillTGD9 : MonoBehaviour
{
    public burate25MLFill burate_Fill;
    public float fillPoint;
    public LiqfillEffect bicker_Fill;
    [Space] public float increaseSped;
    [Space] 
    public ParticleSystem bickerPS;
    public ParticleSystem burateInnerPS;
    public bool fillStart;

    [Space] 
    public fillerBoxTriggerD9 grabPoint;

    [Space] [HideInInspector] public bool burateFull;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("glass")) {
            fillStart = true;
        }
    }

    private void Update()
    {
        if (fillStart && !burateFull)
        {
            if (bicker_Fill.fillFloat_250ml > 200) {
                bicker_Fill.fillFloat_250ml -= Time.deltaTime * increaseSped;
            }
            if (burate_Fill.bFill > fillPoint) {
                if (!bickerPS.isPlaying) {
                    bickerPS.Play();   
                }
                if (!burateInnerPS.isPlaying) {
                    burateInnerPS.Play();
                }

                burate_Fill.updateMethod = true;
                burate_Fill.bFill -= Time.deltaTime * increaseSped;
            }
            
            else if (burate_Fill.bFill < fillPoint) {
                
                if (!bickerPS.isStopped) {
                    bickerPS.Stop();   
                }
                if (!burateInnerPS.isStopped) {
                    burateInnerPS.Stop();
                }

                grabPoint.fillerGrabble.enabled= true;
                burateFull = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("glass")) {
            fillStart = false;
            bickerPS.Stop();
            burateInnerPS.Stop();
        }
    }
}
