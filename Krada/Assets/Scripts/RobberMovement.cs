using UnityEngine;
using System.Collections;

public class RobberMovement : MonoBehaviour {

	public CharacterController Controller;
	public float Speed;
	public float SeeDistance;

	private GameObject Target;
	private Vector3 Direction;
	private Vector3 TargetDirection;
	private bool ActivelyFollow;

	private float changeDirectionTimer;

	private Vector3 inTargetDirection{
		get {
			if(Target != null)
				return Target.transform.position - this.transform.position;
			else
				return Vector3.zero;
		}
	}

	// Use this for initialization
	void Start () {
		Direction = Vector3.zero;
		changeDirectionTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		changeDirectionTimer -= Time.deltaTime;
		if(Target != null && ActivelyFollow){
			TargetDirection = inTargetDirection;
		} else if (changeDirectionTimer <= 0) {
			changeDirectionTimer = Random.Range (0.5f, 3);
			TargetDirection = Random.onUnitSphere + Direction.normalized;
		}

		FindTargetAndFollow ();

		Move ();
	}

	void FindTargetAndFollow (){
		Target = GameObject.FindGameObjectWithTag ("Player");
		Ray ray = new Ray(this.transform.position, inTargetDirection);
		Debug.DrawRay (ray.origin, ray.direction, Color.white, SeeDistance, true);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, SeeDistance);
		if (hit.collider != null)
		if (hit.collider.tag == "Player" && Vector3.Dot (ray.direction, Direction.normalized) > 0.2) {
			ActivelyFollow = true;
		} else if (hit.collider.tag == "Wall" && Vector3.Distance (hit.point, ray.origin) < 1) {
			ActivelyFollow = false;
			TargetDirection = Quaternion.Euler (0, 90, 0) * hit.normal;
		} else {
			ActivelyFollow = false;
		}
	}

	void Move (){
		Direction = Vector3.RotateTowards (Direction, TargetDirection, 0.02f, 10000f);
		Direction.y = 0;
		Controller.SimpleMove (Direction.normalized * Speed * (ActivelyFollow ? 2 : 1));
	}
}
