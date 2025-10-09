using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changerWhite : MonoBehaviour
{
    public bool changed;
    public ParticleSystem psBlow;

    public Renderer mainLiquid;

    public int i;

    public AudioSource acidicEff;
    void Update()
    {
        if (!changed)
        {
            if (transform.eulerAngles.x > 70 && transform.eulerAngles.x < 210)
            {
                mainLiquid.material.SetColor("_SideColor", Color.white);
                mainLiquid.material.SetColor("_TopColor", Color.white);
      
                psBlow.Play();
                changed = true;
            }
            if (transform.eulerAngles.z > 70 && transform.eulerAngles.z < 210)
            {
                mainLiquid.material.SetColor("_SideColor", Color.white);
                mainLiquid.material.SetColor("_TopColor", Color.white);

                psBlow.Play();
                changed = true;
            }
        }

        if ((transform.eulerAngles.z > 70 && transform.eulerAngles.z < 210 && psBlow.isStopped)|| (transform.eulerAngles.x > 70 && transform.eulerAngles.x < 210 && psBlow.isStopped))
        {
            psBlow.Play();
            acidicEff.PlayOneShot(acidicEff.clip);
        }
    }
}
