using UnityEngine;
using System.Collections;
using BNG;

public class PHAudio : MonoBehaviour
{
    public CheckPH[] Ac;
    public AudioSource audioSource;
    public AudioClip[] clip;

    bool isTrue, isfalse;
    bool isP1;
    void Start()
    {
        StartCoroutine(Wait());
    }

    void Update()
    {
        foreach(CheckPH ph in Ac)
        {
            if(ph.isTime || ph.isTime2)
            {
                isTrue = true;
            }
        }

        if(isTrue && !isfalse)
        {
            StartCoroutine(Wait2());
            audioSource.Stop();
            isfalse = true;
        }

        if(isP1 && !isTrue)
        {
            audioSource.PlayOneShot(clip[1]);
            isP1 = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip[0]);
        yield return new WaitForSeconds(5);
        isP1 = true;
    }
    IEnumerator Wait2()
    {
        audioSource.PlayOneShot(clip[2]);
        yield return new WaitForSeconds(3);
        audioSource.PlayOneShot(clip[3]);
    }
}
