using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class detail3DScript : MonoBehaviour
{
    public Transform stokerPosition;
    public float increseY;
    private Vector3 posStorage;
    private void Update()
    {
        posStorage = new Vector3(stokerPosition.position.x, stokerPosition.position.y + increseY, stokerPosition.position.z);
        transform.position = posStorage;
    }
}
