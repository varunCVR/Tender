using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEyes : MonoBehaviour
{
    public GameObject leftPanel, rightPanel;
    public GameObject dot;
    Vector3 startPos;

    public bool skipScript;
   /* private void Awake()
    {
        startPos = dot.transform.position;
    }*/

    bool validRight,validLeft;

    private void Update()
    {

        HandleLogics();

    }
    void HandleLogics()
    {

        if (skipScript)
        {
            return;
        }
        if (InputBridge.Instance.RightTrigger >= 0.5f)
        {
            rightPanel.SetActive(true);

        }
        else
        {
            rightPanel.SetActive(false);
           
        }


        if (InputBridge.Instance.LeftTrigger >=0.5f)
        {
                leftPanel.SetActive(true);
                //dot.transform.position = new Vector3(dot.transform.position.x, dot.transform.position.y, -1.3f);

        }
        else
            {
                leftPanel.SetActive(false);
            //dot.transform.position = startPos;
        }
      
    }
}
