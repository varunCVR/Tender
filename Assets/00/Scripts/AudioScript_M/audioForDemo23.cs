using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo23 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    public float firstDelay;

    [Space] public newTbmetr gb;


    private bool stp1;
    private bool stp2;
    private bool stp3;
    private void Start()
    {
        StartCoroutine(audioDelay());
    }

    IEnumerator audioDelay()
    {
        stp1 = true;
        yield return new WaitForSeconds(clipAll[0].length + 1);
        stp2 = true;
    }

    private void Update()
    {
        if (!stp3)
        {
            if (stp1)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[0]);
                stp1 = false;
            }

            if (stp2)
            { 
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[1]);
                stp2 = false;
            }
        }
     
        if (!stp3 && gb.lastB)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[2]);
            stp3 = true;
        }
    }
}
