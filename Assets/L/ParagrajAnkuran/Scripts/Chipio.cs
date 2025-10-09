using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chipio : MonoBehaviour
{
    public GameObject targetPos;
    public GameObject grabbedObjectTargetPos;
    public GameObject grabbedObjectInWaterTargetPos;
    public GameObject glassObjTargetPos;

    bool grabbed;
    public Transform t;
    public GameObject grabbedGameObject = null;

    public BoxCollider firstWatchGlass;
    public BoxCollider plateOneBoxCollider;
    public BoxCollider plateTwoBoxCollider;
    public BoxCollider waterTrigger;

    public GlassHandler glassHandler;

    public AudioSource audioSource;
    public AudioClip fourth;
    public AudioDemo21 demo21;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glow"))
        {
            if(!grabbed)
            {
                other.transform.eulerAngles = Vector3.zero;
                grabbedGameObject = other.gameObject;
                //grabbedGameObject.transform.eulerAngles = new Vector3(316.93f, 0, 327.4f);
                grabbedGameObject.transform.SetParent(t.transform);
                grabbedGameObject.transform.position = targetPos.transform.position;
               
                grabbed = true;
            }

        }
        else if (other.CompareTag("X"))
        {
            if (grabbed)
            {
                grabbedGameObject.transform.eulerAngles = new Vector3(90f, 0, 0);
                grabbedGameObject.transform.SetParent(firstWatchGlass.transform);
                grabbedGameObject.transform.position = firstWatchGlass.transform.position;
                grabbedGameObject = null;
                grabbed = false;
                firstWatchGlass.enabled = false;
                demo21.stopCoroutins();
                audioSource.PlayOneShot(fourth);
            }
        }
        else if (other.CompareTag("Cable2"))
        {
            if (grabbed)
            {
                grabbedGameObject.transform.eulerAngles = new Vector3(90f, 0, 0);
                grabbedGameObject.transform.SetParent(grabbedObjectTargetPos.transform);
                grabbedGameObject.transform.position = grabbedObjectTargetPos.transform.position;
                grabbedGameObject = null;
                grabbed = false;
                plateOneBoxCollider.enabled = false;
            }
        }else if (other.CompareTag("Buch"))
        {
            if (grabbed)
            {
                grabbedGameObject.transform.eulerAngles = new Vector3(90f, 0, 0);
                grabbedGameObject.transform.SetParent(waterTrigger.transform);
                grabbedGameObject.transform.position = waterTrigger.transform.position;
                grabbedGameObject = null;
                grabbed = false;
                waterTrigger.enabled = false;
            }  
        }
        else if (other.CompareTag("CableOne"))
        {
            if (grabbed)
            {
                grabbedGameObject.transform.eulerAngles = new Vector3(90f, 0, 0);
                grabbedGameObject.transform.SetParent(plateTwoBoxCollider.transform);
                grabbedGameObject.transform.position = plateTwoBoxCollider.transform.position;
                grabbedGameObject = null;
                grabbed = false;
                plateTwoBoxCollider.enabled = false;
            }
        }
       
        else if (other.CompareTag("CopperS"))
        {
            if (grabbed)
            {
                grabbedGameObject.transform.GetChild(0).GetComponent<MeshCollider>().enabled = false;
                grabbedGameObject.transform.eulerAngles = new Vector3(90f, 0, 0);
                grabbedGameObject.transform.SetParent(glassObjTargetPos.transform);
                grabbedGameObject.transform.position = glassObjTargetPos.transform.position;
               
                grabbedGameObject = null;
                grabbed = false;
                plateTwoBoxCollider.enabled = false;

                glassHandler.flowerPositioned = true;

            }
        }
    }
}
