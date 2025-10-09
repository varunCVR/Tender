using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBeakerToItsPos : MonoBehaviour
{
    public GameObject target;
    public AudioSource audioSource;
    public AudioClip clip;

    bool move;
    public bool positionedCorrectly;
    public ParticleSystem steamSmoke;
    public AnimatedTextureUVs textureScript;
    public BurnerOnOff on;
    public Renderer waterRenderer;

    bool playAudioOnceOnly;

    float secs;
    float alpha;
    private void Start()
    {
        steamSmoke.gameObject.SetActive(false);
        waterRenderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));
    }

    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
            if (!playAudioOnceOnly)
            {
                StartCoroutine(playAudio());

                playAudioOnceOnly = true;
            }
            if (Vector3.Distance(transform.position,target.transform.position)<= 0.001f)
            {
                transform.eulerAngles = Vector3.zero;
                positionedCorrectly = true;
               
            }
            else
            {
                positionedCorrectly = false;
            }
        }
    }
    IEnumerator playAudio()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
        yield return new WaitForSeconds(15.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("patti"))
        {
            move = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("patti"))
        {
            if (on.on)
            {
               
                secs += (0.005f);
                if(alpha<1)
                alpha += 0.00014f;
                waterRenderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));
                if (secs >= 10)
                {
                    steamSmoke.gameObject.SetActive(true);
                }
                if (secs > 17)
                {
                    steamSmoke.gameObject.SetActive(false);
                    secs = 17f;
                }
                Debug.Log("i am On:  " + secs);
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("patti"))
        {
            if(secs >= 5)
            {
                StartCoroutine(StopHeat());
            }
            move = false;
            secs = 0;
            playAudioOnceOnly = false;
        }
    }

    IEnumerator StopHeat()
    {
        steamSmoke.gameObject.SetActive(false);
        while (alpha > 0)
        {
            alpha -= 0.00014f;
            waterRenderer.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));
            yield return new WaitForFixedUpdate();
            Debug.Log("Inside Coroutine ");
        }
    }
}
