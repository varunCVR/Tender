using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AduioDemo7 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipOne, clipTwo, clipThree, clipFour;

    private void Start()
    {
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(1.5f);

        audioSource.PlayOneShot(clipOne);
        yield return new WaitForSeconds(clipOne.length + 0.5f);

        audioSource.PlayOneShot(clipTwo);
        yield return new WaitForSeconds(clipTwo.length + 0.5f);

        audioSource.PlayOneShot(clipThree);
        yield return new WaitForSeconds(clipThree.length + 0.5f);

        audioSource.PlayOneShot(clipFour);
        yield return new WaitForSeconds(clipFour.length + 0.5f);
    }
}
