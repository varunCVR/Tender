using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magajSCR : MonoBehaviour
{
    public GameObject magajT;

    public void show()
    {
        magajT.SetActive(false);
    }
        public void hide()

    {
        magajT.SetActive(true);
    }
}
