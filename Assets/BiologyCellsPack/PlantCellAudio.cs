using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCellAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Clip;
    private void Start()
    {
        StartCoroutine(Wait());          
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(Clip);
    }
}
