using System.Collections;
using UnityEngine;

public class audioForDemo20 : MonoBehaviour
{
     public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    public float firstDelay;
 
    void Start() {
         StartCoroutine(firstAudioDelay());
     }
   
      IEnumerator firstAudioDelay() {
           yield return new WaitForSeconds(firstDelay);
           audioPlayer.PlayOneShot(clipAll[0]);
           
           yield return new WaitForSeconds(clipAll[0].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[1]);
           
           yield return new WaitForSeconds(clipAll[1].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[2]);
           
           yield return new WaitForSeconds(clipAll[2].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[3]);
           
           yield return new WaitForSeconds(clipAll[3].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[4]);
           
           yield return new WaitForSeconds(clipAll[4].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[5]);
           
           yield return new WaitForSeconds(clipAll[5].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[6]);
           
           yield return new WaitForSeconds(clipAll[6].length +0.5f);
           audioPlayer.Stop();
           audioPlayer.PlayOneShot(clipAll[7]);
       }
}
