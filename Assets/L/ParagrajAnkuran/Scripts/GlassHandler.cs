using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassHandler : MonoBehaviour
{
    public GameObject childGlass;
    public bool glassAttached;

    public GameObject target;
    bool move;
    bool positionedCorrectly;
    public bool flowerPositioned, glycerinePositioned;

    public Texture t1, t2;
    bool execOnce,finishedTextures;
    public Renderer ratinaDisplay;
    public Renderer glassOne, glassTwo;

    public Color emissionColor;

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
            if(Vector3.Distance(transform.position,target.transform.position) <= 0.005f)
            {
                transform.eulerAngles = new Vector3(0,92.5f, 0);
                positionedCorrectly = true;
            }
            else
            {
                positionedCorrectly = false;
            }
        }

       /* if (glassAttached)
        {
            childGlass.transform.position = new Vector3(0, 0.004f, 0f);
            glassAttached = false;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            move = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("N"))
        {
            move = true;
            if(positionedCorrectly&& flowerPositioned && glycerinePositioned && !execOnce)
            {
                StartCoroutine(ChangeTextures());
                execOnce = false;
            }
            else if (!positionedCorrectly)
            {
                StopAllCoroutines();
                ratinaDisplay.material.SetTexture("_BaseMap", null);
                glassOne.material.SetTexture("_BaseMap", null);
                glassTwo.material.SetTexture("_BaseMap", null);
                ratinaDisplay.material.SetColor("_EmissionColor", emissionColor);
                glassOne.material.SetColor("_EmissionColor", emissionColor);
                glassTwo.material.SetColor("_EmissionColor", emissionColor);
            }
        }
    }
    IEnumerator ChangeTextures()
    {
        if (!finishedTextures)
        {
            ratinaDisplay.material.SetTexture("_BaseMap", t1);
            ratinaDisplay.material.SetColor("_EmissionColor", Color.black);

            glassOne.material.SetTexture("_BaseMap", t1);
            glassOne.material.SetColor("_EmissionColor", Color.black);
            glassTwo.material.SetTexture("_BaseMap", t1);
            glassTwo.material.SetColor("_EmissionColor", Color.black);

            yield return new WaitForSeconds(5f);
            ratinaDisplay.material.SetTexture("_BaseMap", t2);
            glassOne.material.SetTexture("_BaseMap", t2);
            glassTwo.material.SetTexture("_BaseMap", t2);
            finishedTextures = true;
        }
        else
        {
            ratinaDisplay.material.SetTexture("_BaseMap", t2);
            ratinaDisplay.material.SetColor("_EmissionColor", Color.black);

            glassOne.material.SetTexture("_BaseMap", t2);
            glassOne.material.SetColor("_EmissionColor", Color.black);
            glassTwo.material.SetTexture("_BaseMap", t2);
            glassTwo.material.SetColor("_EmissionColor", Color.black);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            move = false;
        }
    }
}
