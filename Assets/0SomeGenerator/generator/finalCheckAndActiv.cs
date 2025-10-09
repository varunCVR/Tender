using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalCheckAndActiv : MonoBehaviour
{
    public GameObject[] allTG;

    public connectWire rightWire;
    public connectWire leftWire;

    [Space] public galvanoRoter gavanoReader;
    public GenraterOn generaTor;
    public GameObject flow;
    
    void Update()
    {
        if (!allTG[0].activeInHierarchy && !allTG[1].activeInHierarchy && !allTG[2].activeInHierarchy && !allTG[3].activeInHierarchy && !allTG[4].activeInHierarchy && !allTG[5].activeInHierarchy && !allTG[6].activeInHierarchy && !allTG[7].activeInHierarchy && rightWire.wCon && leftWire.wCon && !generaTor.enabled)
        {
            flow.SetActive(true);
            //mgPS.Play();
            gavanoReader.enabled = true;
            generaTor.enabled = true;
        }
    }
}
