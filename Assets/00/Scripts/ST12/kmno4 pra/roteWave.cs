using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roteWave : MonoBehaviour
{ 
    public float rotationSpeed;
    public Transform parTrans;
    private Vector3 roter;
    private bool finish;
    private void Start()
    {
        roter = transform.localEulerAngles;
    }
    // 0 to 1 
    // Update is called once per frame
    void Update()
    {
        parTrans.Rotate(Vector3.up * Time.deltaTime * rotationSpeed); // ROTATION
        //float wave = Mathf.Sin(Time.deltaTime * 10) * 5;

        //roter.z = wave;
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,roter.z);
    }
}
