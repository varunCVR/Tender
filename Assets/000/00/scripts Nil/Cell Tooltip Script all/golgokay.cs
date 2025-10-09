using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golgokay : MonoBehaviour
{
    public GameObject golgokayT;

    public void show()
    {
        golgokayT.SetActive(false);
    }

    public void hide()

    {
        golgokayT.SetActive(true);
    }
}

