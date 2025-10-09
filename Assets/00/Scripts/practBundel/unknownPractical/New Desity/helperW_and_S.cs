using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helperW_and_S : MonoBehaviour
{
    // Start is called before the first frame update
    public enter_wtr water_Trig;
    public for_saltwtr salt_trigger;

    public GameObject realHinged;
    public numberChanger updater;

    private void Update()
    {
        if (realHinged.activeInHierarchy && !water_Trig.enabled)
        {
            updater.enabled = true;
            salt_trigger.enabled = true;
            water_Trig.enabled = true;
        }
    }
}
