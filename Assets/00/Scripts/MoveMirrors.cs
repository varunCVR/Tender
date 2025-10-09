using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMirrors : MonoBehaviour
{
   // public GameObject concaveMirror, convexMirror, concaveLens, convexLens, Prism;

    public Transform concaveMirrorPos, convaxMirrorPos, concaveLensPos, convexLensPos, prismPos;

    bool firstPlaced,secPlaced, n1Place,n2Placed,n3Placed;

    public GameObject targetGameObject1, targetGameObject2, targetGameObject3, targetGameObject4, targetGameObject5;

    private void Update()
    {
        if (firstPlaced)
        {
            targetGameObject1.transform.position = Vector3.MoveTowards(targetGameObject1.transform.position, concaveMirrorPos.position, Time.deltaTime);
        }
        if (secPlaced)
        {
            targetGameObject2.transform.position = Vector3.MoveTowards(targetGameObject2.transform.position, convaxMirrorPos.position, Time.deltaTime);
        }
        if (n1Place)
        {
            targetGameObject3.transform.position = Vector3.MoveTowards(targetGameObject3.transform.position, concaveLensPos.position, Time.deltaTime);
        }
        if (n2Placed)
        {
            targetGameObject4.transform.position = Vector3.MoveTowards(targetGameObject2.transform.position, convexLensPos.position, Time.deltaTime);
        }
        if (n3Placed)
        {
            targetGameObject5.transform.position = Vector3.MoveTowards(targetGameObject2.transform.position, prismPos.position, Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("S") && !firstPlaced)
        {
            targetGameObject1 = other.gameObject;
            firstPlaced = true;
           
        }
        else if (other.CompareTag("S") && firstPlaced && !secPlaced)
        {
            secPlaced = true;
            targetGameObject2 = other.gameObject;
        }
        else if (other.CompareTag("N")&& !n1Place)
        {
            targetGameObject3 = other.gameObject;
            n1Place = true;
        }
        else if (other.CompareTag("N") && n1Place && !n2Placed)
        {
            targetGameObject4 = other.gameObject;
            n2Placed = true;
        }
        else if (other.CompareTag("N") && n1Place && n2Placed && !n3Placed)
        {
            targetGameObject5 = other.gameObject;
            n3Placed = true;
        }
    }
}
