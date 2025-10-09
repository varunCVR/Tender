using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmBuyPos : MonoBehaviour
{
    public connectWire rightDefine;
    void Update()
    {
        if (transform.localEulerAngles.y == 180 && rightDefine.defineRight)
        {
            rightDefine.defineRight = false;
        }
        else if (transform.localEulerAngles.y == 0 && !rightDefine.defineRight)
        {
            rightDefine.defineRight = true;
        }
        
    }
}
