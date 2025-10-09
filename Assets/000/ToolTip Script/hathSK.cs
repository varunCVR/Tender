using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hathSK : MonoBehaviour
{
    public GameObject hathT;

    public void show()
    {
        hathT.SetActive(false);
    }

    public void hide()

    {
        hathT.SetActive(true);
    }


}
