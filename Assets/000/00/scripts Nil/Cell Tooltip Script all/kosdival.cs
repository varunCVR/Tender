using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kosdival : MonoBehaviour
{
    public GameObject kosdivalT;

    public void show()
    {
        kosdivalT.SetActive(false);
    }

    public void hide()

    {
        kosdivalT.SetActive(true);
    }
}
