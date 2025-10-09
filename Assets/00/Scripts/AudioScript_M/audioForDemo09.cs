using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo09 : MonoBehaviour
{
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    public AudioClip clip5;
    public AudioClip clip6;
    public AudioClip clip7;
    public AudioClip clip8;
    public AudioClip clip9;

    // script all......
    [Space]
    public buratejiontD9 for_burate;
    public fillerBoxTriggerD9 exitFiller;
    public burateFillTGD9 burateFull;
    public flaskInnerTrigger_d9 HclSign;
    
    // one time call helper.......
    [Space] 
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;
    private bool stp7;
    private bool stp8;
    private bool stp9;
    
    
    
    [Space]
    public AudioSource audioPlayer;

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
        stp3 = true;
    }
    IEnumerator delay5to6()
    {
        yield return new WaitForSeconds(clip5.length +1.5f);
        stp6 = true;
    }

    private void Update()
    {
        if (!stp4)
        {
            if (stp2)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip2);
                stp2=false;
            }
            if (stp3)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip3);
                stp3 = false;
            }
        }

        if (!stp4 && for_burate.burate_Joint)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip4);
            stp4 = true;
        }

        if (!stp5 && burateFull.burateFull)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip5);
            StartCoroutine(delay5to6());
            stp5 = true;
        }

        if (!stp7)
        {
            if (stp6)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clip6);
                stp6 = false;
            }
        }

        if (!stp7 && HclSign.HCLfilled)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip7);
            stp7 = true;
        }

        if (!stp8 && HclSign.FINfilled)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip8);
            stp8 = true;
        }

        /*if (!stp9 && lastButton.lastOne)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip9);
            stp9 = true;
        }*/
    }
}
