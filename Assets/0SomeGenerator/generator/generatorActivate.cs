using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorActivate : MonoBehaviour
{
    public GameObject[] bloods;
    
    public int lenthTotal;
    
    private bool waiter = true;



    public bool delay;
    public float time;
    private int counter;

    public bool execMethod;
        // Start is called before the first frame update

        public void ActivateParticles()
        {
            StartCoroutine(Activate());
        }

        IEnumerator Activate()
        {
            
            for (int i = 0; i < bloods.Length; i++)
            {
                bloods[i].SetActive(true);
                counter++;
                yield return new WaitForSeconds(0.15f);
            }
        }

        public void DisableBloods()
        {
            StartCoroutine(DisableBloodsCo());
            
        }

        IEnumerator DisableBloodsCo()
        {
            for (int i = 0; i < bloods.Length; i++)
            {
                bloods[i].SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void Update()
        {
            if (execMethod)
            {
                ActivateParticles();
                execMethod = false;
            }
        }

        /*void Start()
    {
        lenthTotal = bloods.Length;
        if (delay)
        {
            waiter = false;
            StartCoroutine(reere());
        }

    }
    IEnumerator reere()
    {
        yield return new WaitForSeconds(time);
        waiter = true;
    }
    
    private void Update()
    {
        if (waiter && lenthTotal > 0) 
        {
            StartCoroutine(waitForBlinker());
            waiter = false;
        }
    }
    IEnumerator waitForBlinker()
    {
        yield return new WaitForSeconds(0.1f);
        bloods[lenthTotal-1].SetActive(true);
        lenthTotal--;
        waiter = true;
    }*/
}
