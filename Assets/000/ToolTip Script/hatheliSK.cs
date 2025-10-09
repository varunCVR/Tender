using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatheliSK : MonoBehaviour
{
    public GameObject hatheliT;

    public void show()
    {
        hatheliT.SetActive(false);
    }

    public void hide()

    {
        hatheliT.SetActive(true);
    }


}
