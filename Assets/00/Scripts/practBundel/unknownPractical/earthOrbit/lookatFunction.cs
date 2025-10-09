using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatFunction : MonoBehaviour
{
    public Transform playerCam;
    void Update()
    {
        transform.LookAt(playerCam);
    }
}
