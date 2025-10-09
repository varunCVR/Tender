using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haritkan : MonoBehaviour
{
    public GameObject haritkanT;

    public void show()
    {
        haritkanT.SetActive(false);
    }

    public void hide()

    {
        haritkanT.SetActive(true);
    }
}
