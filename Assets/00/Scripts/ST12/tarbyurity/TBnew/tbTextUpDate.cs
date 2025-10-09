using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tbTextUpDate : MonoBehaviour
{
    public newTbmetr texUpdate;

    public TextMeshProUGUI f1_1;
    public TextMeshProUGUI f1_2;
    public TextMeshProUGUI f1_3;

    public TextMeshProUGUI s1_1;
    public TextMeshProUGUI s1_2;
    public TextMeshProUGUI s1_3;
    
    public TextMeshProUGUI f2_1;
    public TextMeshProUGUI f2_2;
    public TextMeshProUGUI f2_3;
    
    public TextMeshProUGUI s2_1;
    public TextMeshProUGUI s2_2;
    public TextMeshProUGUI s2_3;
    
    public TextMeshProUGUI final1;
    public TextMeshProUGUI final2;
    public TextMeshProUGUI final3;
    
    
    private void Update()
    {
        if (texUpdate.i ==0)
        {
            if (texUpdate.w)
            {
                f1_1.text = "05.30";
            }
            if (texUpdate.s)
            {
                f1_2.text = "29.37";
            } 
            if (texUpdate.c)
            {
                f1_3.text = "25.40";
            }
        }

        if (texUpdate.i==1)
        {
            if (texUpdate.w)
            {
                s1_1.text = "0.00";
                f2_1.text = "0.00";
            }
            if (texUpdate.s)
            {
                s1_2.text = "35.00";
                f2_2.text = "35.00";
            } 
            if (texUpdate.c)
            {
                s1_3.text = "26.25";
                f2_3.text = "26.25";
            }
        }

        if (texUpdate.i ==2)
        {
            if (texUpdate.w)
            {
                s2_1.text = "0.00";
                final1.text = "0.00";
            }
            if (texUpdate.s)
            {
                s2_2.text = "40.00";
                final2.text = "40.00";
            } 
            if (texUpdate.c)
            {
                s2_3.text = "27.00";
                final3.text = "27.00";
            }
        }
    }
}
