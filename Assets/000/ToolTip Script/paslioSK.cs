using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paslioSK : MonoBehaviour
{
    public GameObject paslioT;

    public void show()
    {
        paslioT.SetActive(false);
    }

    public void hide()

    {
        paslioT.SetActive(true);
    }


}
