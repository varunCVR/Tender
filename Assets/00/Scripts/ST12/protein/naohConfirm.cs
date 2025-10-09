using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class naohConfirm : MonoBehaviour
{
    public Collider naoh_Box;
    public Collider cuso_Box;

    public mainTriggerEnter mainConfirm;
    private void Update()
    {
        if (mainConfirm.naStore & !cuso_Box.enabled)
        {
            naoh_Box.enabled = false;
            cuso_Box.enabled = true;
        }
    }
}
