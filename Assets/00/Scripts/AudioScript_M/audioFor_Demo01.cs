using System.Collections;
using Oculus.Interaction;
using UnityEngine;

public class audioFor_Demo01 : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] clipAll;

    public float firstDelay;
    
    
    
    [Space]
    public for_making_X allBool_X;
    
    [Space]
    public for_making_Y allBool_Y;

    [Space] public Grabbable yGlassReal;
    [Space] public GameObject realFlask_OTP;
    
    private bool stp1;
    private bool stp2;
    private bool stp3;
    private bool stp4;
    private bool stp5;
    private bool stp6;

    private bool clp2H;
    private bool clp3H;

    [Space] public glassX_set glassSetX;

    [Space] 
    public massReadUpdate massSignal;
            
    [Space] 
    public changerWhite whiteScript;
    void Start() {
        StartCoroutine(firstAudioDelay());
    }

    IEnumerator firstAudioDelay() {

        yield return new WaitForSeconds(0.1f);
        audioPlayer.PlayOneShot(clipAll[0]);
        yield return new WaitForSeconds(clipAll[0].length + 0.1f);
        clp2H = true;
        yield return new WaitForSeconds(clipAll[1].length + 0.1f);
        clp3H = true;
    }

 
    IEnumerator clip4Activation()
    {
        yield return new WaitForSeconds(0.1f);
        yGlassReal.enabled = true;
    }
    private void Update()
    {
        if (!stp1)
        {
            if (clp2H)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[1]);
                clp2H = false;
            }

            if (clp3H)
            {
                audioPlayer.Stop();
                audioPlayer.PlayOneShot(clipAll[2]);
                clp3H = false;
            }
        }
        if (!stp1 && allBool_X.wb2 && allBool_X.wb3 && allBool_X.wb4)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[3]);
            stp1 = true;
        }

        if (!stp2 && allBool_Y.wb2 && allBool_Y.wb3 && allBool_Y.wb4)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[4]);
            StartCoroutine(clip4Activation());
            stp2 = true;
        }

        if (!stp3 && glassSetX.SglaaSignal)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[5]);
            stp3 = true;
        }
        
        if (!stp4 && realFlask_OTP.activeInHierarchy)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[6]);
            stp4 = true;
        }
        
        
        if (!stp5 && massSignal.sign)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[7]);
            stp5 = true;
        }

        if (!stp6 && whiteScript.changed)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clipAll[8]);
            stp6 = true;
        }
    }
}
