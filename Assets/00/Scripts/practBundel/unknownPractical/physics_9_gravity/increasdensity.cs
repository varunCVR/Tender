using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class increasdensity : MonoBehaviour
{
    public TextMeshProUGUI texting;
    public float i = 997;
    private float interval;

    // Update is called once per frame
    void Update()
    {
        if (i < 1049)
        {
            i+=Time.deltaTime * 10;
            texting.text = "" + i.ToString("0000");
        }
    }
}