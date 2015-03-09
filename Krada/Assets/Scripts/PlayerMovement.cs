using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public CharacterController controller;

	public float Sensitivity;
	public float Speed;
	public float SprintCoef;

	private Vector3 DownSpeed;
	private bool CanJump;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CanJump && Input.GetAxis ("Jump") > 0) {
			CanJump = false;
			DownSpeed = Vector3.up;
		}
		this.transform.Rotate (0, Input.GetAxis ("Mouse X") * Time.deltaTime * Sensitivity, 0, Space.Self);
		var speed = Vector3.zero;
		var maxspeed = (Input.GetAxis ("Fire3") > 0 ? SprintCoef : 1) * Speed;
		speed += Vector3.forward * Input.GetAxis ("Vertical") * maxspeed;
		speed += Vector3.right * Input.GetAxis ("Horizontal") * maxspeed;
		speed = Vector3.ClampMagnitude (speed, maxspeed);
		DownSpeed += Physics.gravity * Time.deltaTime;
		speed += DownSpeed;
		controller.Move (this.transform.rotation * speed * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.collider.name == "Floor") {
			DownSpeed = Vector3.zero;
			CanJump = true;
		}
	}

	public void Activate(){
		this.enabled = true;
	}
}
