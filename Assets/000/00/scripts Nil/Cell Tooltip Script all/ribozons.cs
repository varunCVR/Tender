using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ribozons : MonoBehaviour
{
    public GameObject ribozonsT;

    public void show()
    {
        ribozonsT.SetActive(false);
    }

    public void hide()

    {
        ribozonsT.SetActive(true);
    }
}

