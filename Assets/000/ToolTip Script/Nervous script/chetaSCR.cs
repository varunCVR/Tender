using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chetaSCR : MonoBehaviour
{
    public GameObject chetaT;

    public void show()
    {
        chetaT.SetActive(false);
    }
        public void hide()

    {
        chetaT.SetActive(true);
    }
}
