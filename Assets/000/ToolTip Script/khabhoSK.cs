using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khabhoSK : MonoBehaviour
{
    public GameObject khabhoT;

    public void show()
    {
        khabhoT.SetActive(false);
    }

    public void hide()

    {
        khabhoT.SetActive(true);
    }


}
