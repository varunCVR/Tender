using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oribitRotateFunction : MonoBehaviour
{
    public MyEnum direction;
    public float roterSpeed;

    public enum MyEnum
    {
        up,
        down,
        right,
        left,
        forword,
        back
    }

    private void Update()
    {
        if (direction == MyEnum.up)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * roterSpeed);
        }
        if (direction == MyEnum.down)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * roterSpeed);
        }
        if (direction == MyEnum.right)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * roterSpeed);
        }
        if (direction == MyEnum.left)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * roterSpeed);
        }
        if (direction == MyEnum.forword)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * roterSpeed);
        }
        if (direction == MyEnum.back)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * roterSpeed);
        }
    }
}
