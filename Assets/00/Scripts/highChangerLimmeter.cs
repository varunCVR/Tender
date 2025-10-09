using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highChangerLimmeter : MonoBehaviour
{
    public Transform changer;
    public Slider Sliderslider;
    Vector3 loc;

    private void Start()
    {
        Sliderslider.value = GameManager.instance.SliderValue;
        loc.y = Sliderslider.value;
        changer.position = Vector3.Lerp(changer.position, loc, Time.deltaTime * 10);

        Debug.Log(Sliderslider.value+" On Start........");
    }

    void Update()
    {
        loc.y = Sliderslider.value;
        changer.position =Vector3.Lerp(changer.position,loc,Time.deltaTime * 10);
        GameManager.instance.SliderValue = Sliderslider.value;
        Debug.Log(Sliderslider.value + " On Update........");
    }
}
