using System;
using BNG;
using UnityEngine;
public class hydroRemover : MonoBehaviour
{ 
    public hyDraAdderTB hydroSCPT; 
    public GameObject hyDroAll;
    public ParticleSystem pshyDro;

    [Space] 
    public Grabbable pipetHy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("S") && hydroSCPT.hyDra)
        {
            pshyDro.Play();
            other.GetComponent<Rigidbody>().mass = 2;
            hyDroAll.SetActive(false);
            hydroSCPT.hyDra = false;
            pipetHy.enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}