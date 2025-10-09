using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixkas14 : MonoBehaviour
{
    public GameObject holdTrigger;

    GameObject kasnali;

    bool isTrue;
    private void Update()
    {
        if(isTrue && kasnali)
        {
            kasnali.transform.parent = null;
            holdTrigger.SetActive(false);
            kasnali.transform.position = transform.position;
            kasnali.transform.rotation = transform.rotation;
            isTrue = false;          
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "patti")
        {
            kasnali = other.gameObject;
            isTrue = true;
        }
    }
}
