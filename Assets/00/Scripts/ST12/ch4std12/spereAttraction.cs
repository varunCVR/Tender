using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spereAttraction : MonoBehaviour
{
    public Transform magnetRL;
    public Transform magnetLR;
    public Transform p;
    public Transform n;

    public bool inverse;
    [Space] public Transform spere;
    public Transform right;
    public Transform left;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S"))
        {
            inverse = !inverse;
        }
    }

    private void Update()
    {
        if (!inverse)
        {
            magnetRL.rotation = Quaternion.Lerp(magnetRL.rotation,p.rotation,Time.deltaTime *5);
            magnetLR.rotation = magnetRL.rotation;
            spere.position = Vector3.Lerp(spere.position, right.position, Time.deltaTime);
        }
        if (inverse)
        {
            magnetRL.rotation = Quaternion.Lerp(magnetRL.rotation,n.rotation,Time.deltaTime *5);
            magnetLR.rotation = magnetRL.rotation;
            spere.position = Vector3.Lerp(spere.position, left.position, Time.deltaTime);
        }
        
    }
}
