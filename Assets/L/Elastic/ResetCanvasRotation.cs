using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCanvasRotation : MonoBehaviour
{
    private void Update()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
