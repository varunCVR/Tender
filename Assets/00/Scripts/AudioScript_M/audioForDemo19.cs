using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo19 : MonoBehaviour
{ public AudioSource audioPlayer;
    public AudioClip[] clipAll;
    public float firstDelay;
    void Start()
    {
        StartCoroutine(audioDelay());
    }

    IEnumerator audioDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(clipAll[0]);
        yield return new WaitForSeconds(clipAll[0].length + 1);
        
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(clipAll[1]);
    }
}   
