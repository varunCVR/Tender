using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetText : MonoBehaviour
{
    public PlantCellAudio ad;
    public AudioClip ac;

    public GameObject Text;
    public void Click()
    {
        ad.audioSource.Stop();
        if(!Text.activeInHierarchy)
        {
            Text.SetActive(true);
            ad.audioSource.PlayOneShot(ac);
        }
        else
        {
            Text.SetActive(false);
            ad.audioSource.Stop();
        }
    }
}
