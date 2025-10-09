using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  BNG;

public class clipHolder : MonoBehaviour
{
    public GameObject h1, h2;
    public clipHoldingScript holder;
    public Collider grabber;
    /*public override void OnTrigger(float triggerValue)
    {
        if (triggerValue > 0)
        {
            doWork(triggerValue);
        }
        else
        {
            doRest();
        }

        base.OnTrigger(triggerValue);
    }*/

    public void doWork(float triggerValue)
    {
        holder.isPos = true;
        h1.transform.localEulerAngles = new Vector3(0, 0, -2);
        h2.transform.localEulerAngles = new Vector3(0, 0, 2);
    }

    public void doRest()
    {
        holder.isPos = false;
        h1.transform.localEulerAngles = new Vector3(0, 0, -5);
        h2.transform.localEulerAngles = new Vector3(0, 0, 5);
    }
}
