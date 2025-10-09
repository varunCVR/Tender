using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateAtTime : MonoBehaviour
{
    public GameObject[] bloods;

    public int lenthTotal;

    private bool waiter = true;
    // Start is called before the first frame update
    void Start()
    {
        lenthTotal = bloods.Length;
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
        yield return new WaitForSeconds(0.2f);
        bloods[lenthTotal-1].SetActive(true);
        lenthTotal--;
        waiter = true;
        /*bloods[0].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[2].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[3].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[4].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[5].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[6].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[7].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        bloods[8].SetActive(true);
        yield return new WaitForSeconds(0.2f);*/
    }
}
