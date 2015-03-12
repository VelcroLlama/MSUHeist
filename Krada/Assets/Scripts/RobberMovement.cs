using UnityEngine;
using System.Collections;

public class RobberMovement : MonoBehaviour {

	public CharacterController Controller;
	public float Speed;
	public float SprintCoef;
	public float SeeDistance;
	public float SeeAlwaysDistance;
	public float GrabDistance;
	public float GrabDuration;
	public float RayCastHeight;
    public Animator robberAnim;
    public GameObject targetGameObject;
    
	private GameObject Target;
	private Vector3 SpeedVector;
	private Vector3 TargetSpeedVector;
	private bool ActivelyFollow;

	private float changeDirectionTimer;

	private Vector3 targetDelta {
		get {
			if (Target != null) {
				var vec = Target.transform.position - transform.position;
				vec.y = 0;
				return vec;
			}
			return Vector3.zero;
		}
	}
	private Vector3 inTargetDirection{
		get {
			if(Target != null)
				return (Target.transform.position - rayOrigin).normalized;
			else
				return Vector3.zero;
		}
	}
	private Vector3 rayOrigin {
		get {
			return this.transform.position + Vector3.up * RayCastHeight;
		}
	}

	// Use this for initialization
	void Start () {
		SpeedVector = Vector3.zero;
		TargetSpeedVector = transform.forward * Speed;
		changeDirectionTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        robberAnim.SetBool("Grabbing", false);
        changeDirectionTimer -= Time.deltaTime;
		if(Target != null && ActivelyFollow){
			TargetSpeedVector = targetDelta.normalized * Speed * SprintCoef;
		} else if (changeDirectionTimer <= 0) {
			changeDirectionTimer = Random.Range (0.5f, 3f);
			TargetSpeedVector = Random.onUnitSphere * 0.05f + SpeedVector;
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
			Ray ray = new Ray(rayOrigin, inTargetDirection);
			RaycastHit hit;
			Physics.Raycast (ray, out hit);
			Debug.Log(hit.collider.name);
			if (hit.collider != null)
			if (hit.collider.tag == "PlayerBody" && 
					(Vector3.Dot (ray.direction, SpeedVector.normalized) > 0 && 
					targetDelta.magnitude < SeeDistance || targetDelta.magnitude < SeeAlwaysDistance)) {
				if(targetDelta.magnitude < GrabDistance && t.transform.parent.GetComponent<PlayerMovement>().enabled){
					GrabPlayer(t.transform.parent.gameObject);
				}
				ActivelyFollow = true;
				robberAnim.SetBool("Running", true);
				Debug.DrawLine(ray.origin, hit.point, Color.green);
				return;
			}
			Debug.DrawLine(ray.origin, hit.point, Color.red);
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
        robberAnim.SetTrigger("Grabbing");
        player.GetComponent<PlayerMovement> ().enabled = false;
		Destroy(player, GrabDuration);
		targetGameObject.GetComponent<PlayerCounter> ().ArtLost++;
	}
}