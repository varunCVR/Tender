using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateLock : MonoBehaviour
{
    public float min;
    public float max;
        void Update()
        {
            transform.localEulerAngles = new Vector3(0, Mathf.Clamp(transform.localEulerAngles.y,min,max), 0);
            transform.position = Vector3.zero;
        }
        
}
