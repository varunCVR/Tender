using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
public class CuSo4Reaction : MonoBehaviour
{
    public Color Colorless, Green;

    GameObject MetalPlate;
    GameObject Al, AlReaction;
    GameObject Zn, ZnReaction;
    GameObject Fe, FeReaction;

    ParticleSystem Bubble, AlBubble, ZnBubble;

    [HideInInspector]
    public bool isTrue, isMain;
    bool isAlReaction, isAlReact;
    bool isZnReaction, isZnReact;
    bool isFeReaction, isFeReact;
    bool isFalse;

    Color ClAl, ClZn, ClFe;
    float speed;

    [System.Obsolete]
    private void Start()
    {
        Bubble = transform.FindChild("Bubble").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(isMain)
        {
            StartCoroutine(AfeteReaction());
            if (isAlReact)
            {
                speed = .034f;
                if (ClAl.a < 1)
                {
                    ClAl.a += Time.deltaTime * speed;
                }
                AlReaction.GetComponent<Renderer>().material.color = ClAl;

                Color lerpa = Color.Lerp(GetComponent<Renderer>().material.GetColor("_LCol"), Colorless, Time.deltaTime * speed * 3f);
                Color lerpb = Color.Lerp(GetComponent<Renderer>().material.GetColor("_SCol"), Colorless, Time.deltaTime * speed * 3f);
                GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
                GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
            }

            if (isZnReact)
            {
                speed = .034f;
                if (ClZn.a < 1)
                {
                    ClZn.a += Time.deltaTime * speed;
                }
                ZnReaction.GetComponent<Renderer>().material.color = ClZn;

                Color lerpa = Color.Lerp(GetComponent<Renderer>().material.GetColor("_LCol"), Colorless, Time.deltaTime * speed * 3f);
                Color lerpb = Color.Lerp(GetComponent<Renderer>().material.GetColor("_SCol"), Colorless, Time.deltaTime * speed * 3f);
                GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
                GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
            }

            if (isFeReact)
            {
                speed = .034f;
                if (ClFe.a < 1)
                {
                    ClFe.a += Time.deltaTime * speed;
                }
                FeReaction.GetComponent<Renderer>().material.color = ClFe;

                Color lerpa = Color.Lerp(GetComponent<Renderer>().material.GetColor("_LCol"), Green, Time.deltaTime * speed * 3f);
                Color lerpb = Color.Lerp(GetComponent<Renderer>().material.GetColor("_SCol"), Green, Time.deltaTime * speed * 3f);
                GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
                GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
            }
        }
   
        if (isTrue)
        {
            if (MetalPlate && MetalPlate.GetComponent<Rigidbody>().collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
            {
                if (!isFalse)
                {
                    MetalPlate.GetComponent<Grabbable>().enabled = false;
                    isFalse = true;
                }

                if (isAlReaction)
                {
                    StartCoroutine(WaitForAlReaction());
                }

                if (isZnReaction)
                {
                    StartCoroutine(WaitForZnReaction());
                }

                if (isFeReaction)
                {
                    isFeReact = true;
                }
            }
        }
        else
        {
            if (MetalPlate)
            {
                MetalPlate.GetComponent<Grabbable>().enabled = true;
            }
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zn" || other.tag == "Fe" || other.tag == "Cu" || other.tag == "Al")
        {
            MetalPlate = other.gameObject;
            isTrue = true;
        }

        if (other.tag == "Al")
        {
            Al = other.gameObject;

            if (Al)
            {
                AlReaction = Al.transform.FindChild("Al + CuSo4").gameObject;
                ClAl = AlReaction.GetComponent<Renderer>().material.color;
                AlBubble = Al.transform.FindChild("AlBubble").GetComponent<ParticleSystem>();
            }

            isAlReaction = true;
        }

        if (other.tag == "Zn")
        {
            Zn = other.gameObject;

            if (Zn)
            {
                ZnReaction = Zn.transform.FindChild("Zn + CuSo4").gameObject;
                ClZn = ZnReaction.GetComponent<Renderer>().material.color;
                ZnBubble = Zn.transform.FindChild("ZnBubble").GetComponent<ParticleSystem>();
            }

            isZnReaction = true;
        }

        if (other.tag == "Fe")
        {
            Fe = other.gameObject;

            if (Fe)
            {
                FeReaction = Fe.transform.FindChild("Fe + CuSo4").gameObject;
                ClFe = FeReaction.GetComponent<Renderer>().material.color;
            }

            isFeReaction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zn" || other.tag == "Fe" || other.tag == "Cu" || other.tag == "Al")
        {
            isTrue = false;
        }

        if (other.tag == "Al")
        {
            isAlReaction = false;
            AlBubble.gameObject.SetActive(false);
            Bubble.gameObject.SetActive(false);
            speed = 0;
        }
       
        if (other.tag == "Zn")
        {
            isZnReaction = false;
            ZnBubble.gameObject.SetActive(false);
            Bubble.gameObject.SetActive(false);
            speed = 0;
        }
        
        if (other.tag == "Fe")
        {
            isFeReaction = false;
            speed = 0;
        }
    }
    IEnumerator WaitForAlReaction()
    {
        isAlReact = true;
        yield return new WaitForSeconds(5);
        AlBubble.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        Bubble.gameObject.SetActive(true);
        yield return new WaitForSeconds(20);
        AlBubble.gameObject.SetActive(false);
        Bubble.gameObject.SetActive(false);
    }
    IEnumerator WaitForZnReaction()
    {
        isZnReact = true;
        yield return new WaitForSeconds(5);
        ZnBubble.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        Bubble.gameObject.SetActive(true);
    }

    IEnumerator AfeteReaction()
    {
        yield return new WaitForSeconds(30);
        if (ZnBubble)
        {
            ZnBubble.Stop();
            ZnBubble.gameObject.SetActive(false);
        }

        if (AlBubble)
        {
            AlBubble.Stop();
            AlBubble.gameObject.SetActive(false);
        }

        Bubble.Stop();
        Bubble.gameObject.SetActive(false);
        MetalPlate.GetComponent<Grabbable>().enabled = true;
    }
}
