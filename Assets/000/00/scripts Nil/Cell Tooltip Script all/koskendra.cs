using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koskendra : MonoBehaviour
{
    public GameObject koskendraT;

    public void show()
    {
        koskendraT.SetActive(false);
    }

    public void hide()

    {
        koskendraT.SetActive(true);
    }
}
