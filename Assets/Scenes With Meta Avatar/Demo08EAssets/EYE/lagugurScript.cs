using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lagugurScript : MonoBehaviour
{
    public bool gur;

    public Transform mainGrab;
    public Transform reactionObj;

    public Vector3 posReset;

    public lenceEnter lencEentr;

    private void Update()
    {
        if (gur)
        {
            if (lencEentr.inner)
            {
                reactionObj.localPosition = Vector3.zero;
            }

            if (!lencEentr.inner)
            {
                if (mainGrab.localPosition.x > 0) {
                    posReset.x = mainGrab.localPosition.x;
                }
                else {
                    posReset.x = 0;
                }
                reactionObj.localPosition = -posReset;
            }
        }
        
        if (!gur)
        {
            if (lencEentr.outter)
            {
                reactionObj.localPosition = Vector3.zero;
            }

            if (!lencEentr.outter)
            {
                if (mainGrab.localPosition.x < 0)
                {
                    posReset.x = mainGrab.localPosition.x;
                }
                else
                {
                    posReset.x = 0;
                }
                reactionObj.localPosition = -posReset;
            }
            
            
                
        }
    }
}
