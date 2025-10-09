using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetAngle : MonoBehaviour
{
    public TextMeshProUGUI angleText;
    public Transform secTransform;
    public Transform thirdTransform;
    public WeighHandler handler;

    public GameObject normalCube;


    private void Update()
    {
        if(handler.targetObj == null)
        {
            float angle = GetVectorInternalAngle(normalCube.transform.position, secTransform.position, thirdTransform.position);
            angleText.text = 180f + "\u00B0";
        }
        else
        {
            float angle = GetVectorInternalAngle(transform.position, secTransform.position, thirdTransform.position);
            angleText.text = angle.ToString("00") + "\u00B0";
        }
        
    }


    public static float GetVectorInternalAngle(Vector3 a, Vector3 b, Vector3 c)
    {
        return Vector3.Angle(b - a, c - a);
    }

}
