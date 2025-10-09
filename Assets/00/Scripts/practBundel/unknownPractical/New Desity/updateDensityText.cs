using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class updateDensityText : MonoBehaviour
{
    public int n;
    public int n1;
    public int s;
    public int s1;
    public int e;
    public int g;
    public int emptyB;
    public int emptyB1;
    public int total;
    public int total1;

    public Text totalWeight;
    public Text totalWeight1;

    [Space] 
    public bool nWbicker;
    public bool sWbicker;
    public bool eWbicker;

    public TextMeshProUGUI bbeakerText;
    public TextMeshProUGUI bsaltWaterText;
    public TextMeshProUGUI bclearWaterText;

      public TextMeshProUGUI wbeakerText;
    public TextMeshProUGUI wsaltWaterText;
    public TextMeshProUGUI wclearWaterText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            nWbicker = true;
            n = 40 + 165;
            n1 = 40;
          //  bclearWaterText.text = "205";
          //  wclearWaterText.text = "40";

        }
        if (other.CompareTag("S"))
        {
            sWbicker = true;
            s = 60 + 165;
            s1 = 60;

           // bsaltWaterText.text = "225";
           // wsaltWaterText.text = "60";
        }
        if (other.CompareTag("Event"))
        {
            e = 300;
        }
        if (other.CompareTag("glow"))
        {
            g = 1200;
        }
        if (other.CompareTag("FC"))
        {
            eWbicker = true;
            emptyB = 165;
            emptyB1 = 0;

          //  bbeakerText.text = string.Empty;
           // bbeakerText.text = "165";
           // wbeakerText.text = "00";
        }
       
    } 
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            n = 0;
            n1 = 0;
        }
        if (other.CompareTag("S"))
        {
            s = 0;
            s1 = 0;
        }
        if (other.CompareTag("Event"))
        {
            e = 0;
        }
        if (other.CompareTag("glow"))
        {
            g = 0;
        }
        if (other.CompareTag("FC"))
        {
            emptyB = 0;
            emptyB1 = 0;
        }
    }

    private void Update()
    {
        total = n + s + e + g + emptyB;
        total1 = n1 + s1 + emptyB1;
        totalWeight.text = total.ToString("00");
        totalWeight1.text = total1.ToString("00");
    }
}
