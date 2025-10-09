using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khopdiSK : MonoBehaviour
{
    public GameObject khopdiT;

    public void show()
    {
        khopdiT.SetActive(false);
    }

    public void hide()

    {
        khopdiT.SetActive(true);
    }


}
