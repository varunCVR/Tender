using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObj : MonoBehaviour
{
    private void OnCollisionEnter(Collision target)
    {
       transform.localScale = transform.localScale + new Vector3 (0,(float)0.4,0);
    }
}
