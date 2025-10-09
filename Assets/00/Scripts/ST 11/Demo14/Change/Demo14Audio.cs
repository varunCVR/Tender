using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo14Audio : MonoBehaviour
{
    [Header("Script Access")]
    public kasnali15MLliq[] ac;
    public CheckSugar ac2;

    public FixKasPos[] TestTubeTrigger;

    [Header("Audio Services")]
    [Space]
    public AudioSource audioSource;
    public AudioClip[] clip;

    bool ist1, ist2, ist3;

    bool isP1, isP2, isP3, isP4;

    bool isC1, isC2;
    void Start()
    {
        StartCoroutine(Wait());
    }
    void Update()
    {
        PlayStarrtingAudio();
        triggerActive();

        if (ac[0].fillp >= 5.5f && ac[1].fillp >= 5.5f && ac[2].fillp >= 5.5f && ac[3].fillp >= 5.5f && !ist1)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[5]);
            ist1 = true;
        }

        if(ac[1].fillp >= 5.6f && ac[2].fillp >= 5.65f && ac[3].fillp >= 5.7f && !ist2)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(clip[6]);
            ist2 = true;
        }

        if (ac2.isTrue && !ist3)
        {
            StartCoroutine(Wait2());
            ist3 = true;
        }

        if (isC1 && !isC2)
        {
            StopCoroutine(Wait());
            audioSource.Stop();
            audioSource.PlayOneShot(clip[7]);
            isC1 = false;
        }

        if (isC2 && !isC1)
        {
            StopCoroutine(Wait());
            audioSource.Stop();
            audioSource.PlayOneShot(clip[8]);
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
        yield return new WaitForSeconds(15);
        isC1 = true;
        yield return new WaitForSeconds(18);
        isC2 = true;
    }

    void PlayStarrtingAudio()
    {
        if (isP1 && !ist1 && !ist2 && !isC1 && !isC2)
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

    void triggerActive()
    {
        if (ac2.a >= 1 && ac2.Clock.GetComponent<DigitalClock>().min >= 2)
        {
            StartCoroutine(Trig1Active());
        }

        if (ac2.b >= 1 && ac2.Clock.GetComponent<DigitalClock>().min >= 2)
        {
            StartCoroutine(Trig2Active());
        }

        if (ac2.c >= 1 && ac2.Clock.GetComponent<DigitalClock>().min >= 2)
        {
            StartCoroutine(Trig3Active());
        }

        if (ac2.d >= 1 && ac2.Clock.GetComponent<DigitalClock>().min >= 2)
        {
            StartCoroutine(Trig4Active());
        }
    }
    IEnumerator Trig1Active()
    {
        yield return new WaitForSeconds(30);
        TestTubeTrigger[0].GetComponent<Collider>().enabled = true;
    }
    IEnumerator Trig2Active()
    {
        yield return new WaitForSeconds(30);
        TestTubeTrigger[1].GetComponent<Collider>().enabled = true;
    }
    IEnumerator Trig3Active()
    {
        yield return new WaitForSeconds(30);
        TestTubeTrigger[2].GetComponent<Collider>().enabled = true;
    }
    IEnumerator Trig4Active()
    {
        yield return new WaitForSeconds(30);
        TestTubeTrigger[3].GetComponent<Collider>().enabled = true;
    }
}
