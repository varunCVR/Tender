using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fefsaSCR : MonoBehaviour
{
    public GameObject fefsaT;

    public void show()
    {
        fefsaT.SetActive(false);
    }

    public void hide()

    {
        fefsaT.SetActive(true);
    }
}
