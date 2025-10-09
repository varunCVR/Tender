using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEW_ON_OFF : MonoBehaviour
{
    /*
    public Transform target;
    public Transform ownpos;
    */
    public Vector3 on;
    public Vector3 off;
    
    public bool confirm;
    public FORSPIN spere;
    public AudioSource clickSoundEff;
    [Space] 
    public ParticleSystem psMGfield1;
    public ParticleSystem psMGfield2;
    public ParticleSystem psMGfield3;
    private void OnTriggerEnter(Collider other)
    {
        confirm = !confirm;
        clickSoundEff.Play();
    }
    
    private void Update()
    {
        if (confirm)
        {
            if (!spere.enabled)
            {
                psMGfield1.Play();
                psMGfield2.Play();
                psMGfield3.Play();
                transform.localEulerAngles = on;
                spere.enabled = true;
            }
        }
        else
        {
            if (spere.enabled)
            {
                psMGfield1.Stop();
                psMGfield2.Stop();
                psMGfield3.Stop();
                transform.localEulerAngles = off;
                spere.enabled = false;
            }
            
        }
        
    }
}
