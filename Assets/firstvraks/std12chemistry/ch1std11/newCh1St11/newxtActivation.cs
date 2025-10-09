using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newxtActivation : MonoBehaviour
{
    public dropperFillFlask signL;

    public GameObject flaskReal;
    public GameObject flaskFake;
    private void Update()
    {
        if (signL.falskEnding && !flaskReal.activeInHierarchy) {
            flaskFake.SetActive(false);
            flaskReal.SetActive(true);
        }
    }
}
