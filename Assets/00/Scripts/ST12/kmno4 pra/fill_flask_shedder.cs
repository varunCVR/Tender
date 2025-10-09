using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill_flask_shedder : MonoBehaviour
{
    public Renderer flaskRend;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (flaskRend.material.GetFloat("FillArea") < -0.02f)
            {
                float fill = flaskRend.material.GetFloat("FillArea") + Time.deltaTime * 0.01f;
                flaskRend.material.SetFloat("FillArea",fill);
            }
        }
    } 
}
