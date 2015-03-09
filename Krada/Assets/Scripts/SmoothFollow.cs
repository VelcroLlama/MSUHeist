using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	
	public float VerticalSensitivity;
	public float Smoothness = 0.1f;

	private Vector3 PositionDelta;
	private Transform Target;

	private float verticalRotation;
	
	// Use this for initialization
	void Start () {
		PositionDelta = transform.localPosition;
		Target = transform.parent;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Target == null)
			return;
		float rotationAngle = Target.eulerAngles.y;
		// Damp the rotation around the y-axis
		var currentRotation = Quaternion.Euler(0, rotationAngle, 0);

		// distance meters behind the target
		var wantedPosition = Target.position;
		wantedPosition += currentRotation * PositionDelta;

		RaycastHit hit;
		var direction = wantedPosition - Target.position;
		var offset = 0.05f;
		direction.Normalize ();
		Physics.Raycast (Target.position + direction * offset, direction, out hit, PositionDelta.magnitude);
		if (hit.collider) {
			var point = hit.point - direction * offset;
			var distance = Vector3.Distance(Target.position, point);
			var vx2 = new Vector3(direction.x, 0, direction.z).sqrMagnitude * distance;
			point += 0.5f * Vector3.up * (Mathf.Sqrt(PositionDelta.sqrMagnitude - vx2));
			wantedPosition = point;
		}

		transform.position = Vector3.Lerp (transform.position, wantedPosition, 0.1f);
		transform.LookAt (Target.position);

		verticalRotation -= Input.GetAxis ("Mouse Y") * Time.deltaTime * VerticalSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -20, +40);
		transform.rotation = Quaternion.Euler (verticalRotation, 
		                                       transform.rotation.eulerAngles.y, 
		                                       transform.rotation.eulerAngles.z);
	}
}