using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matCompare : MonoBehaviour
{
    public Material MatComp;
    private Renderer rd;

    private void Start() {
        rd = GetComponent<Renderer>();
    }

    void Update() {
        if (rd.sharedMaterial== MatComp) {
            Debug.Log("Are Equal");
        }
    }
}


