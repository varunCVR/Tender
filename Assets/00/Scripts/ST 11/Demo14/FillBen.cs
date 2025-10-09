using System.Collections;
using UnityEngine;

public class FillBen : MonoBehaviour
{
    public pipet10MLliq PipetLiq;
    public LiqfillEffect Benedict;
    public LiqfillEffect Urine;
    public kasnali15MLliq KBen;

    public GameObject KasnaliCollider;
    public GameObject HoldTrigger;
    public Color MixColor;

    public ParticleSystem BenParticle;
    public ParticleSystem UreParticle;

    bool isStart;
    bool isFill, isEmpty;
    bool isBen, isUrine;
    private void Update()
    {
        if (Benedict.fillFloat_100ml <= 95)
        {
            Benedict.shaderRD.gameObject.GetComponent<Collider>().enabled = false;     
        }

        if (Urine.fillFloat_100ml <= 99.5f)
        {
            Urine.shaderRD.gameObject.GetComponent<Collider>().enabled = false;
        }

        if(KBen.fillp >= 5)
        {
            Urine.shaderRD.gameObject.GetComponent<Collider>().enabled = true;
            isBen = false;
        }

        if(KBen.fillp >= 5.5f)
        {
            StartCoroutine(KTime());
        }

        if (isFill)
        {
            if(isBen)
            {
                if (PipetLiq.fillp <= 5)
                {
                    PipetLiq.fillp += Time.deltaTime * 1.5f;
                }

                if (Benedict.fillFloat_100ml >= 95)
                {
                    Benedict.fillFloat_100ml -= Time.deltaTime * 1.2f;
                }
            }       
            
            if(isUrine)
            {
                PipetLiq.pipetRend.material.SetColor("_LCol", Urine.shaderRD.material.GetColor("_LCol"));
                PipetLiq.pipetRend.material.SetColor("_SCol", Urine.shaderRD.material.GetColor("_SCol"));
                if (PipetLiq.fillp <= .35f)
                {
                    PipetLiq.fillp += Time.deltaTime * 1.5f;
                }

                if (Urine.fillFloat_100ml >= 99.5f)
                {
                    Urine.fillFloat_100ml -= Time.deltaTime * 1.2f;
                }
            }
        }      

        if(isEmpty)
        {
            isFill = false;

            if (PipetLiq.fillp > -1.2f)
            {
                if(isBen)
                {
                    BenParticle.Play();
                }
                
                if(isUrine)
                {
                    UreParticle.Play();
                }

                PipetLiq.fillp -= Time.deltaTime * 1.5f;
                StartCoroutine(StartFill());
            }   
        }

        if (isStart)
        {
            if(isBen)
            {            
                if (KBen.fillp <= 5)
                {
                    KBen.fillp += Time.deltaTime * 1.2f;
                }
            }

            if (isUrine)
            {           
                if (KBen.fillp <= 5.5f)
                {
                    KBen.kasnaliRend.material.SetColor("_LCol", MixColor);
                    KBen.fillp += Time.deltaTime * 1.2f;             
                }
            }      
        }

        if (PipetLiq.fillp <= -1.2f)
        {
            BenParticle.Stop();
            UreParticle.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isBen = true;
            isFill = true;
        }

        if (other.tag == "Player2")
        {
            isUrine = true;
            isFill = true;
        }

        if (other.tag == "Respawn")
        {
            isEmpty = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isFill = false;
        }

        if (other.tag == "Respawn")
        {
            StartCoroutine(StopFill());
            BenParticle.Stop();
            UreParticle.Stop();
            isEmpty = false;
        }
    }
    IEnumerator StartFill()
    {
        StopCoroutine(StopFill());
        yield return new WaitForSeconds(.7f);
        isStart = true;
    }
    IEnumerator StopFill()
    {
        StopCoroutine(StartFill());
        yield return new WaitForSeconds(.7f);
        isStart = false;
    }

    IEnumerator KTime()
    {
        yield return new WaitForSeconds(3);
        KasnaliCollider.SetActive(false);
        KBen.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        HoldTrigger.SetActive(true);
    }
}
