using UnityEngine;

public class CheckPH : MonoBehaviour
{
    public Color PHColor;

    public GameObject Button;

    GameObject P1, P2;

    [HideInInspector]
    public bool isTime, isTime2;
    private void Update()
    {
        if(isTime)
        {
            P1.GetComponent<Renderer>().material.color = Color.Lerp(P1.GetComponent<Renderer>().material.color, PHColor, Time.deltaTime * 1);
        }

        if (isTime2)
        {
            P2.GetComponent<Renderer>().material.color = Color.Lerp(P2.GetComponent<Renderer>().material.color, PHColor, Time.deltaTime * 1);
        }

        if(isTime || isTime2)
        {
            Button.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            P1 = other.gameObject;

            if(other.GetComponent<Renderer>().material.color == new Color(1, .85f, .5f, 1))
            {
                isTime = true;          
            }
        }

        if (other.tag == "Player2")
        {
            P2 = other.gameObject;

            if (other.GetComponent<Renderer>().material.color == new Color(1, .85f, .5f, 1))
            {
                isTime2 = true;
            }
        }
    }
}
