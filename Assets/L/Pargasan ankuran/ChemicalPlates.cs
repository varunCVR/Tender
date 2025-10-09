using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalPlates : MonoBehaviour
{
    public GameObject childObj;
    public ParticleSystem _particleSystem;
    bool isParticlePlayed;

    private void Update()
    {
        Debug.Log(transform.eulerAngles);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            if (transform.eulerAngles.x >= 340f)
            {
                if (!isParticlePlayed) {
                    _particleSystem.Play();
                    other.GetComponent<BeakerWater>().counter += 1;
                }
                
                childObj.SetActive(false);
                isParticlePlayed = true;
            
            }
        }
    }
}
