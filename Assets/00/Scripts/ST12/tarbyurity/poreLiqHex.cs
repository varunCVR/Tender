using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poreLiqHex : MonoBehaviour
{
    public Transform hexWater;
    public Renderer hexPoreLiq;
    public float poreSpeed;
    public float lossSpeed;
    public bool hexPored;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("water3") && other.GetComponent<Rigidbody>().mass ==1)
        {
            if (hexPoreLiq.material.GetFloat("_Fill") < 0.55f) {
                float fillPoint = hexPoreLiq.material.GetFloat("_Fill") + Time.deltaTime * poreSpeed;
                hexPoreLiq.material.SetFloat("_Fill",fillPoint);
                hexWater.transform.localScale = new Vector3(hexWater.transform.localScale.x,
                    hexWater.transform.localScale.y + Time.deltaTime *lossSpeed, hexWater.transform.localScale.z);
            }
            else if (hexPoreLiq.material.GetFloat("_Fill")>=0.55f && !hexPored) {
                hexPored = true;
            }
        }
    }
}
