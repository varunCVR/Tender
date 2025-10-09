using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillFlaskford17 : MonoBehaviour
{
    public bool pipetEnt;
    public float flask_fillSpeed;
    public Renderer flask_Liquid;

    public bool h2so4Filled;
    [Space] public ParticleSystem pipetPS;
    [Space]
    public GameObject h2So4_Trigger;
    
    [Space]
    public getHCL_d9 h2So4Sign; 

    [Space]
    public pipet10MLliq pipetFill;
    public float decSpeed;

    [Space] 
    public GameObject flask_Grb;
    public GameObject flask3_Mix;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            pipetEnt = true;
        }
    }

    private void Update()
    {
        if (pipetEnt)
        {
            if (h2So4Sign.HCLfull && !h2so4Filled)
            {
                if (pipetFill.fillp > -1.2f) {
                    if (!pipetPS.isPlaying)
                    {
                        pipetPS.Play();
                    }
                    pipetFill.fillp -= Time.deltaTime * decSpeed;
                }
                
                if (pipetFill.fillp <= -1.2f) {
                    if (!pipetPS.isStopped)
                    {
                        pipetPS.Stop();
                    }
                    h2So4_Trigger.SetActive(false);
                    flask_Grb.SetActive(true);
                    flask3_Mix.SetActive(false);
                    h2so4Filled = true;
                }
                
                if (flask_Liquid.material.GetFloat("FillArea") < -0.02f)
                {
                    float fill = flask_Liquid.material.GetFloat("FillArea") ;
                    fill += Time.deltaTime * flask_fillSpeed;
                    flask_Liquid.material.SetFloat("FillArea",fill);
                }
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            pipetEnt = false;
        }
    }
}
