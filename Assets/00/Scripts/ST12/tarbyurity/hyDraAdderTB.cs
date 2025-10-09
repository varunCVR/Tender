using System;
using  UnityEngine;
public class hyDraAdderTB : MonoBehaviour
{
     public GameObject hyDraObjAll;
     public bool hyDra;

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("S") && other.GetComponent<Rigidbody>().mass == 1)
          {
               hyDraObjAll.SetActive(true);
               hyDra = true;
          }
     }
}
