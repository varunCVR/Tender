using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kosras : MonoBehaviour
{
    public GameObject kosrasT;

    public void show()
    {
        kosrasT.SetActive(false);
    }

    public void hide()

    {
        kosrasT.SetActive(true);
    }
}

