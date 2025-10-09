using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSugar : MonoBehaviour
{  
    public GameObject Clock;
    public Color col1, col2, col3, col4;

    public GameObject Kasnaliliq, Kasnaliliq2, Kasnaliliq3, Kasnaliliq4;

    [HideInInspector]
    public bool isTrue, isCol, isCol2, isCol3, isCol4;

    float Speed;

    [HideInInspector]
    public int a, b, c, d;

    bool isf1, isf2, isf3, isf4;

    private void Update()
    {
        if (isCol)
        {
            Color lerpa = Color.Lerp(Kasnaliliq.GetComponent<Renderer>().material.GetColor("_LCol"), col1, Time.deltaTime * Speed);
            Color lerpb = Color.Lerp(Kasnaliliq.GetComponent<Renderer>().material.GetColor("_SCol"), col1, Time.deltaTime * Speed);
            Kasnaliliq.GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
            Kasnaliliq.GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
        }

        if (isCol2)
        {
            Color lerpa = Color.Lerp(Kasnaliliq2.GetComponent<Renderer>().material.GetColor("_LCol"), col2, Time.deltaTime * Speed);
            Color lerpb = Color.Lerp(Kasnaliliq2.GetComponent<Renderer>().material.GetColor("_SCol"), col2, Time.deltaTime * Speed);
            Kasnaliliq2.GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
            Kasnaliliq2.GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
        }

        if (isCol3)
        {
            Color lerpa = Color.Lerp(Kasnaliliq3.GetComponent<Renderer>().material.GetColor("_LCol"), col3, Time.deltaTime * Speed);
            Color lerpb = Color.Lerp(Kasnaliliq3.GetComponent<Renderer>().material.GetColor("_SCol"), col3, Time.deltaTime * Speed);
            Kasnaliliq3.GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
            Kasnaliliq3.GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
        }

        if (isCol4)
        {
            Color lerpa = Color.Lerp(Kasnaliliq4.GetComponent<Renderer>().material.GetColor("_LCol"), col4, Time.deltaTime * Speed);
            Color lerpb = Color.Lerp(Kasnaliliq4.GetComponent<Renderer>().material.GetColor("_SCol"), col4, Time.deltaTime * Speed);
            Kasnaliliq4.GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
            Kasnaliliq4.GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "N")
        {
            if(!isf1)
            {
                a += 1;
                isf1 = true;
            }

            if(b >= 1 || c >= 1 || d >= 1 && a < 1)
            {
                Clock.GetComponent<DigitalClock>().sec = 0;
                Clock.GetComponent<DigitalClock>().min = 0;
                Clock.GetComponent<DigitalClock>().Speed = 4.5f;
            }
           
            Clock.GetComponent<DigitalClock>().enabled = true;
            isTrue = true;

            Speed = .08f;

            StartCoroutine(Wait());
        }

        if (other.tag == "S")
        {
            if (!isf2)
            {
                b += 1;
                isf2 = true;
            }

            if (a >= 1 || c >= 1 || d >=1 && b < 1)
            {
                Clock.GetComponent<DigitalClock>().sec = 0;
                Clock.GetComponent<DigitalClock>().min = 0;
                Clock.GetComponent<DigitalClock>().Speed = 4.5f;
            }
           
            Clock.GetComponent<DigitalClock>().enabled = true;
            isTrue = true;

            Speed = .08f;

            StartCoroutine(Wait2());
        }

        if (other.tag == "X")
        {
            if (!isf3)
            {
                c += 1;
                isf3 = true;
            }

            if (a >= 1 || b >= 1 || d >= 1 && c < 1)
            {
                Clock.GetComponent<DigitalClock>().sec = 0;
                Clock.GetComponent<DigitalClock>().min = 0;
                Clock.GetComponent<DigitalClock>().Speed = 4.5f;
            }

            Clock.GetComponent<DigitalClock>().enabled = true;
            isTrue = true;

            Speed = .08f;

            StartCoroutine(Wait3());
        }

        if (other.tag == "K")
        {
            if (!isf4)
            {
                d += 1;
                isf4 = true;
            }

            if (a >= 1 || b >= 1 || c >= 1 && d < 1)
            {
                Clock.GetComponent<DigitalClock>().sec = 0;
                Clock.GetComponent<DigitalClock>().min = 0;
                Clock.GetComponent<DigitalClock>().Speed = 4.5f;
            }

            Clock.GetComponent<DigitalClock>().enabled = true;
            isTrue = true;

            Speed = .08f;

            StartCoroutine(Wait4());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "N")
        {
            Clock.GetComponent<DigitalClock>().enabled = false;
            StopCoroutine(Wait());

            Speed = 0;

            isTrue = false;
            isCol = false;
        }

        if (other.tag == "S")
        {
            Clock.GetComponent<DigitalClock>().enabled = false;
            StopCoroutine(Wait2());

            Speed = 0;

            isTrue = false;
            isCol2 = false;
        }

        if (other.tag == "X")
        {
            Clock.GetComponent<DigitalClock>().enabled = false;
            StopCoroutine(Wait3());

            Speed = 0;

            isTrue = false;
            isCol3 = false;
        }

        if (other.tag == "K")
        {
            Clock.GetComponent<DigitalClock>().enabled = false;
            StopCoroutine(Wait4());

            Speed = 0;

            isTrue = false;
            isCol4 = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        isCol = true;
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(2);
        isCol2 = true;
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(2);
        isCol3 = true;
    }
    IEnumerator Wait4()
    {
        yield return new WaitForSeconds(2);
        isCol4 = true;
    }
}
