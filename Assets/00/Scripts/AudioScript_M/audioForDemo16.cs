using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo16 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    [Space] 
    public knifeCutED cutTg1;
    public knifeCutED cutTg2;
    public slidTrigger fullSlide;
    
    [Space] 
    public float firstDelay;
    // bool area....

    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;
    private bool stp7;
    private bool stp8;
    private bool stp9;
    private bool stp10;

    private void Start()
    {
        StartCoroutine(audioDelay());
    }

    IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(2);
        stp1 = true;
        yield return new WaitForSeconds(clipAll[0].length + 1);
        stp2 = true;
        yield return new WaitForSeconds(clipAll[1].length + 1);
        stp3 = true;
        yield return new WaitForSeconds(clipAll[2].length + 1);
        stp4 = true;
        yield return new WaitForSeconds(clipAll[3].length + 1);
        stp5 = true;
    }
    IEnumerator audioDelay6_9()
    {
        yield return new WaitForSeconds(clipAll[5].length + 1);
        stp7 = true;
        yield return new WaitForSeconds(clipAll[6].length + 1);
    
        stp9 = true;
    }


    private void Update()
    {
        // audio    0 to 4 || 1 to 5
        if (!stp6)
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

            if (stp3)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[2]);
                stp3 = false;
            }
            
            if (stp4)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[3]);
                stp4 = false;
            }
            
            if (stp5)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[4]);
                stp5 = false;
            }
        }

        // audio   5 to 8 || 6 to 9 
        if (!stp6 &&  (cutTg1.cuted||cutTg2.cuted))
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[5]);
            StartCoroutine(audioDelay6_9());
            stp6 = true;
        }

        if (!stp10)
        {
            if (stp7)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[6]);
                stp7 = false;
            }

            if (stp9)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[8]);
                stp9 = false;
            }
        }

        if (!stp10 && fullSlide.sC)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[9]);
            stp10 = true;
        }
    }
}
