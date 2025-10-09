using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koshkendrapatal : MonoBehaviour
{
    public GameObject koshkendrapatalT;

    public void show()
    {
        koshkendrapatalT.SetActive(false);
    }

    public void hide()

    {
        koshkendrapatalT.SetActive(true);
    }
}

