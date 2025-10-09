using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDemo5 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] clip;

    bool is1;
    private void Update()
    {
        if(is1)
        {
            audioSource.PlayOneShot(clip[1]);
            is1 = false;
        }
    }
    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(clip[0]);
        yield return new WaitForSeconds(11.5f);
        is1 = true;
    }
}
