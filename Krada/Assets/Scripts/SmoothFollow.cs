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
		
		float wantedRotationAngle = Target.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, Time.deltaTime / Smoothness);
		var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// distance meters behind the target
		transform.position = Target.position;
		transform.position += currentRotation * PositionDelta;

		transform.LookAt (Target.position);

		RaycastHit hit;
		var direction = transform.position - Target.position;
		direction.Normalize ();
		Physics.Raycast (Target.position + direction * 0.1f, direction * 0.9f, out hit, PositionDelta.magnitude);
		if (hit.collider)
			this.transform.position = hit.point - direction * 0.1f;
		
		verticalRotation -= Input.GetAxis ("Mouse Y") * Time.deltaTime * VerticalSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -20, 20);
		transform.rotation = Quaternion.Euler (verticalRotation, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}
}