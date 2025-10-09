using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOrbitClick : MonoBehaviour
{
    public bool clicked;
    public Transform upLc;
    public Transform downLc;
    public Transform targetTransForm;

    public float clickSpd;
    [Space] public bool condition;

    [Space] public Material matGreen;
    public Material matRed;


    [Header("Activation GameObject")] public GameObject[] activationObjs;

    private bool helperb;
    private int i;
    [Space] [Space] public bool isThereParticle;
    public ParticleSystem[] psFlow;

    [Header("sound FX")] public AudioSource audioPlayer;
    public AudioClip audioClip;


    [Space] public bool getChild;
    public buttonOrbitClick headOrbit;

    private void OnTriggerEnter(Collider other)
    {
        if (getChild)
        {
            if (headOrbit.condition)
            {
                audioPlayer.PlayOneShot(audioClip);
                clicked = true;
                condition = !condition;
            }
        }

        if (!getChild)
        {
            audioPlayer.PlayOneShot(audioClip);
            clicked = true;
            condition = !condition;
        }
    }

    public void CustomTrigger()
    {
        if (getChild)
        {
            if (headOrbit.condition)
            {
                audioPlayer.PlayOneShot(audioClip);
                clicked = true;
                condition = !condition;
            }
        }

        if (!getChild)
        {
            audioPlayer.PlayOneShot(audioClip);
            clicked = true;
            condition = !condition;
        }

        StartCoroutine(ExitTrigger());
    }

    IEnumerator ExitTrigger()
    {
        yield return new WaitForSeconds(1);
        if (getChild)
        {
            if (headOrbit.condition)
            {
                clicked = false;
            }
        }

        if (!getChild)
        {
            clicked = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (getChild)
        {
            if (headOrbit.condition)
            {
                clicked = false;
            }
        }

        if (!getChild)
        {
            clicked = false;
        }
    }

    private void Update()
    {
        if (getChild)
        {
            if (!headOrbit.condition)
            {
                condition = false;
                clicked = false;
            }
        }


        if (clicked && targetTransForm.position != downLc.position)
        {
            targetTransForm.position =
                Vector3.MoveTowards(targetTransForm.position, downLc.position, Time.deltaTime * clickSpd);
        }

        if (!clicked && targetTransForm.position != upLc.position)
        {
            targetTransForm.position =
                Vector3.MoveTowards(targetTransForm.position, upLc.position, Time.deltaTime * clickSpd);
        }


        if (targetTransForm.position == upLc.position)
        {
            if (condition && targetTransForm.gameObject.GetComponent<Renderer>().material != matGreen)
            {
                targetTransForm.gameObject.GetComponent<Renderer>().material = matGreen;
            }

            if (!condition && targetTransForm.gameObject.GetComponent<Renderer>().material != matRed)
            {
                targetTransForm.gameObject.GetComponent<Renderer>().material = matRed;
            }
        }

        if (condition && i == 0)
        {
            foreach (GameObject gobj in activationObjs)
            {
                gobj.SetActive(true);
            }

            if (isThereParticle)
            {
                foreach (ParticleSystem psObj in psFlow)
                {
                    psObj.Play();
                }
            }

            i = 1;
        }

        if (!condition && i == 1)
        {
            foreach (GameObject gobj in activationObjs)
            {
                gobj.SetActive(false);
            }

            if (isThereParticle)
            {
                foreach (ParticleSystem psObj in psFlow)
                {
                    psObj.Stop();
                }
            }

            i = 0;
        }
    }
}