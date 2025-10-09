using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitHook : MonoBehaviour
{

    Vector3 startPos;

    private void Awake()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        if(transform.position.y>= startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}
