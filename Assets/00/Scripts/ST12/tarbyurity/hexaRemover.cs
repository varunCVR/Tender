using System;
using BNG;
using UnityEngine;
public class hexaRemover : MonoBehaviour
{ 
    public hexaAdderTB hexSCPT; 
    public GameObject hxaAll;
    public ParticleSystem hexPS;

    [Space] public Grabbable pipetHex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N") && hexSCPT.hexa)
        {
            hexPS.Play();
            other.GetComponent<Rigidbody>().mass = 2;
            hxaAll.SetActive(false);
            hexSCPT.hexa = false;
            pipetHex.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
