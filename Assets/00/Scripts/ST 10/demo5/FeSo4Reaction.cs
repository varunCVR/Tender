using System.Collections;
using UnityEngine;
using BNG;
public class FeSo4Reaction : MonoBehaviour
{
    public Color Colorless;

    GameObject MetalPlate;
    GameObject Al, AlReaction;
    GameObject Zn, ZnReaction;

    [HideInInspector]
    public bool isTrue, isMain;
    bool isAlReaction, isAlReact;
    bool isZnReaction, isZnReact;
    bool isFalse;

    Color ClAl, ClZn;
    float speed;

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
                    isAlReact = true;
                }

                if (isZnReaction)
                {
                    isZnReact = true;
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
                AlReaction = Al.transform.FindChild("Al + FeSo4").gameObject;
                ClAl = AlReaction.GetComponent<Renderer>().material.color;
            }

            isAlReaction = true;
        }

        if (other.tag == "Zn")
        {
            Zn = other.gameObject;

            if (Zn)
            {
                ZnReaction = Zn.transform.FindChild("Zn + FeSo4").gameObject;
                ClZn = ZnReaction.GetComponent<Renderer>().material.color;
            }

            isZnReaction = true;
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
            speed = 0;
        }

        if (other.tag == "Zn")
        {
            isZnReaction = false;
            speed = 0;
        }
    }
    IEnumerator AfeteReaction()
    {
        yield return new WaitForSeconds(30);
        MetalPlate.GetComponent<Grabbable>().enabled = true;
    }
}
