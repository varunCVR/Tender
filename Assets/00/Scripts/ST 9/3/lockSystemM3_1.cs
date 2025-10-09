using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockSystemM3_1 : MonoBehaviour
{
    public bool lockPS;
    public bool lockQR;

    private Vector3 posM;
    private Vector3 posR;
    private void Awake() {
        posM = transform.position;
        posR = transform.localEulerAngles;
    }

    private void Update() {
        /*if (!lockPS) {
            transform.position = posM;
        }

        if (!lockQR) {
            transform.localEulerAngles = posR;
        }*/
    }
}
