using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PippetForPP : MonoBehaviour
{
    public MoveSliderToItsPos slideScript;
    public Renderer waterMat;
    public ParticleSystem waterParticle;
    bool isEmpty = true;
    bool filled = false;
    public bool waterIsReady;
    public GameObject waterDrop;
    bool breakTheCoroutine;
    public float maxScaleX, maxScaleZ;

    public AudioSource audioSource;
    public AudioClip clipSix;

    private void Start()
    {
        waterDrop.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEmpty)
            {
                filled = false;
            }
            else if(!isEmpty)
            {
                filled = true;
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            if (!filled)
            {
                float value = waterMat.material.GetFloat("_Fill");
                if(value <= 0.55f)
                {
                    value += 0.00001f;
                    waterMat.material.SetFloat("_Fill",value);
                    if(value >= 0.54999f)
                    {
                        isEmpty = false;
                    }
                }
            }
            else if(filled)
            {
                float value = waterMat.material.GetFloat("_Fill");
                if (value > 0.5447965f)
                {
                    value -= 0.00001f;
                    waterMat.material.SetFloat("_Fill", value);
                    waterParticle.Play();
                    if (value <= 0.5447965f)
                    {
                        isEmpty = true;
                        waterParticle.Stop();
                    }
                }
                else
                {
                    waterParticle.Stop();
                }
            }
        }else if (other.CompareTag("Buch"))
        {
            if (filled)
            {
                float value = waterMat.material.GetFloat("_Fill");
                if (value > 0.5447965f)
                {
                    value -= 0.001f;
                    waterMat.material.SetFloat("_Fill", value);
                    waterParticle.gameObject.SetActive(true);
                    waterParticle.Play();
                    waterDrop.SetActive(true);

                    if (!breakTheCoroutine)
                    {
                        StartCoroutine(IncreaseWaterDropSizeX(maxScaleX));
                        StartCoroutine(IncreaseWaterDropSizeZ(maxScaleZ));

                        StartCoroutine(PlaySixthClip());
                        breakTheCoroutine = true;
                        slideScript.isWaterDrop = true;
                    }

                }
                else
                {
                    waterParticle.gameObject.SetActive(false);//waterParticle.Stop();
                }
            }
        }
    }

    IEnumerator PlaySixthClip()
    {
        yield return new WaitForSeconds(2f);
        audioSource.Stop();
        audioSource.PlayOneShot(clipSix);
        yield return new WaitForSeconds(clipSix.length + 0.5f);
    }
    private void OnTriggerExit(Collider other)
    {
        if (isEmpty)
        {
            filled = false;
        }
        else if (!isEmpty)
        {
            filled = true;
        }
    }
    IEnumerator IncreaseWaterDropSizeX(float maxX)
    {
        while(waterDrop.transform.localScale.x < maxX)
        {
            float i = waterDrop.transform.localScale.x;
            i += 0.0001f;
            waterDrop.transform.localScale = new Vector3(i, waterDrop.transform.localScale.y, waterDrop.transform.localScale.z);
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator IncreaseWaterDropSizeZ(float maxZ)
    {
        while (waterDrop.transform.localScale.z < maxZ)
        {
            float i = waterDrop.transform.localScale.z;
            i += 0.0001f;
            waterDrop.transform.localScale = new Vector3(waterDrop.transform.localScale.x, waterDrop.transform.localScale.y, i);
            yield return new WaitForFixedUpdate();
        }
    }
}
