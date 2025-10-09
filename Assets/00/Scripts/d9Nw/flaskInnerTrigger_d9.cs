using UnityEngine;

public class flaskInnerTrigger_d9 : MonoBehaviour
{
    public bool pipetEnt;
    public float flask_fillSpeed;
    public Renderer flask_Liquid;

    public bool HCLfilled;
    public bool FINfilled;
    [Space] 
    public ParticleSystem pipetPS;
    [Space]
    public GameObject fin_Trigger;
    public GameObject hcl_Trigger;
    
    [Space]
    public getHCL_d9 hclSign; 
    public getFINOLF_d9 finolSign;

    [Space]
    public pipet10MLliq pipetFill;
    public float decSpeed;

    [Space] 
    public GameObject flask_Grb;
    public GameObject flask3_Mix;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N")) {
            pipetEnt = true;
        }
    }

    private void Update()
    {
        if (pipetEnt) {
            if (hclSign.HCLfull && !HCLfilled) {
                if (pipetFill.fillp > -1.2f) {
                    if (!pipetPS.isPlaying) {
                        pipetPS.Play();
                    }
                    pipetFill.fillp -= Time.deltaTime * decSpeed;
                }
                
                if (pipetFill.fillp <= -1.2f) {
                    if (!pipetPS.isStopped) {
                        pipetPS.Stop();
                    }
                    fin_Trigger.SetActive(true);
                    hcl_Trigger.SetActive(false);
                    HCLfilled = true;
                }
                
                if (flask_Liquid.material.GetFloat("FillArea") < -0.02f) {
                    float fill = flask_Liquid.material.GetFloat("FillArea") ;
                    fill += Time.deltaTime * flask_fillSpeed;
                    flask_Liquid.material.SetFloat("FillArea",fill);
                }
            }
            if (finolSign.finolf_full && !FINfilled) {
                if (pipetFill.fillp > -1.2f) {
                    if (!pipetPS.isPlaying) {
                        pipetPS.Play();
                    }
                    pipetFill.fillp -= Time.deltaTime * decSpeed;
                }
                if (pipetFill.fillp <= -1.2f) {
                    if (!pipetPS.isStopped) {
                        pipetPS.Stop();
                    }
                    fin_Trigger.SetActive(false);
                    
                    flask_Grb.SetActive(true);
                    flask3_Mix.SetActive(false);
                    
                    FINfilled = true;
                }
                if (flask_Liquid.material.GetFloat("FillArea") < -0.02f)
                {
                    float fill = flask_Liquid.material.GetFloat("FillArea");
                    fill += Time.deltaTime * flask_fillSpeed;
                    flask_Liquid.material.SetFloat("FillArea",fill);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N")) {
            pipetPS.Stop();
            pipetEnt = false;
        }
    }
}