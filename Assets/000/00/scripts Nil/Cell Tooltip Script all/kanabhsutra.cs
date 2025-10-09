using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kanabhsutra : MonoBehaviour
{
    public GameObject kanabhsutraT;

    public void show()
    {
        kanabhsutraT.SetActive(false);
    }

    public void hide()

    {
        kanabhsutraT.SetActive(true);
    }
}
