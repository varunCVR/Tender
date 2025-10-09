using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burateEnter : MonoBehaviour
{
    public GameObject realBurate;
    public GameObject fackBurate;
    public bool burateBool;
    public GameObject triggerBurate_garni_mate;
    public GameObject fanal_trigger;
    public GameObject enter_kmno4_trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FC"))
        {
            fackBurate.SetActive(false);
            realBurate.SetActive(true);
            triggerBurate_garni_mate.SetActive(true);
            burateBool = true;
            fanal_trigger.SetActive(true);
            enter_kmno4_trigger.SetActive(true);
        }
    }

    private void Update()
    {
        if (fackBurate.GetComponent<Rigidbody>().useGravity && burateBool)
        {
            Destroy(fackBurate);
            Destroy(this.gameObject);
        }
    }
}
