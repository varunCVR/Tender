using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillPipettes : MonoBehaviour
{
    public GameObject Pipette;
    GameObject BeakerLiq;
    public GameObject BeakerUrine;
    public GameObject BeakerGlucose;
    [Space]
    public ParticleSystem BenDrop;
    public ParticleSystem UriDrop;
    public ParticleSystem GluDrop;
    [Space]
    public Color UriCol;
    public Color GluCol;

    [HideInInspector]
    public bool isFill, isEmpty;
    [HideInInspector]
    public bool isBen, isUri, isGlu;
    [HideInInspector]
    public bool isFix1, isFix2;

    private void Update()
    {
        if(BeakerLiq && Pipette)
        {
            if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml <= 80 && Pipette.GetComponent<pipet10MLliq>().fillp <= -1.2f)
            {
                isFix1 = true;
            }

            if(isFix1 && BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml <= 98 && BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml > 80 && Pipette.GetComponent<pipet10MLliq>().fillp <= -1.2f)
            {
                isFix2 = true;
            }
        }

        if (isFill && BeakerLiq)
        {
            if(isBen)
            {
                if (Pipette.GetComponent<pipet10MLliq>().fillp <= 10)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp += Time.deltaTime * 1.5f;

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml >= 80)
                    {
                        BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml -= Time.deltaTime * 1.33f;
                    }

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml <= 80)
                    {
                        BeakerLiq.GetComponent<LiqfillEffect>().shaderRD.GetComponent<Collider>().enabled = false;
                        BeakerUrine.GetComponent<Collider>().enabled = true;               
                    }
                }
            }

            if(isUri)
            {
                isBen = false;

                Pipette.GetComponent<pipet10MLliq>().pipetRend.material.SetColor("_LCol", UriCol);
                Pipette.GetComponent<pipet10MLliq>().pipetRend.material.SetColor("_SCol", UriCol);

                if (Pipette.GetComponent<pipet10MLliq>().fillp <= 2)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp += Time.deltaTime * 1.5f;

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml >= 98)
                    {
                        BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml -= Time.deltaTime * 1.33f;
                    }

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml <= 98)
                    {
                        BeakerUrine.GetComponent<Collider>().enabled = false;
                        BeakerGlucose.GetComponent<Collider>().enabled = true;
                    }
                }
            }

            if (isGlu)
            {
                isUri = false;

                Pipette.GetComponent<pipet10MLliq>().pipetRend.material.SetColor("_LCol", GluCol);
                Pipette.GetComponent<pipet10MLliq>().pipetRend.material.SetColor("_SCol", GluCol);

                if (Pipette.GetComponent<pipet10MLliq>().fillp <= 3)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp += Time.deltaTime * 1.5f;

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml >= 98)
                    {
                        BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml -= Time.deltaTime * 1.33f;
                    }

                    if (BeakerLiq.GetComponent<LiqfillEffect>().fillFloat_100ml <= 98)
                    {
                        BeakerUrine.GetComponent<Collider>().enabled = false;
                        BeakerGlucose.GetComponent<Collider>().enabled = true;
                    }
                }
            }

        }

        if (isEmpty)
        {
            isFill = false;

            if(isBen)
            {
                if (Pipette.GetComponent<pipet10MLliq>().fillp >= -1.2f)
                {
                    BenDrop.Play();
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * 1.5f;
                }
                else
                {
                    BenDrop.Stop();
                }

                if (Pipette.GetComponent<pipet10MLliq>().fillp <= 5)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * .5f;
                }
            }

            if(isUri)
            {
                if (Pipette.GetComponent<pipet10MLliq>().fillp >= -1.2f)
                {
                    UriDrop.Play();
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * .5f;
                }
                else
                {
                    UriDrop.Stop();
                }

                if (Pipette.GetComponent<pipet10MLliq>().fillp <= .5f)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * 1;
                }
            }      

            if(isGlu)
            {
                if (Pipette.GetComponent<pipet10MLliq>().fillp >= -1.2f)
                {
                    GluDrop.Play();
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * 1.5f;
                }
                else
                {
                    GluDrop.Stop();
                }

                if (Pipette.GetComponent<pipet10MLliq>().fillp <= .5f)
                {
                    Pipette.GetComponent<pipet10MLliq>().fillp -= Time.deltaTime * 1;
                }
            }
        }
        else
        {
            BenDrop.Stop();
            UriDrop.Stop();
            GluDrop.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            BeakerLiq = other.transform.parent.gameObject;
            isFill = true;
            isBen = true;
        }

        if (other.tag == "Player2")
        {
            BeakerLiq = other.transform.parent.gameObject;
            isFill = true;
            isUri = true;
        }

        if (other.tag == "Player3")
        {
            BeakerLiq = other.transform.parent.gameObject;
            isFill = true;
            isGlu = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player2" || other.tag == "Player3")
        {
            isFill = false;
        }
    }
}
