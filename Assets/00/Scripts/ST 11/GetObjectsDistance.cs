using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetObjectsDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public Transform raycastStartPos;
    public float distance = 1000f;
    public LayerMask layerMask;
    public Material newMat;
    Material sOldMat,noldMat,milkOldMat,glassOldMat;
    public GameObject collidedObject = null;
    public List<GameObject> collidedObj;

    public Renderer s, n, milk, glass;
    [Range(0,10)]
    public int increaseFeet;

    private void Start()
    {
        sOldMat = s.material;
        noldMat = n.material;
        milkOldMat = milk.material;
        glassOldMat = glass.material;
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit,distance,layerMask))
        {
            if(hit.collider.CompareTag("S"))
            {
                distanceText.text = (Vector3.Distance(transform.position, hit.point)+ increaseFeet).ToString("0") + " Feet";
                s.material = newMat;
                n.material = noldMat;
                milk.material = milkOldMat;
                glass.material = glassOldMat;
                Debug.DrawRay(transform.position, transform.forward);
            }
            else if(hit.collider.CompareTag("N"))
            {
                distanceText.text = (Vector3.Distance(transform.position, hit.point) + increaseFeet).ToString("0") + " Feet";
                s.material = sOldMat;
                n.material = newMat;
                milk.material = milkOldMat;
                glass.material = glassOldMat;
                Debug.DrawRay(transform.position, transform.forward);
            }
            else if (hit.collider.CompareTag("milk"))
            {
                distanceText.text = (Vector3.Distance(transform.position, hit.point) + increaseFeet).ToString("0") + " Feet";
                s.material = sOldMat;
                n.material = noldMat;
                milk.material = newMat;
                glass.material = glassOldMat;
                Debug.DrawRay(transform.position, transform.forward);
            }
            else if (hit.collider.CompareTag("glass"))
            {
                distanceText.text = (Vector3.Distance(transform.position, hit.point) + increaseFeet).ToString("0") + " Feet";
                s.material = sOldMat;
                n.material = noldMat;
                milk.material = milkOldMat;
                glass.material = newMat;
                Debug.DrawRay(transform.position, transform.forward);
            }
            else
            {
                s.material = sOldMat;
                n.material = noldMat;
                milk.material = milkOldMat;
                glass.material = glassOldMat;
            }

        }
    }
}
