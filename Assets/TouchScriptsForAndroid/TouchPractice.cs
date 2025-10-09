using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchPractice : MonoBehaviour
{
    float distance = 0f;
    private Transform targetTransform = null;
    private float yPos, zPos, minX, maxX;
    
    public float timer;
    public TextMeshProUGUI text;

    public ShootLaserSecForAndroid laser;
    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Player")
                    {
                        targetTransform = hit.transform;
                        laser.isOn = true;
                    }
                    else
                    {
                        targetTransform = null;
                    }
                }
                if(targetTransform)
                this.distance = Vector3.Distance(ray.origin, this.targetTransform.position);
            }else if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider.tag == "Player")
                    {
                        targetTransform = hit.transform;
                    }
                    else
                    {
                        targetTransform = null;
                    }
                }

                if (targetTransform)
                {
                    this.targetTransform.position = new Vector3(ray.origin.x+ray.direction.x*distance,targetTransform.position.y,targetTransform.position.z);//ray.origin + ray.direction * distance;
                    //targetTransform.GetComponent<TouchMove>().LimitPos();
                }
                    
            }else if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    
                    if (hit.collider.tag == "Player")
                    {
                        targetTransform = null;
                        laser.isOn = false;
                    }
                }
            }
        }
    }

    /*void OnMouseDown()
    {

        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        this.distance = Vector3.Distance(ray.origin, this.transform.position);
    }
 
    void OnMouseDrag()
    {
        Touch touch = Input.GetTouch(0);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        this.transform.position = ray.origin + ray.direction * distance;
    }*/
}
