using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nitambSK : MonoBehaviour
{
    public GameObject nitambT;

    public void show()
    {
        nitambT.SetActive(false);
    }

    public void hide()

    {
        nitambT.SetActive(true);
    }


}
