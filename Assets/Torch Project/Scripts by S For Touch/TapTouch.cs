using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapTouch : MonoBehaviour
{
    public GameObject target;
    public GameObject oldTarget;

    public Text debugText;

    private int index;
    
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
                    if(oldTarget)
                        debugText.text = oldTarget.name;

                        target = hit.transform.gameObject.GetComponent<DialogueHolder>().myDialogue;
                        hit.transform.gameObject.GetComponent<DialogueHolder>().ShowMyDialogue(oldTarget);
                       
                    }
                    else
                    {
                        //target = null;
                    }
                }
            }else if (touch.phase == TouchPhase.Ended)
            {
                if (target)
                {
                    oldTarget = target;
                }
            }
        }
    }
}
