using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasteCheck : MonoBehaviour
{

 //   [HideInInspector]
    public bool isRed, isYellow, isPink, isGreen, is1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "N")
        {
            if(other.transform.localScale.x >= .398f)
            {
                GetComponent<Renderer>().enabled = true;
                if (!isRed && !isPink && !isGreen)
                {
                    isYellow = true;
                }
            }    
        }

        if(other.tag == "K")
        {
            if (other.transform.localScale.x >= .398f)
            {
                GetComponent<Renderer>().enabled = true;
                if (!isRed && !isYellow && !isGreen)
                {
                    isPink = true;
                }
            }
        }

        if (other.tag == "S")
        {
            if (other.transform.localScale.x >= .398f)
            {
                GetComponent<Renderer>().enabled = true;
                if (!isPink && !isYellow && !isGreen)
                {
                    isRed = true;
                }
            }
        }

        if (other.tag == "B")
        {
            if (other.transform.localScale.x >= .398f)
            {
                GetComponent<Renderer>().enabled = true;
                if (!isPink && !isYellow && !isRed)
                {
                    isGreen = true;
                }
            }
        }

        if (other.tag == "Respawn")
        {
            GetComponent<Renderer>().enabled = false;
            is1 = true;
            isYellow = false;
            isRed = false;
            isPink = false;
            isGreen = false;
        }
    }
}
