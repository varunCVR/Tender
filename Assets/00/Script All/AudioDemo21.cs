using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDemo21 : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip[] clips;


    private void Start()
    {
        StartCoroutine(PlayFirstAudio());
    }
    public void stopCoroutins()
    {
        StopAllCoroutines();
        audioSource.Stop();
    }

    IEnumerator PlayFirstAudio()
    {
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(3.5f);
        audioSource.PlayOneShot(clips[1]);
        yield return new WaitForSeconds(17.2f);
        audioSource.PlayOneShot(clips[2]);

    }
}
