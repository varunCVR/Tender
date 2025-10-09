using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class weight_meter : MonoBehaviour
{
    private float totalweight;
    public TextMeshProUGUI mText;
    public bool InNot;

    [Space]

    public float a;
    public float b;
    public float c;

    [HideInInspector] public bool mas_1;
    [HideInInspector] public bool mas_2;
    [HideInInspector] public bool mas_3;


    [Space]

    public TextMeshProUGUI A_first;
    public TextMeshProUGUI B_first;
    public TextMeshProUGUI C_first;

    private float aF_1;
    private float bF_1;
    private float cF_1;

    [Space]

    public TextMeshProUGUI A_sec;
    public TextMeshProUGUI B_sec;
    public TextMeshProUGUI C_sec;

    private float aF_2;
    private float bF_2;
    private float cF_2;

    [Space]

    public TextMeshProUGUI A_diff;
    public TextMeshProUGUI B_diff;
    public TextMeshProUGUI C_diff;

    private float diffA;
    private float diffB;
    private float diffC;
        private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("water2") ||other.CompareTag("water3")||other.CompareTag("water4"))
        {
            InNot = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("water2"))
        {
            if (other.GetComponent<Rigidbody>().mass == 1)
            {
                a = 0.96f;
            }
            if (other.GetComponent<Rigidbody>().mass == 2)
            {
                mas_1 = true;
                aF_1 = a;
                a = 1.02f;
            }
            if (other.GetComponent<Rigidbody>().mass == 3)
            {
                a = 1.08f;
                aF_2 = a;
            }
        }
        if (other.CompareTag("water3"))
        {
            if (other.GetComponent<Rigidbody>().mass == 1)
            {
                b = 1.10f;
            }
            if (other.GetComponent<Rigidbody>().mass == 2)
            {
                mas_2 = true;
                b = 1.12f;
                bF_1 = b;
            }
            if (other.GetComponent<Rigidbody>().mass == 3)
            {
                b = 1.19f;
                bF_2= b;
            }
        }
        if (other.CompareTag("water4"))
        {
            if (other.GetComponent<Rigidbody>().mass == 1)
            {
                c = 0.75f;
            }
            if (other.GetComponent<Rigidbody>().mass == 2)
            {
                mas_3 = true;
                c = 0.80f;
                cF_1 = c;
            }
            if (other.GetComponent<Rigidbody>().mass == 3)
            {
                c = 0.84f;
                cF_2   = c;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("water2") ||other.CompareTag("water3")||other.CompareTag("water4"))
        {
            InNot = false;
        }
        if (other.CompareTag("water2"))
        {
            a = 0;
        }
        if (other.CompareTag("water3"))
        {
            b = 0;
        }
        if (other.CompareTag("water4"))
        {
            c = 0;
        }
    }

    private void Update()
    {          
        textReader();
    }

    public void textReader()
    {

        float total = a + b + c;
        mText.text = total.ToString("0.00");

        diffA = Mathf.Abs(aF_1 - aF_2);
        diffB = Mathf.Abs(bF_1 - bF_2);
        diffC = Mathf.Abs(cF_1 - cF_2);



        A_first.text = aF_1.ToString("0.00");
        A_sec.text = aF_2.ToString("0.00");   
        A_diff.text = diffA.ToString("0.00");
        
        B_first.text= bF_1.ToString("0.00");
        B_sec.text = bF_2.ToString("0.00");
        B_diff.text = diffB.ToString("0.00");

        C_first.text= cF_1.ToString("0.00");
        C_sec.text = cF_2.ToString("0.00");
        C_diff.text= diffC.ToString("0.00");
    }
}
