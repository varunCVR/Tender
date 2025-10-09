using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAudio : MonoBehaviour
{
    public GameObject[] info;
    public GameObject Buttons;

    public AudioSource audioSource;
    public AudioClip[] clip;

    [HideInInspector]
    public bool isTrue;
    void Start()
    {
        foreach(GameObject obj in info)
        {
            obj.SetActive(false);
        }

        StartCoroutine(Wait());
    }

    private void Update()
    {
        if(isTrue)
        {
            StopCoroutine(Wait());
        }
    }

    public void StopCoroutineCustom()
    {
        StopCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        if(!isTrue)
        {
            Buttons.SetActive(true);
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(clip[0]);
            /*yield return new WaitForSeconds(7);
            audioSource.PlayOneShot(clip[1]);
            yield return new WaitForSeconds(5.2f);*/
            
        }
    }
}
