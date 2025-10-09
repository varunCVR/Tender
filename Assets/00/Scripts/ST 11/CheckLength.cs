using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckLength : MonoBehaviour
{
    public GameObject obj;
    public Material Highlight;
   
    [Space]
    [Header("Set Max Value of Distance")]
    public float max;
  
    [Space][Header("Inforamtion Text")] 
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Length;
    public TextMeshProUGUI Width;
    public TextMeshProUGUI Height;
    public TextMeshProUGUI Distance;

    GameObject HitObject;
    float value;
    LineRenderer lr;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        value = max;
    }
    private void Update()
    {
        lr.SetPosition(0, Vector3.zero);
        lr.SetPosition(1, Vector3.forward * max);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, max))
        {
            HitObject = hit.transform.gameObject;    
            if(hit.collider.tag == "N")
            {
                Info();
            }
            else
            {
                InfoNormal();
            }
           
            obj.SetActive(true);
            obj.transform.position = hit.point;
        }
        else
        {
            if (!hit.collider)
            {        
                obj.SetActive(false);
                max = value;
            }       
        }  
    }
    void Info()
    {
        Name.text = HitObject.transform.name;
        Length.text = HitObject.transform.localScale.x.ToString("") + " km";
        Width.text = HitObject.transform.localScale.z.ToString("") + " km";
        Height.text = HitObject.transform.localScale.y.ToString("") + " km";
        max = Vector3.Distance(transform.position, HitObject.transform.position);
        Distance.text = (Vector3.Distance(transform.position, HitObject.transform.position)*99999).ToString("0.00") + " km";
    }
    void InfoNormal()
    {
        Name.text = HitObject.transform.name;
        Length.text = HitObject.transform.localScale.x.ToString("") + " Meter";
        Width.text = HitObject.transform.localScale.z.ToString("") + " Meter";
        Height.text = HitObject.transform.localScale.y.ToString("") + " Meter";
        max = Vector3.Distance(transform.position, HitObject.transform.position);
        Distance.text = Vector3.Distance(transform.position, HitObject.transform.position).ToString("0.00") + " m";
    }
}
