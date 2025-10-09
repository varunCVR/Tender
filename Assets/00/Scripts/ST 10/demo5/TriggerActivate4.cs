using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivate4 : MonoBehaviour
{
    public GameObject[] Liquid;
    public AudioSource audioSource;
    public AudioClip Clip;

    float fill1, fill2, fill3, fill4;

    bool isTrue, isFalse;

    private void Update()
    {
        fill1 = Liquid[0].GetComponent<Renderer>().material.GetFloat("_Fill");
        fill2 = Liquid[1].GetComponent<Renderer>().material.GetFloat("_Fill");
        fill3 = Liquid[2].GetComponent<Renderer>().material.GetFloat("_Fill");
        fill4 = Liquid[3].GetComponent<Renderer>().material.GetFloat("_Fill");

        if (fill1 >= .1f && fill2 >= .1f && fill3 >= .1f && fill4 >= .1f)
        {
            foreach(GameObject obj in Liquid)
            {
                obj.GetComponent<Collider>().enabled = true;
                isTrue = true;
            }
        }

        if(isTrue && !isFalse)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(Clip);
            isFalse = true;
        }
    }
}
