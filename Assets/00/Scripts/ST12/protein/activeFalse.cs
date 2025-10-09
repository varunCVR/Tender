using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeFalse : MonoBehaviour
{
    public mainTriggerEnter endingBool;

    public GameObject activate;
    public GameObject de_activate;
    
    private bool stp;
    private void Update()
    {
        if (endingBool.ended && !stp)
        {
            StartCoroutine(timActivate());
            stp = true;
        }
    }

    IEnumerator timActivate()
    {
        yield return new WaitForSeconds(1);
        activate.SetActive(true);
        de_activate.SetActive(false);
    }
}
