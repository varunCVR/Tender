using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class glassX_set : MonoBehaviour
{

    public Transform s_pos;
    public bool SglaaSignal;
    private GameObject colObj;

    [Header("NextActivation")] public GameObject rope;
    public GameObject realBuch;
    public GameObject fakeBuch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pani"))
        {
            colObj = other.gameObject;

            other.GetComponent<Grabbable>().enabled = false;
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<Collider>());
            
            
            SglaaSignal = true;
            rope.SetActive(true);
            realBuch.SetActive(true);
            fakeBuch.SetActive(false);
        }
    }

    private void Update()
    {
        if (SglaaSignal && colObj.transform.localPosition != s_pos.localPosition)
        {
            colObj.transform.localPosition =
                Vector3.MoveTowards(colObj.transform.localPosition, s_pos.localPosition, Time.deltaTime);
            colObj.transform.rotation = Quaternion.Lerp(colObj.transform.rotation, s_pos.rotation, Time.deltaTime * 10);
        }
    }
}
