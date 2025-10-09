using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantcellgrab : MonoBehaviour
{
    public GameObject Button;

    Vector3 startpos;
    Quaternion startrotation;

    private void Start()
    {
        startpos = transform.position;
        startrotation = transform.rotation;
    }

    private void Update()
    {
        if(GetComponent<Rigidbody>().collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, startpos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, startrotation, Time.deltaTime * 5);
        }

        if(transform.position == startpos && transform.rotation == startrotation)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            Button.SetActive(true);
        }
        else
        {
            Button.SetActive(false);
        }
    }
}
