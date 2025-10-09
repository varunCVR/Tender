using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelvisSK : MonoBehaviour
{
    public GameObject pelvisT;

    public void show()
    {
        pelvisT.SetActive(false);
    }

    public void hide()

    {
        pelvisT.SetActive(true);
    }


}
