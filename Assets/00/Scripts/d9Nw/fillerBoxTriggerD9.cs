using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class fillerBoxTriggerD9 : MonoBehaviour
{
    public bool enterd_Fill;
    public bool exit_Fill;

    public Transform filler;
    public Transform fillterPos;
    public Grabbable fillerGrabble;
    [Space]
    public GameObject BickerfillTrigger;

    [Space] public burateFillTGD9 fullSign;

    public GameObject hclTG;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("X") && !exit_Fill)
        {
            enterd_Fill = true;
            fillerGrabble.enabled = false;
            BickerfillTrigger.SetActive(true);
        }
    }

    private void Update()   
    {
        if (enterd_Fill)
        {
            if (!fullSign.burateFull)
            {
                filler.position = fillterPos.position;
                filler.rotation = fillterPos.rotation;
            }

            if (fullSign.burateFull && filler.gameObject.GetComponent<Rigidbody>().useGravity)
            {
                filler.position = fillterPos.position;
                filler.rotation = fillterPos.rotation;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("X"))
        {
            if (fullSign.burateFull)
            {
                hclTG.SetActive(true);
                enterd_Fill = false;
                exit_Fill = true;
            }
        }
    }
}
