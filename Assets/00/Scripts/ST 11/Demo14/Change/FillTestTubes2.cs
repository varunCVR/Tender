using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTestTubes2 : MonoBehaviour
{
    public GameObject KLiqu;
    public GameObject Trigger3;
    public Color Col;

    GameObject Pipette, PipetteLiq;

    bool isProcess;
    bool isTrue;

    private void Update()
    {
        if (isProcess)
        {
            if (Pipette.GetComponent<pipet10MLliq>().fillp > -1.2f)
            {
                PipetteLiq.GetComponent<FillPipettes>().isEmpty = true;
                StartCoroutine(WaitForFill());
            }
            else
            {
                StartCoroutine(StopForFill());
            }
        }
        else
        {
            StartCoroutine(StopForFill());
        }

        if (isTrue)
        {
            if (KLiqu.GetComponent<kasnali15MLliq>().fillp >= 5f && KLiqu.GetComponent<kasnali15MLliq>().fillp <= 5.5f)
            {
                KLiqu.GetComponent<kasnali15MLliq>().kasnaliRend.material.SetColor("_LCol", Col);
                KLiqu.GetComponent<kasnali15MLliq>().fillp += Time.deltaTime * 1.3f;
            }
        }

        if (KLiqu.GetComponent<kasnali15MLliq>().fillp >= 5.5f)
        {
            PipetteLiq.GetComponent<FillPipettes>().isEmpty = false;
            Trigger3.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            Pipette = other.transform.parent.gameObject;
            PipetteLiq = other.gameObject;

            if (PipetteLiq.GetComponent<FillPipettes>().isFix1)
            {
                isProcess = true;
            }             
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            other.GetComponent<FillPipettes>().isEmpty = false;
            isProcess = false;
        }
    }
    IEnumerator WaitForFill()
    {
        yield return new WaitForSeconds(.74f);
        isTrue = true;
    }
    IEnumerator StopForFill()
    {
        yield return new WaitForSeconds(.74f);
        isTrue = false;
    }

}
