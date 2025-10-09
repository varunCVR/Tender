using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushControllerCustom : MonoBehaviour
{
    public GameObject targetObj;
    public Transform fixPos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spoon"))
        {
            if (targetObj == null)
            {
                targetObj = other.gameObject;
                targetObj.transform.parent = fixPos.transform;
                targetObj.transform.position = fixPos.position;
                Destroy(targetObj.GetComponent<Rigidbody>());
            }
        }
        
    }
}
