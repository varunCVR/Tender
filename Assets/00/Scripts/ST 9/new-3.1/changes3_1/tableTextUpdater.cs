using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tableTextUpdater : MonoBehaviour
{
    public massReadUpdate massSign;

    public TextMeshProUGUI txt1;
    public TextMeshProUGUI txt2;

    private void Update()
    {
        if (massSign.sign)
        {
            txt1.text = "165.4";
        }
        if (massSign.sign1)
        {
            txt2.text = "165.4";
        }
    }
}
