using System;
using UnityEngine;
using UnityEngine.UI;

public class DetectTouchMovement : MonoBehaviour
{
	public float minZoomRange  = 0.1f,maxZoomRange =0.5f;
	public float cameraXValueHelper;
	public float cameraYValueHelper;

	public float minx, maxX, minY, maxY, minZ, maxZ;
	public float zoomSpeed = 0.04f;
	const float pinchTurnRatio = Mathf.PI / 2;
	const float minTurnAngle = 0;
	
	const float pinchRatio = 1;
	const float minPinchDistance = 2f;
	
	const float panRatio = 1;
	const float minPanDistance = 0;
	
	static public float turnAngleDelta;
	static public float turnAngle;

	static public float pinchDistanceDelta;
	static public float pinchDistance;
	
	private bool moreThenOneTouch = false;
	private Vector3 worldStartPoint;

	public Text debugtext;
	public Text debugtext1;
	
	//Swipping 2nd Script
	
	Vector3 hit_position = Vector3.zero;
	Vector3 current_position = Vector3.zero;
	Vector3 camera_position = Vector3.zero;
	float z = 0.0f;

	private Transform myTransform;

	private void Start()
	{
		myTransform = transform;
	}

	private void Update()
	{
		Calculate();
		LimitPos();
	}

	void LimitPos()
	{
		cameraXValueHelper = 0.12f;
		cameraYValueHelper = 0.8f;

		Vector3 pos = transform.position;

		
		pos.x = Mathf.Clamp(pos.x, minx-cameraXValueHelper, maxX+cameraXValueHelper);
		pos.y = Mathf.Clamp(pos.y, minY-cameraYValueHelper, maxY+cameraYValueHelper);
		pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

		myTransform.position = pos;
	}

	public void Calculate () {
		pinchDistance = pinchDistanceDelta = 0;
		turnAngle = turnAngleDelta = 0;
		
		// if two fingers are touching the screen at the same time ...
		if (Input.touchCount == 2) {
			Touch touch1 = Input.touches[0];
			Touch touch2 = Input.touches[1];
			
			// ... if at least one of them moved ...
			if (touch2.phase == TouchPhase.Began ) {
				
				hit_position = (touch1.position+touch2.position)/2;
				camera_position = myTransform.position;
			}
			if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) {
				// ... check the delta distance between them ...
				
				current_position = (touch1.position+touch2.position)/2;
				
				
				//Started...
				
				
				Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
        
				// Invert direction to that terrain appears to move with the mouse.
				direction = direction * -1;
        
				Vector3 position = camera_position + direction;
        
				
				
				//Ended
				pinchDistance = Vector2.Distance(touch1.position, touch2.position);
				float prevDistance = Vector2.Distance(touch1.position - touch1.deltaPosition,
				                                      touch2.position - touch2.deltaPosition);
				pinchDistanceDelta = pinchDistance - prevDistance;
				
				// ... if it's greater than a minimum threshold, it's a pinch!
				if (Mathf.Abs(pinchDistanceDelta) > minPinchDistance) {
					pinchDistanceDelta *= pinchRatio;
					ZoomInOut(pinchDistanceDelta *(zoomSpeed*Time.deltaTime));

				} else {
					pinchDistance = pinchDistanceDelta = 0;
				}
				
				// ... or check the delta angle between them ...
				turnAngle = Angle(touch1.position, touch2.position);
				float prevTurn = Angle(touch1.position - touch1.deltaPosition,
				                       touch2.position - touch2.deltaPosition);
				turnAngleDelta = Mathf.DeltaAngle(prevTurn, turnAngle);
				
				// ... if it's greater than a minimum threshold, it's a turn!
				if (Mathf.Abs(turnAngleDelta) > minTurnAngle) {
					
					turnAngleDelta *= pinchTurnRatio;
					myTransform.position = position;

				} else {
					turnAngle = turnAngleDelta = 0;
				}
			}
		}
	}
	
	
	 void ZoomInOut(float increment)
	{
		Camera.main.orthographicSize =
			Mathf.Clamp(Camera.main.orthographicSize - increment, minZoomRange,
				maxZoomRange); //Mathf.Clamp(Camera.main.fieldOfView - increment, 10, 90);
	}
	static private float Angle (Vector2 pos1, Vector2 pos2) {
		Vector2 from = pos2 - pos1;
		Vector2 to = new Vector2(1, 0);
		
		float result = Vector2.Angle( from, to );
		Vector3 cross = Vector3.Cross( from, to );
		
		if (cross.z > 0) {
			result = 360f - result;
		}
		
		return result;
	}
}