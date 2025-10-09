using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartaudio2 : MonoBehaviour
{
    public HeartAudio ac;
    public AudioClip clip;
    public GameObject info;
    public void Click()
    {
        ac.StopCoroutineCustom();
        ac.audioSource.Stop();
        if (!info.activeInHierarchy)
        {
            info.SetActive(true);
            ac.audioSource.PlayOneShot(clip);
        }
        else
        {
            info.SetActive(false);
            ac.audioSource.Stop();
        }           
    }
}
