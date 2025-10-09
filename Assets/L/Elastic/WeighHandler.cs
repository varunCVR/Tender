using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighHandler : MonoBehaviour
{
    public bool SetHeight;
    public Rigidbody rb;
    float weight = 1f;
    public float speed;
    public float maxWeight;
    public float minWeight;
    public float weightIncrementDecrement;

    public GameObject targetObj = null;
    Rigidbody targetRigidbody = null;

    public Grabber leftGrabber;
    public Grabber rightGrabber;


    public bool grabbed;
    public string grabbedObjName;
    bool correctTheRotation;
    public LineRenderer lr;

    public Transform upperPos;
    public Transform downPos;

    private void Update()
    {
        
        if (targetObj != null && !grabbed)
        {
             targetObj.transform.position = new Vector3(rb.position.x,rb.position.y,rb.position.z);
            targetObj.transform.eulerAngles = new Vector3(0, 270f, 0);
           /* lr.SetPosition(0, downPos.position);
            lr.SetPosition(1, upperPos.position);
*/
            // targetObj.transform.position = Vector3.MoveTowards(targetObj.transform.position, rb.position,Time.deltaTime*speed);
        }

      
        if (rightGrabber.HeldGrabbable || leftGrabber.HeldGrabbable)
        {

            if (rightGrabber.HeldGrabbable.name == grabbedObjName)
            {
                grabbed = true;
            }
        }
        else
        {
            grabbed = false;
        }
       /* if (correctTheRotation)
        {
            
        }*/
    }
    public void IncreaseWeight(float t)
    {
        weight += t;
        if (weight >= maxWeight)
        {
            weight = maxWeight;
        }
        rb.mass = weight;
    }
    public void DecreaseWeight(float t)
    {
        weight -= t;
        if (weight <= minWeight)
        {
            weight = minWeight;
        }
        rb.mass = weight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("K"))
        {

            if(targetObj == null)
            {
                targetObj = other.gameObject;
                targetRigidbody = targetObj.GetComponent<Rigidbody>();
                targetRigidbody.useGravity = false;
                correctTheRotation = true;
                float weight = other.GetComponent<WeightHolder>().weight;
                IncreaseWeight(weight*2);
                grabbedObjName = other.gameObject.name;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("K"))
        {
            if (targetObj != null && !grabbed)
            {
               targetRigidbody.useGravity = false;
            }else if(targetObj != null && grabbed)
            {
                if(rightGrabber.HeldGrabbable.name == grabbedObjName)
                {
                    targetRigidbody.useGravity = true;
                }
                else
                {
                    targetRigidbody.useGravity = false;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("K"))
        {
            if (targetObj != null)
            {
                correctTheRotation = false;
                targetRigidbody.useGravity = true;
                targetRigidbody = null;
                targetObj = null;
                grabbedObjName = null;
                float weight = other.GetComponent<WeightHolder>().weight;
                DecreaseWeight(weight*2);
            }
        }
    }
}
