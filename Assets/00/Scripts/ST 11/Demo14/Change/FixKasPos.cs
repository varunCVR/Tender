using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixKasPos : MonoBehaviour
{
    public GameObject holdTrigger;
    public GameObject kasnali;

    bool isTrue;

    private void Update()
    {
        if (isTrue && kasnali)
        {
            kasnali.transform.parent = transform.parent;
            holdTrigger.SetActive(false);
            kasnali.transform.position = transform.position;
            kasnali.transform.rotation = transform.rotation;
            isTrue = false;
        }

        if (kasnali.transform.position == transform.position)
        {
            GetComponent<Collider>().enabled = false;
            StartCoroutine(Wait());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "patti")
        {       
            if(transform.childCount == 0)
            {
                isTrue = true;
            }       
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        holdTrigger.SetActive(true);
    }
}
