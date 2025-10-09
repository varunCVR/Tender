using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo017 : MonoBehaviour
{
     public AudioSource audioPlayer;
    
    [Space]
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip9;
    public AudioClip clip11;
    public AudioClip clip12;
    public AudioClip clip13;
    
    [Space]
    public buratejiontD9 for_burate;
    public burateFillTGD9 fullBurate;
    public fillerBoxTriggerD9 exitFiller;
    public flaskSETTrigger flaskEnterd;
    public GameObject finalResult;
    
    
    
    [Space] 
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;
    private bool stp7;
    private bool stp9;
    private bool stp11;
    private bool stp12;
    private bool stp13;
    
    private void Start()
    {
        StartCoroutine(timeDelay());
    }
    IEnumerator timeDelay()
    {
        yield return new WaitForSeconds(0.3f);
        audioPlayer.PlayOneShot(clip1);
        yield return new WaitForSeconds(clip1.length + 1.5f);
        stp2 = true;
        yield return new WaitForSeconds(clip2.length + 1.5f);
        /*stp3 = true;
        yield return new WaitForSeconds(clip3.length + 1.5f);*/
        stp4 = true;
    }

    IEnumerator lasttimeDelay()
    {
        yield return new WaitForSeconds(clip9.length + 0.5f);
        stp11 = true;
        audioPlayer.PlayOneShot(clip11);
    }

    private void Update()
    {

        if (!stp6)
        {
            if (stp2)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip2);
                stp2 = false;
            }
            /*if (stp3)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip3);
                stp3 = false;
            }*/
            if (stp4)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip5);
                stp4= false;
            }
        }
        if (!stp6 && for_burate.burate_Joint)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip6);
            stp6 = true;
        }
        
        // removefiller

        if (!stp7 && fullBurate.burateFull)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip7);
            stp7 = true;
        }

        if (!stp9 && exitFiller.exit_Fill)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip9);
            StartCoroutine(lasttimeDelay());
            stp9 = true;
        }

        if (!stp12)
        {
            if (stp11)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip11);
                stp11 = false;
            }
        }
        
        /*if (!stp11 && flask.xxy)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip11);
            stp11 = true;
        }*/

        if (!stp12 && flaskEnterd.firstSet)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip12);
            stp12 = true;
        }

        if (!stp13 && finalResult.activeInHierarchy)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip13);
            stp13 = true;
        }
        
    } 
}
