using System.Collections;
using UnityEngine;

public class EggCollider : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.CompareTag("glow")) {
         GetComponent<MeshCollider>().enabled = false;
         GetComponent<Rigidbody>().linearDamping = 20;
         StartCoroutine(colActivate());
      }
   }
   IEnumerator colActivate()
   {
      yield return new WaitForSeconds(1.5f);
      GetComponent<MeshCollider>().enabled = true;
   }
}
