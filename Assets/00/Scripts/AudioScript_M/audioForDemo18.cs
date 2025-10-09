using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo18 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    [Space] 
    public for_testtube tueBool;
    
    [Space] 
    public float firstDelay;
    // bool area....

    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;

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
    }

    private void Update()
    {
        if (!stp4)
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
        }

        if (!stp4 && tueBool.endBool)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[3]);
            stp4 = true;
        }
    }
}

