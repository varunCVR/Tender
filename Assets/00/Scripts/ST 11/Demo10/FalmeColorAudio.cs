using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalmeColorAudio : MonoBehaviour
{
    [Header("Script Access")]
    public platinumgol ac;
    public FlameColor fc;
    
    [Header("Objects")][Space]
    public GameObject PasteTrigger;
    public GameObject BlueGlass;

    [Header("Audio Material")][Space]
    public AudioClip[] clips;
    public AudioSource audioSource;

    bool isT1, isT2, isT3, isT4, isT5, isT6;

    bool is1, is2, is3;

    bool isP1, isP2;
    void Start()
    {
        StartCoroutine(Wait());
    }
    private void Update()
    {
        Clip2_3();
        LastAudio();

        if (ac.golbhag.activeInHierarchy && !isT1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[3]);
            isT1 = true;
        }

        if(fc.isfix && ! isT2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[4]);
            isT2 = true;
        }

        if(!PasteTrigger.activeInHierarchy && !isT3)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[5]);
            isT3 = true;
        }

        if(fc.isNa && !isT4)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[6]);
            isT4 = true;
        }

        if(BlueGlass.GetComponent<Rigidbody>().collisionDetectionMode == CollisionDetectionMode.ContinuousDynamic && !isT5 && isT4)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[7]);
            isT5 = true;
        }  
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clips[0]);
        yield return new WaitForSeconds(14f);
        isP1 = true;
        yield return new WaitForSeconds(18f);
        isP2 = true;
    }
    void Clip2_3()
    {
        if(isP1 && !isT1 && !isT2 && !isT3 && !isT4 && !isT5 && !isT6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[1]);
            isP1 = false;
        }

        if (isP2 && !isT1 && !isT2 && !isT3 && !isT4 && !isT5 && !isT6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[2]);
            isP2 = false;
        }            
    }

    void LastAudio()
    {
        if (fc.isP)
        {
            is1 = true;
        }

        if (fc.isSr)
        {
            is2 = true;
        }

        if (fc.isBa)
        {
            is3 = true;
        }

        if (is1 && is2 && is3 && !isT6)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clips[8]);
            isT6 = true;
        }
    }
}
