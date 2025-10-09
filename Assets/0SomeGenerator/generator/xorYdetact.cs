using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xorYdetact : MonoBehaviour
{
    public Transform xObj;
    public Transform yObj;

    [Space] 
    public Transform rightLoc;
    public Transform leftLocation;
    [Space] 
    public connectWire Xcon;
    public connectWire Ycon;
    private void Update()
    {
        if (xObj.position == rightLoc.position)
        {
            Xcon.defineRight = true;
        }

        if (xObj.position==leftLocation.position)
        {
            Xcon.defineRight = false;
        }
        if (yObj.position == rightLoc.position)
        {
            Ycon.defineRight = true;
        }

        if (yObj.position==leftLocation.position)
        {
            Ycon.defineRight = false;
        }
    }
}
