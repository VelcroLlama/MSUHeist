using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public CharacterController controller;

	public float Sensitivity;
	public float Speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, Input.GetAxis ("Mouse X") * Sensitivity, 0, Space.Self);
		var speed = Vector3.zero;
		speed += Vector3.forward * Input.GetAxis ("Vertical") * Speed;
		speed += Vector3.right * Input.GetAxis ("Horizontal") * Speed;
		speed = Vector3.ClampMagnitude (speed, Speed);
		controller.SimpleMove (this.transform.rotation * speed);
	}
}
