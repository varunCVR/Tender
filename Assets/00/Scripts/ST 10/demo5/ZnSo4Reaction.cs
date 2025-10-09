using System.Collections;
using UnityEngine;
using BNG;

public class ZnSo4Reaction : MonoBehaviour
{
    GameObject MetalPlate, Al, AlReaction;

    [HideInInspector]
    public bool isTrue, isMain;
    bool isAlReaction, isReact;
    bool isFalse;

    Color ClAl;
    float speed;

    private void Update()
    {
        if (isMain)
        {
            StartCoroutine(AfeteReaction());
            if (isReact)
            {
                speed = .034f;
                if (ClAl.a < 1)
                {
                    ClAl.a += Time.deltaTime * speed;
                }
                AlReaction.GetComponent<Renderer>().material.color = ClAl;
            }
        }

        if(isTrue)
        {
            if (MetalPlate && MetalPlate.GetComponent<Rigidbody>().collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
            {           
                if(!isFalse)
                {
                    MetalPlate.GetComponent<Grabbable>().enabled = false;
                    isFalse = true;
                }
        
                if(isAlReaction)
                {
                    isReact = true;
                }
            }
        }      
        else
        {
            if(MetalPlate)
            {
                MetalPlate.GetComponent<Grabbable>().enabled = true;
            }          
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Zn" || other.tag == "Fe" || other.tag == "Cu" || other.tag == "Al")
        {
            MetalPlate = other.gameObject;
            isTrue = true;
        }

        if(other.tag == "Al")
        {
            Al = other.gameObject;
           
            if (Al)
            {
                AlReaction = Al.transform.FindChild("Al + ZnSo4").gameObject;
                ClAl = AlReaction.GetComponent<Renderer>().material.color;
            }

            isAlReaction = true;
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
    }
    IEnumerator AfeteReaction()
    {
        yield return new WaitForSeconds(30);
        MetalPlate.GetComponent<Grabbable>().enabled = true;
    }
}
