using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class UrineAudio : MonoBehaviour
{
    [Header("Script Access")]
    public kasnali15MLliq ac;
    public CheckS ac2;

    public GameObject TestTubeTrigger;

    [Header("Audio Services")][Space]
    public AudioSource audioSource;
    public AudioClip[] clip;

    bool ist1, ist2;

    bool isP1, isP2, isP3, isP4;

    bool isC1, isC2;
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        PlayStarrtingAudio();

        if (ac.fillp >= 5.5f && !ist1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[5]);
            ist1 = true;
        }

        if (ac2.isTrue && !ist2)
        {
            StartCoroutine(Wait2());
            ist2 = true;
        }

        if(isC1 && !isC2)
        {
            StopCoroutine(Wait());
            audioSource.Stop();
            audioSource.PlayOneShot(clip[6]);
            isC1 = false;
        }
       
        if(isC2 && !isC1)
        {
            StopCoroutine(Wait());
            audioSource.Stop();
            audioSource.PlayOneShot(clip[7]);
            isC2 = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip[0]);
        yield return new WaitForSeconds(5);
        isP1 = true;
        yield return new WaitForSeconds(68);
        isP2 = true;
        yield return new WaitForSeconds(36);
        isP3 = true;
        yield return new WaitForSeconds(23);
        isP4 = true;
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(5);
        isC1 = true;
        yield return new WaitForSeconds(28);
        isC2 = true;
        TestTubeTrigger.SetActive(true);
    }

    void PlayStarrtingAudio()
    {
        if(isP1 && !ist1 && !ist2 && !isC1 && !isC2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[1]);
            isP1 = false;
        }
        if (isP2 && !ist1 && !ist2 && !isC1 && !isC2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[2]);
            isP2 = false;
        }
        if (isP3 && !ist1 && !ist2 && !isC1 && !isC2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[3]);
            isP3 = false;
        }
        if (isP4 && !ist1 && !ist2 && !isC1 && !isC2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[4]);
            isP4 = false;
        }
    }
}
