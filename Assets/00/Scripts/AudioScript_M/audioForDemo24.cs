using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo24 : MonoBehaviour
{  
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    public float firstDelay;

    [Space] 
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;

    [Space] 
    public Rigidbody mas1;
    public Rigidbody mas2;
    public Rigidbody mas3;
    
    public weight_meter mass;

    public fonaltreeConnection lastAudio;

    private void Start()
    {
        StartCoroutine(audioDelay());
    }

    IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        stp1 = true;
        yield return new WaitForSeconds(clipAll[0].length + 1);
        stp2 = true;
    }
    
    private void Update()
    {
        if (!stp3) {
            if (stp1) {
                audioPlayer.PlayOneShot(clipAll[0]);
                stp1 = false;
            }

            if (stp2) {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[1]);
                stp2 = false;
            }
        }

        if (!stp3 && mas1.mass == 2 && mas2.mass == 2 && mas3.mass == 2)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[2]);
            stp3 = true;
        }

        if (!stp4 && mass.mas_1 && mass.mas_2 && mass.mas_3)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[3]);
            stp4 = true;
        }

        if (!stp5 && lastAudio.timeEnding)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[4]);
            stp5 = true;
        }
    }
}
