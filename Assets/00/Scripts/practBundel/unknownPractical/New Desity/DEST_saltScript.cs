                        using UnityEngine;

public class DEST_saltScript : MonoBehaviour
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

    public bool section;
    private bool high;
    public bool ended;

    private bool _endUp;

    [Space] public GameObject s_fake;
    public GameObject s_real;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            if (!section) {
                up = true;
            }

            if (section) {
                _endUp = true;
            }
        }
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            if (!section) {
                psFill.Stop();
                up = false;
            }

            if (section) {
                _endUp = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Event"))
        {
            if (!section)
            {
                if (mainGlassRend.fillPoint < 0.157f && up ) {
                    if (psFill.isStopped) {
                        psFill.Play();
                    }
                    mainGlassRend.fillPoint += Time.deltaTime * increaseSpeed;
                }
                if (mainGlassRend.fillPoint >= 0.157f)
                {
                    high = true;
                    up = false;
                }
            }

            if (section)
            {
                if (psFill.isPlaying)
                {
                    psFill.Stop();
                }
            }

            if (section && !_endUp)
            {
                _endUp = true;
            }
        }
    }

    private void Update()
    {
        if (!section) 
        {   
            if (!up && !ended && mainGlassRend.fillPoint > 0.15f)
            {
                mainGlassRend.fillPoint -= Time.deltaTime * decreaseSpeed;
            }
            if (mainGlassRend.fillPoint <= 0.144)
            {
                psFill.Stop();
            }
            if (!up && !ended && mainGlassRend.fillPoint <= 0.15f && high)
            {
                ended = true;
            }

            if (up || !ended && high)
            {
                if (smallGlassRend.fillPoint < 0.05f)
                {
                    smallGlassRend.fillPoint += Time.deltaTime * increaseSpeed_SmallGlass;
                }

                if (smallGlassRend.fillPoint >= 0.05f && !s_real.activeInHierarchy)
                {
                    section = true;
                    psFill.Stop();
                    s_fake.SetActive(false);
                    s_real.SetActive(true);
                }
            }
        }

        if (section) {
            if (_endUp) {
                if (mainGlassRend.fillPoint < 0.15f)
                {
                    mainGlassRend.fillPoint += Time.deltaTime * increaseSpeed;
                }
            }
            else if (!_endUp) {
                if (mainGlassRend.fillPoint > 0.140f)
                {
                    mainGlassRend.fillPoint -= Time.deltaTime * increaseSpeed;
                }
            }
        }
    }   
}
