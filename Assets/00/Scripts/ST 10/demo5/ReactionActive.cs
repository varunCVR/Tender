using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionActive : MonoBehaviour
{
    public ZnSo4Reaction[] ZnSo4;
    public GameObject Clock1;
    [Space]
    public FeSo4Reaction[] FeSo4;
    public GameObject Clock2;
    [Space]
    public CuSo4Reaction[] Cuso4;
    public GameObject Clock3;
    [Space]
    public Al2So4Reaction[] Al2So4;
    public GameObject Clock4;
    [Space]
    public AudioDemo5 ad;
    public AudioClip clip, clip2;
    public AudioClip c2, c3, c4, c5;

    bool isT1, isT2, isT3, isT4, isT5;
    int i;

    bool is2, is3, is4;

    bool isI1, isI2, isI3;

    bool isSecondClip;
    void Update()
    {
        if(Clock1.GetComponent<DigitalClock>().min >= 5 && !isI1)
        {
            isSecondClip = true;
            StartCoroutine(Second());
            isI1 = true;
        }

        if (Clock2.GetComponent<DigitalClock>().min >= 5 && !isI2)
        {
            isSecondClip = true;
            StartCoroutine(Third());
            isI2 = true;
        }

        if (Clock3.GetComponent<DigitalClock>().min >= 5 && !isI3)
        {
            isSecondClip = true;
            StartCoroutine(Fourth());
            isI3 = true;
        }

        if (Clock4.GetComponent<DigitalClock>().min >= 5)
        {
            isSecondClip = true;
        }

        if (isSecondClip)
        {
            ad.audioSource.Stop();
            ad.audioSource.PlayOneShot(clip2);
            isSecondClip = false;
        }

        if(is2)
        {
            ad.audioSource.Stop();
            ad.audioSource.PlayOneShot(c2);
            is2 = false;
        }

        if (is3)
        {
            ad.audioSource.Stop();
            ad.audioSource.PlayOneShot(c3);
            is3 = false;
        }

        if (is4)
        {
            ad.audioSource.Stop();
            ad.audioSource.PlayOneShot(c4);
            is4 = false;
        }

        if(i >= 4 && !isT5)
        {
            StartCoroutine(Fifth());
            isT5 = true;
        }

        if (ZnSo4[0].isTrue && ZnSo4[1].isTrue && ZnSo4[2].isTrue &&ZnSo4[3].isTrue)
        {
            foreach(ZnSo4Reaction zn in ZnSo4)
            {
                zn.isMain = true;
                Clock1.GetComponent<DigitalClock>().enabled = true;
            }   

            if(!isT1)
            {
                i += 1;
                ad.audioSource.Stop();
                ad.audioSource.PlayOneShot(clip);
                isT1 = true;
            }
        }

        if (FeSo4[0].isTrue && FeSo4[1].isTrue && FeSo4[2].isTrue && FeSo4[3].isTrue)
        {
            foreach(FeSo4Reaction fe in FeSo4)
            {
                fe.isMain = true;
                Clock2.GetComponent<DigitalClock>().enabled = true;
            }

            if (!isT2)
            {
                i += 1;
                ad.audioSource.Stop();
                ad.audioSource.PlayOneShot(clip);
                isT2 = true;
            }
        }

        if (Cuso4[0].isTrue && Cuso4[1].isTrue && Cuso4[2].isTrue && Cuso4[3].isTrue)
        {
            foreach (CuSo4Reaction cu in Cuso4)
            {
                cu.isMain = true;
                Clock3.GetComponent<DigitalClock>().enabled = true;
            }

            if (!isT3)
            {
                i += 1;
                ad.audioSource.Stop();
                ad.audioSource.PlayOneShot(clip);
                isT3 = true;
            }
        }

        if (Al2So4[0].isTrue && Al2So4[1].isTrue && Al2So4[2].isTrue && Al2So4[3].isTrue)
        {
            foreach (Al2So4Reaction al in Al2So4)
            {
                al.isMain = true;
                Clock4.GetComponent<DigitalClock>().enabled = true;
            }
           
            if (!isT4)
            {
                i += 1;
                ad.audioSource.Stop();
                ad.audioSource.PlayOneShot(clip);
                isT4 = true;
            }
        }
    }
    IEnumerator Second()
    {
        yield return new WaitForSeconds(3);
        is2 = true;
    }
    IEnumerator Third()
    {
        yield return new WaitForSeconds(3);
        is3 = true;
    }
    IEnumerator Fourth()
    {
        yield return new WaitForSeconds(3);
        is4 = true;
    }
    IEnumerator Fifth()
    {
        yield return new WaitForSeconds(5);
        ad.audioSource.Stop();
        ad.audioSource.PlayOneShot(c5);
    }
}
