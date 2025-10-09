using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo1 : MonoBehaviour
{

    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    public float firstDelay;

    public float[] timeDelay;



    [Header("Script Area")] 
    public for_making_X xTrigger;
    public for_making_Y yTrigger;
    
    [Space] 
    public GameObject realFlask_OTP;
  
    [Space] 
    public massReadUpdate massSignal;
            
    [Space] 
    public changerWhite whiteScript;
    
    private bool stop1;
    private bool stop2;
    private bool stop3;
    private bool stop4;
    
    void Start() {
        StartCoroutine(firstAudioDelay());
    }

    IEnumerator firstAudioDelay() {
        yield return new WaitForSeconds(firstDelay);
        audioPlayer.PlayOneShot(clipAll[0]);
        
        yield return new WaitForSeconds(timeDelay[0]);
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(clipAll[1]);
        
        yield return new WaitForSeconds(timeDelay[1]);
        audioPlayer.Stop();
        audioPlayer.PlayOneShot(clipAll[2]);
    }
    void Update()
    {
        if (!stop1 && xTrigger.wb2 && xTrigger.wb3 && xTrigger.wb4 && yTrigger.wb2 && yTrigger.wb3 && yTrigger.wb4)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[3]);
            stop1 = true;
        }

        if (!stop2 && realFlask_OTP.activeInHierarchy)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[4]);
            stop2 = true;
        }

        if (!stop3 && massSignal.sign)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[5]);
            stop3 = true;
        }

        if (!stop4 && whiteScript.changed)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[6]);
            stop4 = true;
        }
    }
}
