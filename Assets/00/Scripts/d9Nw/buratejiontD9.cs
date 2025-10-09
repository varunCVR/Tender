using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buratejiontD9 : MonoBehaviour
{
    public bool burate_Joint;
    public GameObject Next_Trigger;

    public Transform locBurate;
    public GameObject burateOrg;
    public GameObject burateGrb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buch"))
        {
            burate_Joint = true;
        }
    }

    private void Update()
    {
        if (burate_Joint && burateGrb!=null)
        {
            burateGrb.transform.position = locBurate.position;
            burateGrb.transform.rotation = locBurate.rotation;
            if (burateGrb.GetComponent<Rigidbody>().useGravity)
            {
                burateOrg.SetActive(true);
                Next_Trigger.SetActive(true);

                burateGrb.SetActive(false);
                Destroy(burateGrb,1f);
            }
        }
    }
}
     