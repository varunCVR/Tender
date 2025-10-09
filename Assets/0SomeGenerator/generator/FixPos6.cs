using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class FixPos6 : MonoBehaviour
{
    public FixPos6 CoilTrigger;

    GameObject Obj;
    bool isObj;

    private int x;

    public bool isFix1;

    public bool isJointed;
    void Update()
    {
        if(isObj)
        {
            if(isFix1)
            {
                if (x != 10)
                {
                    Obj.GetComponent<Grabbable>().enabled = false;
                    Obj.GetComponent<Rigidbody>().isKinematic = true;
                }
                
                Obj.transform.position = Vector3.Lerp(Obj.transform.position, transform.position, Time.deltaTime * 3);
                Obj.transform.rotation = Quaternion.Lerp(Obj.transform.rotation, transform.rotation, Time.deltaTime * 3);
                GetComponent<Collider>().enabled = false;

                StartCoroutine(Wait());

                if (Obj.transform.position == transform.position && !isJointed)
                {
                    isJointed = true;
                }
            }
            
            if(Obj.GetComponent<Rigidbody>().useGravity)
            {
                Obj.GetComponent<Grabbable>().enabled = false;
                Obj.GetComponent<Rigidbody>().isKinematic = true;

                Obj.transform.position = Vector3.Lerp(Obj.transform.position, transform.position, Time.deltaTime * 2);
                Obj.transform.rotation = Quaternion.Lerp(Obj.transform.rotation, transform.rotation, Time.deltaTime * 2);
                GetComponent<Collider>().enabled = false;

                StartCoroutine(Wait());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.tag == "N" && other.tag == "N" || this.tag == "S" && other.tag == "S")
        {
            x = 0;
            Obj = other.gameObject;
            other.GetComponent<Collider>().enabled = false;
            isObj = true;
           
        }

        if (this.tag == "Cylinder" && other.tag == "Cylinder" || this.tag == "X" && other.tag == "X" || this.tag == "Coil" && other.tag == "Coil" )
        {
            x = 0;
            Obj = other.gameObject;
            other.GetComponent<Collider>().enabled = false;
            isObj = true;
            isFix1 = true;
           
        }

        if (this.tag == "Shaft" && other.tag == "Shaft")
        {
            if(CoilTrigger.isFix1)
            {
                x = 10;
                Obj = other.gameObject;
                //other.GetComponent<Collider>().enabled = false;
                isObj = true;
                isFix1 = true;
               
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
