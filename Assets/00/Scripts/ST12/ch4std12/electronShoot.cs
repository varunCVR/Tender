using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electronShoot : MonoBehaviour
{
    private bool collided;
    public ParticleSystem psTail;

    private void Start()
    {
        psTail = transform.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (!collided)
        {
            psTail.Play();
            transform.Translate(0,0,0.01f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        psTail.Stop();
        collided = true;
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<MeshRenderer>());
        Destroy(gameObject,10f);
    }
}
