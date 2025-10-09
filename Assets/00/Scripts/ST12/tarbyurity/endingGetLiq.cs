using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingGetLiq : MonoBehaviour
{
    public Transform thisLiq;
    public Renderer otherLiq;
    public bool lastbool;
    [Header("Speed Area")]
    public float reduceSpeed;
    public float redoxspd;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player2"))
        {
            if (otherLiq.material.GetFloat("_Fill") < 0.55f)
            {
                float fillpoint = otherLiq.material.GetFloat("_Fill") + Time.deltaTime * reduceSpeed;
                otherLiq.material.SetFloat("_Fill",fillpoint);
                thisLiq.localScale = new Vector3(thisLiq.localScale.x, thisLiq.localScale.y - Time.deltaTime * redoxspd, thisLiq.localScale.z);
            }
            if (otherLiq.material.GetFloat("_Fill") >= 0.55f && !lastbool)
            {
                lastbool = true;
            }
        }
    }
}
