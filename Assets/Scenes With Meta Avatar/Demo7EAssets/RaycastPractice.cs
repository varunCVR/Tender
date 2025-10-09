using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPractice : MonoBehaviour
{
    public GameObject movingCube;

    public int point;

    private void Update()
    {
        var r = new Ray(movingCube.transform.position, Vector3.right);
        print(r.GetPoint(point));


        movingCube.transform.position =
            Vector3.MoveTowards(movingCube.transform.position, r.GetPoint(point), Time.deltaTime);
    }
}