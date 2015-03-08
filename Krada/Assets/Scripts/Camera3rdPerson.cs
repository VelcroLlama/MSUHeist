using UnityEngine;
using System.Collections;

public class Camera3rdPerson : MonoBehaviour {

	private Vector3 PositionDelta;
	private Transform Target;

	// Use this for initialization
	void Start () {
		PositionDelta = transform.localPosition;
		Target = transform.parent;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (
			transform.rotation.eulerAngles.x, 
		    Mathf.LerpAngle (transform.rotation.eulerAngles.y, Target.rotation.eulerAngles.y, 0.8f), 
		    transform.rotation.eulerAngles.z
		);
		transform.position = Vector3.Lerp (transform.position, Target.position+Target.rotation*PositionDelta, 0.2f);
	}
}
