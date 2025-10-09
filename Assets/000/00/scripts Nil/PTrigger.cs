using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTrigger : MonoBehaviour
{
    ParticleSystem rakh;
    void Start()
    {
        rakh = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "patti")
        {
            rakh.Play();
        }
 
    }
    void OnTriggerExit(Collider other)
    {
        rakh.Stop();
    }
}
