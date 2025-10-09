using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antahkosjal : MonoBehaviour
{
    public GameObject antahkosjalT;

    public void show()
    {
        antahkosjalT.SetActive(false);
    }

    public void hide()

    {
        antahkosjalT.SetActive(true);
    }
}
