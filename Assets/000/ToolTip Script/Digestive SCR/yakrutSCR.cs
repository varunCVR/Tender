using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yakrutSCR : MonoBehaviour
{
    public GameObject yakrutT;

    public void show()
    {
        yakrutT.SetActive(false);
    }

    public void hide()

    {
        yakrutT.SetActive(true);
    }
}
