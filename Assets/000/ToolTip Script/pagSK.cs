using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pagSK : MonoBehaviour
{
    public GameObject pagT;

    public void show()
    {
        pagT.SetActive(false);
    }

    public void hide()

    {
        pagT.SetActive(true);
    }


}
