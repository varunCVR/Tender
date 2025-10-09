using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAngleBetwenTwoObj : MonoBehaviour
{
    void Update()
    {
        transform.rotation = new Quaternion(Mathf.Clamp(transform.rotation.x, -0.1f, 0.1f), transform.rotation.y,
            Mathf.Clamp(transform.rotation.z, -0.1f, 0.1f),1);
    }
}
