using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerOnOff : MonoBehaviour
{
    public GameObject fire;
    public bool on;

    public void OnOrOff()
    {
        on = !on;

        if (on)
        {
            fire.SetActive(true);
        }
        else
        {
            fire.SetActive(false);
        }
    }
}
