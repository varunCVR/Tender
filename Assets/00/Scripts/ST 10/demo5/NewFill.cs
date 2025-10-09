using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFill : MonoBehaviour
{
    public GameObject Pipette;
    public GameObject BeakerLiq;
    public ParticleSystem Drop;

    public string FillTag;

    [HideInInspector]
    public bool isFill, isEmpty;

    float fill;

    private void Update()
    {
        Pipette.GetComponent<Renderer>().material.SetFloat("FillArea", fill);

        if (isFill)
        {
            isEmpty = false;
            if (Pipette.GetComponent<pipett25ML>().fillp <= 25f)
            {
                Pipette.GetComponent<pipett25ML>().fillp += Time.deltaTime * 4.5f;
               
                if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_500ml >= 400)
                {
                    BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_500ml -= Time.deltaTime * 4.3f;
                }
            }       
        }

        if (isEmpty)
        {
            isFill = false;
            if (Pipette.GetComponent<pipett25ML>().fillp >= -1.2f)
            {
                Drop.Play();
                Pipette.GetComponent<pipett25ML>().fillp -= Time.deltaTime * 4.5f;
            }
            else
            {
                Drop.Stop();
            }
        }
        else
        {
            Drop.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == FillTag)
        {
            isFill = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == FillTag)
        {
            isFill = false;
        }
    }
}
