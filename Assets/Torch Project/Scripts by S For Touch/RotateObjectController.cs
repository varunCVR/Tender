using System;
using UnityEngine;

public class RotateObjectController : MonoBehaviour
{
    public float PCRotationSpeed = 10f;
    public float MobileRotationSpeed = 0.4f;
    //Drag the camera object here
    public Camera cam;

    private Transform target;


    private void Start()
    {
        target = transform;
    }

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * PCRotationSpeed;
        float rotY = Input.GetAxis("Mouse Y") * PCRotationSpeed;

        Vector3 right = Vector3.Cross(cam.transform.up, target.position - cam.transform.position);
        Vector3 up = Vector3.Cross(target.position - cam.transform.position, right);
        target.rotation = Quaternion.AngleAxis(-rotX, up) * target.rotation;
        target.rotation = Quaternion.AngleAxis(rotY, right) * target.rotation;
    }

    void HandleZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector3 touchZeroprevPos = touchZero.position - touchZero.deltaPosition;
            Vector3 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float preMag = (touchZeroprevPos - touchOnePrevPos).magnitude;
            float currMag = (touchOne.position - touchZero.position).magnitude;

            float difference = currMag - preMag;

            ChangeScale(difference*Time.deltaTime);
        }
    }

    void ChangeScale(float differenc)
    {
        target.localScale = new Vector3(target.localScale.x+differenc,target.localScale.y+differenc,target.localScale.z+differenc);
        //debugText.text = (target.localScale + " Differnce" + differenc);
    }
    void Update ()
    {
        // get the user touch input
        foreach (Touch touch in Input.touches) {
            Debug.Log("Touching at: " + touch.position);
            Ray camRay = cam.ScreenPointToRay (touch.position);
            RaycastHit raycastHit;
            if(Physics.Raycast (camRay, out raycastHit, 10))
            {
                if (touch.phase == TouchPhase.Began) {
                    Debug.Log("Touch phase began at: " + touch.position);
                } else if (touch.phase == TouchPhase.Moved) {
                    Debug.Log("Touch phase Moved");
                    
                    //touch.deltaPosition.y * MobileRotationSpeed    put this in X axis
                    transform.Rotate (0, 
                        -touch.deltaPosition.x * MobileRotationSpeed, 0, Space.World);
                } else if (touch.phase == TouchPhase.Ended) {
                    Debug.Log("Touch phase Ended");    
                }    
            }
        }

        HandleZoom();
    }
}
