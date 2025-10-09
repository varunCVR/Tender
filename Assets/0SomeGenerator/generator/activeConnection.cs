using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeConnection : MonoBehaviour
{
    public FixPos6 switch1;
    public FixPos6 switch2;

    public connectWire wire1;
    public connectWire wire2;
    private void Update() {
        if (switch1.isJointed && switch2.isJointed && !wire2.enabled) {
            wire1.enabled = true;
            wire2.enabled = true;
        }
    }
}
