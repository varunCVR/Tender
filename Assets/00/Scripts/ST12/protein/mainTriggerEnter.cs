using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainTriggerEnter : MonoBehaviour
{
    public resetColor1 mainLiq;
    public SkinnedMeshRenderer dropperLiq;
    public ParticleSystem psDrop;
    public bool naStore;
    
    [Space] public FIRSTlIQtRIGGER naohConfirm;
    
    [Header("speed")]
    public float increasSpeed;
    

    public TriggerSecondCuso cusoSign;
    [Space] public SkinnedMeshRenderer bluerRend;
    public ParticleSystem bluePs;
    public Renderer mainColor;
    [Space]

    private Color colWhite = Color.white;
    public Color pinkish;
    private float i;
    
    
    //healper Objs

    private bool _emterB;
    private bool _emteL;
    private bool _startB;
    private bool _startL;
    private int ic;

    [HideInInspector] public bool ended;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S") && !naStore && naohConfirm.naoh && !cusoSign.cuso4)
        {
            psDrop.Play();
            _emterB = true;
        }
        
        if (other.CompareTag("S") && cusoSign.cuso4)
        {
            bluePs.Play();
            _emteL = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("S") && !naStore)
        {
            psDrop.Stop();
            _emterB = false;
        }
        if (other.CompareTag("S") && cusoSign.cuso4)
        {
            bluePs.Stop();
            _emteL = false;
        }
    }

    private void Update()
    {
        if (_emterB != _startB && ic == 0)
        {
            StartCoroutine(startB());
            ic = 1;
        }

        if (_emteL && ic==0 && !_startL )
        {
            StartCoroutine(startL());
            ic = 1;
        }

        if (_startL)
        {
           
            if (mainLiq.fillPouint < 0.026f)
            {
                    mainLiq.fillPouint += Time.deltaTime * increasSpeed;
            }
            if (i < 1)
            {
                    i += Time.deltaTime * 0.4f;
            }
            Color lerp = Color.Lerp(colWhite, pinkish, i);
            mainColor.material.SetColor("sColor",lerp);
            mainColor.material.SetColor("fColor",lerp);
            mainColor.material.SetColor("lColor",lerp);

            if (i>=1 && !ended)
            {
                ended = true;
            }
        }
        
        if (_startB)
        {
            if (dropperLiq.GetBlendShapeWeight(0)<100 && !naStore && naohConfirm.naoh && !cusoSign.cuso4)
            {
                if (mainLiq.fillPouint < 0.0265f)
                {
                    mainLiq.fillPouint += Time.deltaTime * increasSpeed;
                }
            }
        }
    }

    IEnumerator startB()
    {
        yield return new WaitForSeconds(2.5f);
        _startB = _emterB;
        ic = 0;
    }
    IEnumerator startL()
    {
        yield return new WaitForSeconds(2.5f);
        _startL = true;
        ic = 0;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("S")&& !naStore && naohConfirm.naoh && !cusoSign.cuso4)
        {
            if (dropperLiq.GetBlendShapeWeight(0) < 100)
            {
                float fillPoint = dropperLiq.GetBlendShapeWeight(0) + Time.deltaTime * 15;
                dropperLiq.SetBlendShapeWeight(0,fillPoint);
            }

            if (dropperLiq.GetBlendShapeWeight(0) >= 100)
            {
                psDrop.Stop();
                dropperLiq.gameObject.SetActive(false);
                naStore = true;
            }
        }

        if (other.CompareTag("S") && cusoSign.cuso4)
        {
            if (bluerRend.GetBlendShapeWeight(0) < 100)
            {
                float fill = bluerRend.GetBlendShapeWeight(0) + Time.deltaTime * 15;
                bluerRend.SetBlendShapeWeight(0,fill);
            }
            if (bluerRend.GetBlendShapeWeight(0) >= 100)
            {
                bluePs.Stop();
                bluerRend.gameObject.SetActive(false);
                naStore = true;
            }
        }
    }
}
