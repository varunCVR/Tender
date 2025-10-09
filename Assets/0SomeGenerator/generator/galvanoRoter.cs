using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galvanoRoter : MonoBehaviour
{
    public Transform minPoint;
    public Transform maxPoint;
    public Transform centerNeedle;
    public bool roter,rotateLeftSide,rotateRightSide,backToCenter;
    public int spd;
    void Update() {
        if (transform.rotation == maxPoint.rotation) {
            roter = true;
        }
        if (transform.rotation == minPoint.rotation) {
            roter = false;
        }
        
            if (rotateRightSide)
            {
                transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, minPoint.localEulerAngles,Time.deltaTime * spd);
            }
            else if(rotateLeftSide)
                transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, maxPoint.localEulerAngles,
                    Time.deltaTime * spd);
            else
            {
                transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, centerNeedle.localEulerAngles,
                    Time.deltaTime * spd);
            }
    }
}
