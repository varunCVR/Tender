using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterPapper : MonoBehaviour
{

    public GameObject obj1, obj2;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Clicker"))
        {
            obj1.GetComponent<MeshRenderer>().enabled = false;
        }else if (collision.CompareTag("milk"))
        {
            obj2.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
