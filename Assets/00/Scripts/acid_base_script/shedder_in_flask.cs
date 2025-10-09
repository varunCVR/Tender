using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shedder_in_flask : MonoBehaviour
{
    public Renderer flaskRend;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
        }
    }
}
