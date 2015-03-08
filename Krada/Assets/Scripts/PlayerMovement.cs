using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public CharacterController controller;

	public float Sensitivity;
	public float Speed;
	public float SprintCoef;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, Input.GetAxis ("Mouse X") * Sensitivity, 0, Space.Self);
		var speed = Vector3.zero;
		var maxspeed = (Input.GetAxis ("Fire3") > 0 ? SprintCoef : 1) * Speed;
		speed += Vector3.forward * Input.GetAxis ("Vertical") * maxspeed;
		speed += Vector3.right * Input.GetAxis ("Horizontal") * maxspeed;
		speed = Vector3.ClampMagnitude (speed, maxspeed);
		controller.SimpleMove (this.transform.rotation * speed);
	}
}
