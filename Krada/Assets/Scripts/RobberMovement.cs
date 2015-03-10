using UnityEngine;
using System.Collections;

public class RobberMovement : MonoBehaviour {

	public CharacterController Controller;
	public float Speed;
	public float SprintCoef;
	public float SeeDistance;
	public float GrabDistance;
	public float GrabDuration;
    public Animator robberAnim;

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
        robberAnim.SetBool("Grabbing", false);
        changeDirectionTimer -= Time.deltaTime;
		if(Target != null && ActivelyFollow){
			TargetSpeedVector = inTargetDirection * Speed * SprintCoef;
		} else if (changeDirectionTimer <= 0) {
			changeDirectionTimer = Random.Range (0.6f, 2);
			TargetSpeedVector = Random.onUnitSphere * Speed + SpeedVector;
		}

		if (CheckCollision (transform.right, 0.02f))
			CheckCollision (transform.forward, 0.08f);
		else if (CheckCollision (-transform.right, -0.02f))
			CheckCollision (transform.forward, -0.08f);
		else
			CheckCollision (transform.forward, 0.08f);

		FindTargetAndFollow ();

		Move ();
        
	}

	void FindTargetAndFollow (){
		var Targets = GameObject.FindGameObjectsWithTag ("PlayerBody");
		foreach (var t in Targets) {
			Target = t;
			Ray ray = new Ray(transform.position, inTargetDirection);
			RaycastHit hit;
			Physics.Raycast (ray, out hit, SeeDistance, 8);
			if (hit.collider != null)
			if (hit.collider.tag == "PlayerBody" && Vector3.Dot (ray.direction, SpeedVector.normalized) > 0.2) {
				if(hit.distance < GrabDistance){
					GrabPlayer(t);
				}
				ActivelyFollow = true;
				robberAnim.SetBool("Running", true);
				return;
			}
		}
		ActivelyFollow = false;
		robberAnim.SetBool("Running", false);
	}
	
	bool CheckCollision (Vector3 direction, float coef){
		Ray ray = new Ray (rayOrigin, direction);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, 0.8f);
		if (hit.collider != null)
		if (hit.collider.tag == "Wall" || hit.collider.tag == "Robber" || hit.collider.tag == "LaserWall") {
			Debug.DrawLine (hit.point, ray.origin, Color.red);
			var normal = Quaternion.AngleAxis(90, Vector3.up) * hit.normal;
			TargetSpeedVector += coef * Mathf.Clamp(1-hit.distance, 0, 1) * normal;
			return true;
		}
		return false;
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

	void GrabPlayer(GameObject player){
		var movement = player.GetComponent<PlayerMovement> ();
		if (movement != null) {
			movement.enabled = false;
			Destroy(player, GrabDuration);
		}
	}
}