using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naoh_enter_trigger : MonoBehaviour
{
    private bool entered;
    public Renderer in_burrate;
    public Renderer in_bikker;
    public ParticleSystem kmno4_ps;
    public ParticleSystem snd_kmno4_ps;
    public GameObject step_2;
    public GameObject onlyshow;

    [HideInInspector] public bool for_stp5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Al"))
        {
            entered = true;
            kmno4_ps.Play();
            snd_kmno4_ps.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Al"))
        {
            entered = false;
            kmno4_ps.Stop();
            snd_kmno4_ps.Stop();
        }
    }
    
    private void Update()
    {
        if (entered)
        {
            StartCoroutine(fillburate());
            if (in_bikker.material.GetFloat("FillArea") > 0.05)
            {
                float fill = in_bikker.material.GetFloat("FillArea") - Time.deltaTime * 0.05f;
                in_bikker.material.SetFloat("FillArea",fill);
            }
        }
    }

    IEnumerator fillburate()
    {
        yield return new WaitForSeconds (1.8f);
        if (in_burrate.material.GetFloat("FillArea") < 0.4)
        {
            float fill = in_burrate.material.GetFloat("FillArea") + Time.deltaTime * 0.04f;
            in_burrate.material.SetFloat("FillArea",fill);
        }
        else
        {
            for_stp5 = true;
            kmno4_ps.Stop();
            snd_kmno4_ps.Stop();
            step_2.SetActive(true);
            onlyshow.SetActive(false);
        }
    }
}
