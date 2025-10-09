using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranjakkan : MonoBehaviour
{
    public GameObject ranjakkanT;

    public void show()
    {
        ranjakkanT.SetActive(false);
    }

    public void hide()

    {
        ranjakkanT.SetActive(true);
    }
}

