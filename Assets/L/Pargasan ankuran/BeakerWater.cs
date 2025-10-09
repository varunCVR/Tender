using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerWater : MonoBehaviour
{
    public int counter;
    public bool waterIsReady;

    public AudioSource audioSource;
    public AudioClip clipFive;
    bool callItOnce;

    public AudioDemo22 audioScript;

    private void Update()
    {
        if(counter>= 4)
        {
            waterIsReady = true;
            if (!callItOnce)
            {
                StartCoroutine(PlayFifthClip());
                callItOnce = true;
            }
        }
    }

    IEnumerator PlayFifthClip()
    {
        audioScript.StopCoroutinExecution();
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(clipFive);
        yield return new WaitForSeconds(clipFive.length + 0.5f);
    }
}
