using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spownObjWithTriggr : MonoBehaviour
{
    private Vector3 getPos;
    private Vector3 downPos;
    private bool entrd;

    public float pressSpeed;
    public bool woodArea;
    public bool eggArea;
    public bool clayArea;
    
    [Space]
    public GameObject woodobj;
    public Transform woodloc;
    public int woodCount;
    private int wC;

    [Space] 
    public GameObject eggObj;
    public Transform eggloc;
    public int eggCount;
    private int ec;

    [Space] public GameObject clayObj;
    public Transform clayloc;
    public int clayCount;
    private int cC;
    
    private void Awake() {
        getPos = transform.localPosition;
        downPos = new Vector3(getPos.x,0.006f,getPos.z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        entrd = true;
        if (woodArea && wC < woodCount) {
            Instantiate(woodobj, woodloc.localPosition, woodloc.rotation);
            wC++;
        }
        if (eggArea && ec<eggCount) {
            Instantiate(eggObj, eggloc.localPosition, eggloc.rotation);
            ec++;
        }
        if (clayArea && cC<clayCount) {
            Instantiate(clayObj, clayloc.localPosition, clayloc.rotation);
            cC++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entrd = false;
    }

    private void Update()
    {
        if (entrd)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, downPos, Time.deltaTime * pressSpeed);
        }
        else {
            transform.localPosition = Vector3.Lerp(transform.localPosition, getPos, Time.deltaTime * pressSpeed);
        }
    }
}
