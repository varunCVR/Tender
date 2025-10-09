using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLtoF : MonoBehaviour
{
    public for_testtube bollConfirm;
    public GameObject activate;
    public GameObject D_activate;
    private bool stp;
    private void Update()
    {
        if (bollConfirm.endBool && !stp)
        {
            StartCoroutine(timActivate());
            stp = true;
        }
    }
    IEnumerator timActivate()
    {
        yield return new WaitForSeconds(1);
        activate.SetActive(true);
        D_activate.SetActive(false);
    }
}
