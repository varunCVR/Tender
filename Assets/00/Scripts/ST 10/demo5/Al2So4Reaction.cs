using System.Collections;
using UnityEngine;
using BNG;
public class Al2So4Reaction : MonoBehaviour
{
    GameObject MetalPlate;

    [HideInInspector]
    public bool isTrue, isMain;
    bool isFalse;


    private void Update()
    {
        if(isMain)
        {
            StartCoroutine(AfeteReaction());
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zn" || other.tag == "Fe" || other.tag == "Cu" || other.tag == "Al")
        {
            isTrue = false;
        }
    }
    IEnumerator AfeteReaction()
    {
        yield return new WaitForSeconds(30);
        MetalPlate.GetComponent<Grabbable>().enabled = true;
    }
}
