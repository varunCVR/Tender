using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naliSCR : MonoBehaviour
{
    public GameObject naliT;

    public void show()
    {
        naliT.SetActive(false);
    }

    public void hide()

    {
        naliT.SetActive(true);
    }
}
