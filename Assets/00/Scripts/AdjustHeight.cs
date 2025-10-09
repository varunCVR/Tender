using BNG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdjustHeight : MonoBehaviour
{
    public BNGPlayerController bc;
    public UnityEngine.UI.Slider slider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("SliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("SliderValue");
        }
        else
        {
            slider.value = slider.minValue;
        }
    }
    private void Update()
    {
        bc.ElevateCameraHeight = slider.value;
    }
    public void OnValueChange()
    {
        PlayerPrefs.SetFloat("SliderValue", slider.value);
    }      
    public void Quit()
    {
        PlayerPrefs.DeleteKey("SliderValue");
    }
}



