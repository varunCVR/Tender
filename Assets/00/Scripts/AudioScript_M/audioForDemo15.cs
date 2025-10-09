using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo15 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;
    public float firstDelay;

    [Space] public mainTriggerEnter endingMilk;
    
    [Space]
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;
    void Start()
    {
        StartCoroutine(audioDelay());
    }

    IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        audioPlayer.PlayOneShot(clipAll[0]);
        
        yield return new WaitForSeconds(clipAll[0].length + 1);
        stp1 = true;

        yield return new WaitForSeconds(clipAll[1].length + 1);
        stp2 = true;
        
        yield return new WaitForSeconds(clipAll[2].length + 1);
        stp3 = true;
        
        yield return new WaitForSeconds(clipAll[3].length + 1);
        stp4 = true;
    }

    private void Update()
    {
        if (!stp5)
        {
            if (stp1)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[1]);
                stp1 = false;
            }

            if (stp2)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[2]);
                stp2 = false;
            }

            if (stp3)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[3]);
                stp3 = false;
            }

            if (stp4)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[4]);
                stp4 = false;
            }
        }

        if (!stp5 && endingMilk.ended )
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[5]);
            stp5 = true;
        }
    }
}
