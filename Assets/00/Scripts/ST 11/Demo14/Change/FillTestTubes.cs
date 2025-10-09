using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTestTubes : MonoBehaviour
{
    public GameObject KLiqu;
    public GameObject Trigger2;

    GameObject Pipette, PipetteLiq;

    bool isProcess;
    bool isTrue;

    private void Update()
    {
        if(isProcess)
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
            if (KLiqu.GetComponent<kasnali15MLliq>().fillp <= 5)
            {
                KLiqu.GetComponent<kasnali15MLliq>().fillp += Time.deltaTime * 1.9f;
            }
        }

        if (KLiqu.GetComponent<kasnali15MLliq>().fillp >= 5)
        {
            PipetteLiq.GetComponent<FillPipettes>().isEmpty = false;
            Trigger2.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            Pipette = other.transform.parent.gameObject;
            PipetteLiq = other.gameObject;

            isProcess = true;
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

