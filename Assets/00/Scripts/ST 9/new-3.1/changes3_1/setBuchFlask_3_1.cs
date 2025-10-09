    using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class setBuchFlask_3_1 : MonoBehaviour
{
    public Transform buchPosition;
    private GameObject buchObj;
    public bool buchSign;

    [Header("AfterBuchActivation")] 
    public GameObject RealFlask;
    public GameObject fakeFlask;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buch"))
        {
            buchObj = other.gameObject;
            other.GetComponent<Grabbable>().enabled = false;
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<Collider>());
            
            buchSign = true;
        }
    }

    private void Update()
    {
        if (buchSign && buchObj.transform.localPosition != buchPosition.localPosition) 
        {
            buchObj.transform.localPosition = Vector3.MoveTowards(buchObj.transform.localPosition,
                buchPosition.localPosition, Time.deltaTime);
            buchObj.transform.rotation = Quaternion.Lerp(buchObj.transform.rotation, buchPosition.rotation, Time.deltaTime * 10);
        }

        if (buchSign && buchObj.transform.localPosition == buchPosition.localPosition && fakeFlask.activeInHierarchy)
        {
            RealFlask.SetActive(true);
            fakeFlask.SetActive(false);
        }
    } 
}
