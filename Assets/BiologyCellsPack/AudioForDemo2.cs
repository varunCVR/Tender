using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForDemo2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipOne,clipTwo,clipThree,clipFour,clipFive,clipSix,clipSeven,clipEight;

    public void PlayAudioInSequence()
    {
        StartCoroutine(PlayAudio());
    }
    public void StopAudios()
    {
        StopAllCoroutines();
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clipOne);
        yield return new WaitForSeconds(clipOne.length + 0.5f);

        audioSource.PlayOneShot(clipTwo);
        yield return new WaitForSeconds(clipTwo.length + 0.5f);

        audioSource.PlayOneShot(clipThree);
        yield return new WaitForSeconds(clipThree.length + 0.5f);

        audioSource.PlayOneShot(clipFour);
        yield return new WaitForSeconds(clipFour.length + 0.5f);

        audioSource.PlayOneShot(clipFive);
        yield return new WaitForSeconds(clipFive.length + 0.5f);

        audioSource.PlayOneShot(clipSix);
        yield return new WaitForSeconds(clipSix.length + 0.5f);

        audioSource.PlayOneShot(clipSeven);
        yield return new WaitForSeconds(clipSeven.length + 0.5f);

        audioSource.PlayOneShot(clipEight);
        yield return new WaitForSeconds(clipEight.length + 0.5f);
    }
}
