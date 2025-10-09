using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DigitalClock : MonoBehaviour
{
    [SerializeField] public float sec, min, hour;
    [SerializeField] public float Speed;

    public Text S;
    public Text M;
    public Text H;

    void Update()
    {
        sec += Time.deltaTime * Speed;
        
        if (sec > 60)
        {
            min += 1;
            sec = 0;
        }
       
        if (min > 60)
        {
            hour += 1;
            min = 0;
        }
       
        S.text = sec.ToString("00");
        M.text = min.ToString("00");
        H.text = hour.ToString("00");

    }
}
