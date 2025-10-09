using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillHClPipette : MonoBehaviour
{
    public pipet10MLliq PipetLiq;
    public LiqfillEffect HCl;

    public ParticleSystem Drops;

    [HideInInspector]
    public GameObject Paste;

    [HideInInspector]
    public bool isPaste, isEmpty, isFill;

    private void Update()
    {
        if(isFill)
        {
            if (PipetLiq.fillp <= 10)
            {
                PipetLiq.fillp += Time.deltaTime * 1.5f;
            }

            if (HCl.fillFloat_100ml >= 90)
            {
                HCl.fillFloat_100ml -= Time.deltaTime * 1.3f;
            }
        }

        if(isEmpty)
        {
            isFill = false;
            if (PipetLiq.fillp > -1.2f)
            {
                PipetLiq.fillp -= Time.deltaTime * .23f;
                Drops.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Respawn")
        {
            isFill = true;
        }

        if (other.tag == "X")
        {
            Paste = other.gameObject;
            isPaste = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Respawn")
        {
            isFill = false;
        }

        if (other.tag == "X")
        {
            isPaste = false;
            isEmpty = false;
            Drops.Stop();
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
        Drops.gameObject.SetActive(false);
    }
}
