using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDemo11 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clipOne, clipTwo, clipThree, clipFour, clipFive;


    private void Start()
    {
        StartCoroutine(PlayInSequance());
    }

    IEnumerator PlayInSequance()
    {
        yield return new WaitForSeconds(1.5f);
        audioSource.PlayOneShot(clipOne);
        yield return new WaitForSeconds(clipOne.length+0.8f);
        audioSource.PlayOneShot(clipTwo);
        yield return new WaitForSeconds(clipTwo.length + 0.8f);
        audioSource.PlayOneShot(clipThree);
        yield return new WaitForSeconds(clipThree.length + 0.8f);
        audioSource.PlayOneShot(clipFour);
        yield return new WaitForSeconds(clipFour.length + 0.8f);
        audioSource.PlayOneShot(clipFive);
        yield return new WaitForSeconds(clipFive.length + 0.8f);
    }

}
