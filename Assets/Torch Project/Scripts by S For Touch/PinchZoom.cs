using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchZoom : MonoBehaviour
{
    private Vector3 touchStart;
    private Camera camera;
    private Transform cameraTransform;

    public float zoomInOutSpeed = 0.3f;
    public float zoomInMin = 5, zoomOutMax = 90;
    public float scaleSpeed;

    public Transform target;

    private Vector3 camPos;

    private Vector3 oldDirection;
    public Text debugText;
    
    private bool moreThenOneTouch = false;
    private Vector3 worldStartPoint;

    void HandleSwipes() {

        Touch currentTouch;
        // only work with one touch
        if (Input.touchCount == 1 && !moreThenOneTouch) {
            currentTouch = Input.GetTouch(0);

            if (currentTouch.phase == TouchPhase.Began) {
                this.worldStartPoint = Camera.main.ScreenToViewportPoint(currentTouch.position);
            }

            if (currentTouch.phase == TouchPhase.Moved) {
                Vector3 worldDelta = Camera.main.ScreenToViewportPoint(currentTouch.position) - this.worldStartPoint;
            
                Camera.main.transform.Translate(
                    -worldDelta.x,
                    -worldDelta.y,
                    0
                );
            }
    
        }

        if (Input.touchCount > 1) {
            moreThenOneTouch = true;
        } else {
            moreThenOneTouch = false;
            if(Input.touchCount == 1)
                this.worldStartPoint = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position);
        }
    }

    void HandleSwipeBuggy()
    {
        Vector3 mouseposition = Input.mousePosition; //Find Mouse Position
        mouseposition = Camera.main.ScreenToViewportPoint(mouseposition);
        
        Debug.Log("Mouse Position..." + mouseposition);
        
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = camera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector3 touchZeroprevPos = touchZero.position - touchZero.deltaPosition;
            Vector3 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float preMag = (touchZeroprevPos - touchOnePrevPos).magnitude;
            float currMag = (touchOne.position - touchZero.position).magnitude;

            float difference = currMag - preMag;

            ZoomInOut(difference * zoomInOutSpeed);
            ChangeScale(difference*Time.deltaTime);
        }else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - camera.ScreenToViewportPoint(Input.mousePosition);
            if (direction != oldDirection)
            {
                cameraTransform.position += direction;
            }
            oldDirection = direction;
            
            Debug.Log("Directions is..." + direction);
        }

        ZoomInOut(Input.GetAxis("Mouse ScrollWheel"));
    }
    private void Start()
    {
        camera = GetComponent<Camera>();
        cameraTransform = transform;
        camPos = cameraTransform.position;
    }

    public void ResetCameraPosition()
    {
        cameraTransform.position = camPos;
    }
    private void Update()
    {
        
        HandleSwipes();
       //HandleSwipeBuggy();
    }

    void ChangeScale(float differenc)
    {
        target.localScale = new Vector3(target.localScale.x+differenc,target.localScale.y+differenc,target.localScale.z+differenc);
        debugText.text = (target.localScale + " Differnce" + differenc);
    }
    void ZoomInOut(float increment)
    {
        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - increment, zoomInMin, zoomOutMax);
    }
}

