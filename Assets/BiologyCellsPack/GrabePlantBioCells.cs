using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabePlantBioCells : MonoBehaviour
{
    public List<Transform> allObj;
    List<Vector3> startPos;
    List<Vector3> startRot;

    private void Start()
    {
        for (int i = 0; i < allObj.Count; i++)
        {
            startPos[i] = allObj[i].position;
            startRot[i] = allObj[i].eulerAngles;
        }
    }
}
