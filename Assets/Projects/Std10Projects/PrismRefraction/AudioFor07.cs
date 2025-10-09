using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFor07 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip firstClip,secClip,thirdClip,fourthClip;

    private void Start()
    {
        StartCoroutine(PlayAudioInSequence());
    }
    IEnumerator PlayAudioInSequence()
    {
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(firstClip);
        yield return new WaitForSeconds(firstClip.length + 0.5f);
        audioSource.PlayOneShot(secClip);
        yield return new WaitForSeconds(secClip.length + 0.5f);
        audioSource.PlayOneShot(thirdClip);
        yield return new WaitForSeconds(thirdClip.length + 0.5f);        
        audioSource.PlayOneShot(fourthClip);
        yield return new WaitForSeconds(fourthClip.length + 0.5f);
    }
}
