using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doroScriptConnect : MonoBehaviour
{
    public GameObject doro;
    public bool rope;
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RF"))
        {
            rope = true;
            doro.SetActive(true);
            GetComponent<Collider>().enabled = false;
            Destroy(other.gameObject);
            rb.linearDamping = 2;
        }
    }
}
