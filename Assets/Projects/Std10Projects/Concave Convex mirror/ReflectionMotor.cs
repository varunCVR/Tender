using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ReflectionMotor : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField inputField;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, slider.value, 0);
    }

    public void SetSliderValue()
    {
        float number;
        var isNumeric = float.TryParse(inputField.text, out number);
        if (isNumeric) slider.value = float.Parse(inputField.text);
    }
}