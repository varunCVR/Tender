using System.Collections;
using UnityEngine;

public class Createpaste : MonoBehaviour
{
    public GameObject TickMark;
    public FillHClPipette ac;
    bool isTrue;
    void Update()
    {
        if(ac.isPaste)
        {
            if(transform.localScale.x <= .398f)
            {
                ac.isEmpty = true;
            }
        }

        if (isTrue)
        {
            if (transform.localScale.x <= .398f)
            {
                transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 1.5f, transform.localScale.y - Time.deltaTime * 2.5f, transform.localScale.z + Time.deltaTime * 1.5f);
                GetComponent<Renderer>().material.SetFloat("_Smoothness", .9f);
                GetComponent<Renderer>().material.SetFloat("_BumpScale", 1);
            }
            isTrue = false;
        }      

        if(transform.localScale.x >= .398f)
        {
            TickMark.SetActive(true);
            ac.Drops.Stop();
            ac.isPaste = false;
            ac.isEmpty = false;
            ac.Paste.SetActive(false);
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(Wait());
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "water")
        {
            isTrue = true;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
        ac.Drops.gameObject.SetActive(false);
        GetComponent<Createpaste>().enabled = false;
    }
}
