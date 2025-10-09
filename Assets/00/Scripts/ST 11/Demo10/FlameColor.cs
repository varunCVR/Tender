using UnityEngine;

public class FlameColor : MonoBehaviour
{
    public GameObject[] Fire;

    public PasteCheck Paste;

    [Space]
    public Color NaColor;
    public Color NaOuterColor;
    public float NaOuterSize;
   
    [Space]
    public Color PColor;
    public Color POuterColor;
    public float POuterSize;
   
    [Space]
    public Color SrColor;
    public Color SrOuterColor;
    public float SROuterSize;

    [Space]
    public Color BaColor;
    public Color BaOuterColor;
    public float BaOuterSize;

    [HideInInspector]
    public bool isDefault;
    public bool isfix;
    public bool isNa, isP;
    public bool isSr, isBa;

     Color DefaultColor, DefaultOuterColor;
     float DefaultOuterSize;
    private void Start()
    {
        foreach (GameObject obj in Fire)
        {
            DefaultColor = obj.GetComponent<Renderer>().material.GetColor("Color_E29E6C60");
            DefaultOuterColor = obj.GetComponent<Renderer>().material.GetColor("Color_89D2C634");
            DefaultOuterSize = obj.GetComponent<Renderer>().material.GetFloat("Vector1_D8127884");
        }
    }

    void Update()
    {
        if(isDefault)
        {
            foreach(GameObject obj in Fire)
            {
                obj.GetComponent<Renderer>().material.SetColor("Color_E29E6C60", DefaultColor);
                obj.GetComponent<Renderer>().material.SetColor("Color_89D2C634", DefaultOuterColor);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_D8127884", DefaultOuterSize);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_5F10D5CF", .8f);
            }
        }

        if(isNa)
        {
            foreach (GameObject obj in Fire)
            {
                obj.GetComponent<Renderer>().material.SetColor("Color_E29E6C60", NaColor);
                obj.GetComponent<Renderer>().material.SetColor("Color_89D2C634", NaOuterColor);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_D8127884", NaOuterSize);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_5F10D5CF", 1.3f);
            }
        }

        if (isP)
        {
            foreach (GameObject obj in Fire)
            {
                obj.GetComponent<Renderer>().material.SetColor("Color_E29E6C60", PColor);
                obj.GetComponent<Renderer>().material.SetColor("Color_89D2C634", POuterColor);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_D8127884", POuterSize);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_5F10D5CF", 1.3f);
            }
        }

        if (isSr)
        {
            foreach (GameObject obj in Fire)
            {
                obj.GetComponent<Renderer>().material.SetColor("Color_E29E6C60", SrColor);
                obj.GetComponent<Renderer>().material.SetColor("Color_89D2C634", SrOuterColor);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_D8127884", SROuterSize);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_5F10D5CF", 1.3f);
            }
        }

        if (isBa)
        {
            foreach (GameObject obj in Fire)
            {
                obj.GetComponent<Renderer>().material.SetColor("Color_E29E6C60", BaColor);
                obj.GetComponent<Renderer>().material.SetColor("Color_89D2C634", BaOuterColor);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_D8127884", BaOuterSize);
                obj.GetComponent<Renderer>().material.SetFloat("Vector1_5F10D5CF", 1.3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Paste.is1)
        {
            isfix = true;
        }

        if(other.tag == "Player" && Paste.isYellow)
        {
            isDefault = false;
            isNa = true;
        }

        if (other.tag == "Player" && Paste.isPink)
        {
            isDefault = false;
            isP = true;
        }

        if (other.tag == "Player" && Paste.isRed)
        {
            isDefault = false;
            isSr = true;
        }

        if (other.tag == "Player" && Paste.isGreen)
        {
            isDefault = false;
            isBa = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isDefault = true;
            isNa = false;
            isP = false;
            isSr = false;
            isBa = false;
        }
    }
}
