using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jatharSCR : MonoBehaviour
{
    public GameObject jatharT;

    public void show()
    {
        jatharT.SetActive(false);
    }

    public void hide()

    {
        jatharT.SetActive(true);
    }
}
