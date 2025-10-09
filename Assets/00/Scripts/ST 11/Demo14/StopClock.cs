using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StopClock : MonoBehaviour
{
    public float HourStop = 2;
    public DigitalClock Cl;
    void Update()
    {
        if(Cl.min == HourStop)
        {
            Cl.Speed = 0;
        }
    }
}
