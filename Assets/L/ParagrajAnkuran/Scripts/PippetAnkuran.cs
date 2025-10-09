using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PippetAnkuran : MonoBehaviour
{
    bool breakCoroutine;
    public GameObject waterDrop;
    public Pippet pippetType;
    public float maxX;
    public float maxY;
    public float maxZ;
    public AudioSource audioSource;
    public AudioClip sixth,seventh;

    public GlassHandler glassHandler;

    public enum Pippet
    {
        Glycerine,
        CottonStainBlue,
        DistilledWater
    }
    private void OnTriggerExit(Collider other)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(pippetType == Pippet.Glycerine)
        {
            if (other.CompareTag("CopperS"))
            {
                if (!breakCoroutine)
                {
                    StartCoroutine(IncreaseWaterDropSizeX(maxX));
                    StartCoroutine(IncreaseWaterDropSizeZ(maxZ));
                    StartCoroutine(IncreaseWaterDropSizeY(maxY));
                    breakCoroutine = true;

                    glassHandler.glycerinePositioned = true;
                }
            }
        }else if(pippetType == Pippet.CottonStainBlue)
        {
            if (other.CompareTag("Cable2"))
            {

                if (!breakCoroutine)
                {
                    StartCoroutine(IncreaseWaterDropSizeX(maxX));
                    StartCoroutine(IncreaseWaterDropSizeZ(maxY));
                    StartCoroutine(PlayNextAudioSixth());
                    breakCoroutine = true;
                }
            }
        }else if(pippetType == Pippet.DistilledWater)
        {
            if (other.CompareTag("CableOne"))
            {
                if (!breakCoroutine)
                {
                    StartCoroutine(IncreaseWaterDropSizeX(maxX));
                    StartCoroutine(IncreaseWaterDropSizeZ(maxY));
                    StartCoroutine(PlayNextAudioSeventh());
                    breakCoroutine = true;
                }
            }
        }
     }
    IEnumerator PlayNextAudioSeventh()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(seventh);
        yield return new WaitForSeconds(13f);
    }
    IEnumerator PlayNextAudioSixth()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sixth);
        yield return new WaitForSeconds(13f);
    }
    IEnumerator IncreaseWaterDropSizeX(float maxX)
    {
        
        while (waterDrop.transform.localScale.x < maxX)
        {
            float i = waterDrop.transform.localScale.x;
            
            i += 0.00001f;
            waterDrop.transform.localScale = new Vector3(i, waterDrop.transform.localScale.y, waterDrop.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator IncreaseWaterDropSizeZ(float maxZ)
    {
        while (waterDrop.transform.localScale.z < maxZ)
        {
            float i = waterDrop.transform.localScale.z;
            i += 0.00001f;
            waterDrop.transform.localScale = new Vector3(waterDrop.transform.localScale.x, waterDrop.transform.localScale.y, i);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator IncreaseWaterDropSizeY(float maxY)
    {
        while (waterDrop.transform.localScale.y < maxY)
        {
            float i = waterDrop.transform.localScale.y;
            i += 0.00001f;
            waterDrop.transform.localScale = new Vector3(waterDrop.transform.localScale.x, i, waterDrop.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
    }
}
