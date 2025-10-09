using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;

public class AudioHolder : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
       
    }


    public void Play()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }
    public void Stop()
    {
        audioSource.Stop();
    }
}
