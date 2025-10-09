using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funel_fix_on_Location : MonoBehaviour
{
    public bool confirm;
    public GameObject realFunal;
    public GameObject funalLocation;

    [HideInInspector] public bool removefunal;

    public naoh_enter_trigger for5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("X"))
        {
            confirm = true;
        }
    }
    
    private void Update()
    {
        if (confirm && !for5.for_stp5)
        {
            realFunal.transform.eulerAngles = Vector3.zero;
            realFunal.transform.position = funalLocation.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("X"))
        {
            removefunal = true;
            confirm = false;
        }
    }
}
