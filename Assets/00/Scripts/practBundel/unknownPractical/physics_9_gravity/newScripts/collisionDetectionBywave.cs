using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetectionBywave : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
     
      if (collision.gameObject.CompareTag("glow")) {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().linearDamping = 15;

            StartCoroutine(colActivater());
      }

      if (collision.gameObject.CompareTag("Salt"))
      {
         GetComponent<MeshCollider>().enabled = false;
         GetComponent<Rigidbody>().linearDamping = 15;

         StartCoroutine(colActivater());
      }
   }

   IEnumerator colActivater()
   {
      yield return new WaitForSeconds(1f);
      GetComponent<MeshCollider>().enabled = true;
   }
}
