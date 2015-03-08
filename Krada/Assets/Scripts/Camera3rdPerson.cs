using UnityEngine;
using System.Collections;

public class Camera3rdPerson : MonoBehaviour {

	private Vector3 PositionDelta;
	private Transform Target;
	private float VerticalRotation;

	// Use this for initialization
	void Start () {
		PositionDelta = transform.localPosition;
		Target = transform.parent;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (
			VerticalRotation, 
		    Mathf.LerpAngle (transform.rotation.eulerAngles.y, Target.rotation.eulerAngles.y, 0.8f), 
		    transform.rotation.eulerAngles.z
		);
		transform.position = Vector3.Lerp (transform.position, Target.position+Target.rotation*PositionDelta, 0.3f);
		RaycastHit hit;
		var direction = transform.position - Target.position;
		direction.Normalize ();
		Physics.Raycast (Target.position + direction * 0.2f, direction, out hit, PositionDelta.magnitude);
		if (hit.collider)
			this.transform.position = hit.point - direction * 0.1f;

		VerticalRotation -= Input.GetAxis ("Mouse Y");
		VerticalRotation = Mathf.Clamp (VerticalRotation, -20, 20);
	}
}
