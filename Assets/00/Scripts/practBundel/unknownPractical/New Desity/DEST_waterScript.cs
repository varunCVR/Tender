using UnityEngine;

public class DEST_waterScript : MonoBehaviour
{
    public fillResetDS mainGlassRend;
    public fillResetDS smallGlassRend;
    public ParticleSystem psFill;
    [Space]
    public float increaseSpeed;
    public float increaseSpeed_SmallGlass;
    public float decreaseSpeed;
    [Space]
    public bool up;
    public bool sectionEnded;

    private bool high;
    public bool ended;

    private bool endUp;

    [Space] public GameObject s_fake;
    public GameObject s_real;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Event")) {
            if (!sectionEnded) {        
                up = true; 
            }

            if (sectionEnded) {
                endUp = true;
            }
        }
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Event")) {
            if (!sectionEnded) {
                psFill.Stop();
                up = false;
            }

            if (sectionEnded) {
                endUp = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            if (!sectionEnded)
            {
                if (mainGlassRend.fillPoint < 0.1565f && up ) {
                    if (psFill.isStopped) {
                        psFill.Play();
                    }
                    mainGlassRend.fillPoint += Time.deltaTime * increaseSpeed;
                }
                if (mainGlassRend.fillPoint >= 0.1565f)
                {
                    high = true;
                    up = false;
                }
            }

            if (sectionEnded) {
                if (psFill.isPlaying) {
                    psFill.Stop();
                }
            }
            
            
            if (sectionEnded && !endUp) {
                endUp = true;
            }
        }
    }
    private void Update()
    {
        if (!sectionEnded) {
            if (!up && !ended && mainGlassRend.fillPoint > 0.15f) {
                mainGlassRend.fillPoint -= Time.deltaTime * decreaseSpeed;
            }
            if (mainGlassRend.fillPoint <= 0.144)
            {
                psFill.Stop();
            }

            if (!up && !ended && mainGlassRend.fillPoint <= 0.15f && high) {
                ended = true;
            }

            if (up || !ended && high) {
                if (smallGlassRend.fillPoint < 0.04f) {
                    smallGlassRend.fillPoint += Time.deltaTime * increaseSpeed_SmallGlass;
                }

                if (smallGlassRend.fillPoint >= 0.04f && !s_real.activeInHierarchy) {
                    sectionEnded = true;
                    psFill.Stop();
                    s_fake.SetActive(false);
                    s_real.SetActive(true);
                }
            }
        }

        
        if (sectionEnded) {
            if (endUp) {
                if (mainGlassRend.fillPoint < 0.15f) {
                                    mainGlassRend.fillPoint += Time.deltaTime * increaseSpeed;
                }
            }
            else if(!endUp) {
                if (mainGlassRend.fillPoint > 0.142f) {
                    mainGlassRend.fillPoint -= Time.deltaTime * increaseSpeed;
                }
            }
        }   
    }
}       
