using UnityEngine;
using System.Collections;

public class RobberMovement : MonoBehaviour {

	public CharacterController Controller;
	public float Speed;
	public float SeeDistance;

	private GameObject Target;
	private Vector3 SpeedVector;
	private Vector3 TargetSpeedVector;
	private bool ActivelyFollow;

	private float changeDirectionTimer;

	private Vector3 inTargetDirection{
		get {
			if(Target != null)
				return (Target.transform.position - this.transform.position).normalized;
			else
				return Vector3.zero;
		}
	}
	private Vector3 rayOrigin {
		get {
			return this.transform.position + Vector3.up * .5f;
		}
	}

	// Use this for initialization
	void Start () {
		SpeedVector = Vector3.zero;
		changeDirectionTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		changeDirectionTimer -= Time.deltaTime;
		if(Target != null && ActivelyFollow){
			TargetSpeedVector = inTargetDirection * Speed * 2;
		} else if (changeDirectionTimer <= 0) {
			changeDirectionTimer = Random.Range (0.6f, 2);
			TargetSpeedVector = Random.onUnitSphere * Speed + SpeedVector;
		}

		CheckCollision (transform.forward);
		CheckCollision (transform.right);
		CheckCollision (-transform.right);
		FindTargetAndFollow ();

		Move ();
	}

	void FindTargetAndFollow (){
		Target = GameObject.FindGameObjectWithTag ("Player");
		Ray ray = new Ray(transform.position, inTargetDirection);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, SeeDistance);
		if (hit.collider != null)
		if (hit.collider.tag == "Player" && Vector3.Dot (ray.direction, SpeedVector.normalized) > 0.2) {
			ActivelyFollow = true;
		} else {
			ActivelyFollow = false;
		}
	}

	void CheckCollision (Vector3 direction){
		Ray ray = new Ray (rayOrigin, direction);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, 1);
		if (hit.collider != null)
		if (hit.collider.tag == "Wall" || hit.collider.tag == "Robber") {
			Debug.DrawLine (hit.point, ray.origin, Color.red);
			TargetSpeedVector += hit.normal * 0.01f;
		}
	}

	void Move (){
		var maxspeed = Speed * (ActivelyFollow ? 2 : 1);
		TargetSpeedVector = TargetSpeedVector.normalized * Mathf.Lerp (TargetSpeedVector.magnitude, maxspeed, 0.1f);
		TargetSpeedVector = Vector3.ClampMagnitude (TargetSpeedVector, maxspeed);
		SpeedVector = Vector3.RotateTowards (SpeedVector, TargetSpeedVector, 0.05f, 0.1f);
		SpeedVector.y = 0;
		if (Vector3.Dot (SpeedVector, TargetSpeedVector) > 0)
			Controller.SimpleMove (SpeedVector);
		this.transform.forward = SpeedVector.normalized;
	}
}
