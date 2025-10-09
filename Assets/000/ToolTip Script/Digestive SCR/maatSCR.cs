using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maatSCR : MonoBehaviour
{
    public GameObject maatT;

    public void show()
    {
        maatT.SetActive(false);
    }

    public void hide()

    {
        maatT.SetActive(true);
    }
}
