using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pindSCR : MonoBehaviour
{
    public GameObject pindT;

    public void show()
    {
        pindT.SetActive(false);
    }

    public void hide()

    {
        pindT.SetActive(true);
    }
}
