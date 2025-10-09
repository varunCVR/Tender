using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioForDemo3 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;
    public float firstDelay;
  //  public float[] timeDelay;
    
  /*
   * clip  - 5  summary
   *
   * clip - 6 and 7 summary
   *
   * 
   */
  
    [Header("Script Area")]
    public archConnection_hing hingConnent;
    public enter_wtr enterWat;
    public GameObject bottelLeft;
    public updateDensityText massObj;
    public saltExit saltMelt;
    public GameObject TGsalt;
    public DEST_saltScript saltEnd;

    [Space]
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;
    private bool stp7;
    private bool stp8;
    private void Start() {
        StartCoroutine(audioDelay());
    }
    IEnumerator audioDelay() {
        yield return new WaitForSeconds(firstDelay);
        
        audioPlayer.PlayOneShot(clipAll[0]);
        yield return new WaitForSeconds(clipAll[0].length + 0.5f);

        if (!stp1)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[1]);
        }
    }
    IEnumerator audioDelay5_6()
    {
        audioPlayer.PlayOneShot(clipAll[5]);
        yield return new WaitForSeconds(clipAll[5].length + 0.5f);

        if (!stp5)
        {       
              audioPlayer.Stop();
              audioPlayer.PlayOneShot(clipAll[6]);
        }
    }
    IEnumerator audioDelatLast() {
        audioPlayer.PlayOneShot(clipAll[10]);
        yield return new WaitForSeconds(clipAll[10].length + 0.5f);
        audioPlayer.PlayOneShot(clipAll[11]);
    }
    private void Update()
    {
        if (!stp1 && hingConnent.connectGrm) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[2]);
            stp1 = true;
        }
      
        if (!stp2 && enterWat.firstTime) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[3]);
            stp2 = true;
        }

        if (!stp3 && !bottelLeft.activeInHierarchy ) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[4]);
            stp3 = true;
        }

        if (!stp4 && massObj.nWbicker) {
            audioPlayer.Stop();
            StartCoroutine(audioDelay5_6());
            stp4 = true;
        }

        if (!stp5 && saltMelt.slatyAll) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[7]);
            stp5 = true;
        }

        if (!stp6 && saltMelt.slatyAll && TGsalt.GetComponent<for_saltwtr>().entrd) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[8]);
            stp6 = true;
        }

        if (!stp7 && saltEnd.section) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[9]);
            stp7 = true;
        }

        if (!stp8 && massObj.sWbicker && massObj.nWbicker) {
            audioPlayer.Stop();
            StartCoroutine(audioDelatLast());
            stp8 = true;
        }
    }
}
