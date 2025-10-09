using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPosGrab : MonoBehaviour
{
    public Quaternion Rotation;
    private void Update()
    {
        if(GetComponent<Rigidbody>().collisionDetectionMode != CollisionDetectionMode.ContinuousDynamic)
        {
            if (transform.localRotation != Rotation)
            {
                transform.rotation = Rotation;
            }
        }      
    }
}

