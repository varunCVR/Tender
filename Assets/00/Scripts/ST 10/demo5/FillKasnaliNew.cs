using System.Collections;
using UnityEngine;

public class FillKasnaliNew : MonoBehaviour
{
    public GameObject Liqu;

    public string Tag;

    bool isTrue;

    float fill;
    private void Start()
    {
        fill = Liqu.GetComponent<Renderer>().material.GetFloat("_Fill");
    }
    private void Update()
    {
        Liqu.GetComponent<Renderer>().material.SetFloat("_Fill", fill);
        if(isTrue)
        {
            if(fill <= .1f)
            {
                fill += Time.deltaTime * .018f;
            }
        }

        if(fill >= .1f)
        {
            isTrue = false;
            GetComponent<Collider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tag)
        {
            if(other.GetComponent<NewFill>().Pipette.GetComponent<pipett25ML>().fillp > -1.2f)
            {
                other.GetComponent<NewFill>().isEmpty = true;
                StartCoroutine(WaitForFill());
            }      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tag)
        {
            other.GetComponent<NewFill>().isEmpty = false;
            StartCoroutine(StopForFill());
        }
    }
    IEnumerator WaitForFill()
    {
        yield return new WaitForSeconds(.74f);
        isTrue = true;
    }
    IEnumerator StopForFill()
    {
        yield return new WaitForSeconds(.74f);
        isTrue = false;
    }
}
