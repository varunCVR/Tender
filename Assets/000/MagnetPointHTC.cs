using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPointHTC : MonoBehaviour
{

    public float forceFactor = 50f;

    List<Rigidbody> rgBalls = new List<Rigidbody>();
    Transform magnetPoint;

    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        foreach (Rigidbody rgbBal in rgBalls)
        {
            rgbBal.AddForce((magnetPoint.position - rgbBal.position) * forceFactor * Time.fixedDeltaTime);
        }     
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            rgBalls.Add(other.GetComponent<Rigidbody>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
            rgBalls.Remove(other.GetComponent<Rigidbody>());
    }
}
