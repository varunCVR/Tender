using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSeeds : MonoBehaviour
{
    public MoveSliderToItsPos sliderScript;
    public GameObject[] allSeeds;
    int i = 0;
    bool helper;

    public AudioSource audioSource;
    public AudioClip clipSeven;
    bool PlayAudioOnlyOnce;

    private void Start()
    {
        for (int i = 0; i < allSeeds.Length; i++)
        {
            allSeeds[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buch"))
        {
            if (!helper)
            {
                i += 1;
                helper = true;
            }
            if(i >= 3)
            {
                sliderScript.isWaterDrop = true;
                sliderScript.plantSeedsIsOn = true;
                for(int i = 0; i< allSeeds.Length; i++)
                {
                    allSeeds[i].SetActive(true);

                    if (!PlayAudioOnlyOnce)
                    {

                        StartCoroutine(PlaySeventhClip());

                        PlayAudioOnlyOnce = true;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Buch"))
        {
            helper = false;
        }
    }

    IEnumerator PlaySeventhClip()
    {
        yield return new WaitForSeconds(1f);
        audioSource.Stop();
        audioSource.PlayOneShot(clipSeven);
        yield return new WaitForSeconds(clipSeven.length + 0.5f);
    }
}
