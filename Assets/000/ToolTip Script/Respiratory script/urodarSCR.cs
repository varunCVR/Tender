using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class urodarSCR : MonoBehaviour
{
    public GameObject urodarT;

    public void show()
    {
        urodarT.SetActive(false);
    }

    public void hide()

    {
        urodarT.SetActive(true);
    }
}
