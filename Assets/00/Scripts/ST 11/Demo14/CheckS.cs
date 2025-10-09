using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckS : MonoBehaviour
{
    public GameObject Kasnaliliq;
    public GameObject Clock;
    public Color col1;

    public bool isTrue, isCol;

    float Speed;

    private void Update()
    {
        if (isCol)
        {
            Color lerpa = Color.Lerp(Kasnaliliq.GetComponent<Renderer>().material.GetColor("_LCol"), col1, Time.deltaTime * Speed);
            Color lerpb = Color.Lerp(Kasnaliliq.GetComponent<Renderer>().material.GetColor("_SCol"), col1, Time.deltaTime * Speed);
            Kasnaliliq.GetComponent<Renderer>().material.SetColor("_LCol", lerpa);
            Kasnaliliq.GetComponent<Renderer>().material.SetColor("_SCol", lerpb);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Clock.GetComponent<DigitalClock>().enabled = true;
            isTrue = true;

            Speed = .045f;

            StartCoroutine(Wait());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Finish")
        {
            Clock.GetComponent<DigitalClock>().enabled = false;
            StopCoroutine(Wait());

            Speed = 0;

            isTrue = false;
            isCol = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        isCol = true;
    }
}
