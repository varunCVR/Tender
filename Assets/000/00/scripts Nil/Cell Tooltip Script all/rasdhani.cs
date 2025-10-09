using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rasdhani : MonoBehaviour
{
    public GameObject rasdhaniT;

    public void show()
    {
        rasdhaniT.SetActive(false);
    }

    public void hide()

    {
        rasdhaniT.SetActive(true);
    }
}
