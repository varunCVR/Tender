using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbon : MonoBehaviour
{
    public GameObject bulb;

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {

           bulb.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)

    {
        if (other.gameObject.tag == "Player")
        {

            bulb.SetActive(false);

        }
    }
}
