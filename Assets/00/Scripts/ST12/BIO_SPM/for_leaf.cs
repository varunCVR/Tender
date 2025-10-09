using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class for_leaf : MonoBehaviour
{
    private bool confirm;
    public Renderer Material;
    public float smoothness;
    [Space] public for_veseline vesoBool;

    [Space] public Rigidbody leafMas;
    public bool _V;
    private void OnTriggerEnter(Collider other) {
        if (vesoBool.vasolated) {
            
            if (other.CompareTag("S") && !_V)
            {
                leafMas.mass = 2;
                _V = true;
                vesoBool.vasolated = false;
                vesoBool.VESOLINEaLL.SetActive(false);
                confirm = true;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        
        if (other.CompareTag("S")) {
            confirm = false;
        }
    }
    private void Update() {
        if (confirm) {
            Material.material.GetFloat("_Smoothness");
            Material.material.SetFloat("_Smoothness",smoothness);
        }
    }
}
