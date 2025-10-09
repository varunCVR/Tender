using System;
using UnityEngine;
using UnityEngine.UI;

public class archConnection_hing : MonoBehaviour
{
    public bool connectGrm;

  public GameObject _300OBJhing;
  public GameObject _300OBJgrab;
  
  
    public Text for_reader;
    private float i;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clicker") && !connectGrm)
        {
            connectGrm = true;
             
            _300OBJgrab.SetActive(false);
            _300OBJhing.SetActive(true);
        }
    }

    private void Update()
    {
        if (connectGrm)
        {
            i = Mathf.Clamp(i, 0, 300);
 
            if (i<300)
            {
                i+=Time.time;
            }

            if (i > 300)
            {
                i = 300;
            }
            for_reader.text = ""+i.ToString("000");

        }
    }
}
