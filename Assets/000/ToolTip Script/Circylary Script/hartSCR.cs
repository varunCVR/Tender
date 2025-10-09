using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hartSCR : MonoBehaviour
{
    public GameObject hartT;

    public void show()
    {
        hartT.SetActive(false);
    }

    public void hide()

    {
        hartT.SetActive(true);
    }


}
