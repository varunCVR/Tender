using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nanumagajSCR : MonoBehaviour
{
    public GameObject nanumagajT;

    public void show()
    {
        nanumagajT.SetActive(false);
    }

    public void hide()

    {
        nanumagajT.SetActive(true);
    }
}
