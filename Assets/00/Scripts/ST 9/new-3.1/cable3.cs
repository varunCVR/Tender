using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable3 : MonoBehaviour
{
    private LineRenderer Lr;
   public Material met;
   public Transform endLocation;
   public float width;
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        Lr = GetComponent<LineRenderer>();
        Lr.widthMultiplier = width;
        Lr.material = met;
    }

    void Update()
    {
        Lr.SetPosition(0,transform.position);
        Lr.SetPosition(1,endLocation.position);
    }
}
