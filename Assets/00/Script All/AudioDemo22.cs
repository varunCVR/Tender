using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDemo22 : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clipOne, clipTwo, clipThree,clipFourth;

    private void Start()
    {
        StartCoroutine(PlayStartAudios());
    }

    public void StopCoroutinExecution()
    {
        StopCoroutine(PlayStartAudios());
        audioSource.Stop();
    }

    IEnumerator PlayStartAudios()
    {
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(clipOne);
        yield return new WaitForSeconds(3.7f);
        audioSource.PlayOneShot(clipTwo);
        yield return new WaitForSeconds(clipTwo.length+0.5f);
        audioSource.PlayOneShot(clipThree);
        yield return new WaitForSeconds(clipThree.length + 0.5f);
        audioSource.PlayOneShot(clipFourth);
        yield return new WaitForSeconds(clipFourth.length + 0.5f);

    }
}
