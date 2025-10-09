using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laysozom : MonoBehaviour
{
    public GameObject laysozomT;

    public void show()
    {
        laysozomT.SetActive(false);
    }

    public void hide()

    {
        laysozomT.SetActive(true);
    }
}

