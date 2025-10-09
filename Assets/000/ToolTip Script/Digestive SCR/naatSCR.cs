using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naatSCR : MonoBehaviour
{
    public GameObject naatT;

    public void show()
    {
        naatT.SetActive(false);
    }

    public void hide()

    {
        naatT.SetActive(true);
    }
}
