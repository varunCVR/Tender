using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pagpanjoSK : MonoBehaviour
{
    public GameObject pagpanjoT;

    public void show()
    {
        pagpanjoT.SetActive(false);
    }

    public void hide()

    {
        pagpanjoT.SetActive(true);
    }


}
