using BNG;
using UnityEngine;

public class grabbleCondition : MonoBehaviour
{
    public enum grabtype
    {
        Grab,
        notGrab
    }
    public grabtype Grb;
    private void Start()
    {
        if (Grb == grabtype.Grab)
        {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Grabbable>().enabled = true;
        }

        if (Grb == grabtype.notGrab)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MeshCollider>().enabled = true;
            GetComponent<Grabbable>().enabled = false;
        }
    }
    private void Update()
    {
        if (Grb == grabtype.notGrab && GetComponent<Grabbable>().enabled)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MeshCollider>().enabled = true;
            GetComponent<Grabbable>().enabled = false;
        }

        if (Grb == grabtype.Grab && GetComponent<Rigidbody>().isKinematic)
        {
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Grabbable>().enabled = true;
        }
    }
}