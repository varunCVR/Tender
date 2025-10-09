using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annSCR : MonoBehaviour
{
    public GameObject annT;

    public void show()
    {
        annT.SetActive(false);
    }

    public void hide()

    {
        annT.SetActive(true);
    }
}
