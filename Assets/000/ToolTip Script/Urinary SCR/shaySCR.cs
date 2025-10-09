using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaySCR : MonoBehaviour
{
    public GameObject shayT;

    public void show()
    {
        shayT.SetActive(false);
    }

    public void hide()

    {
        shayT.SetActive(true);
    }
}