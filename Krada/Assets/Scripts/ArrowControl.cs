using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour
{

    public Transform Goal;
    public Transform Camera;

    private Vector2 targetDir {
		get {
			var goalpos = Goal.position - Camera.position;
			return new Vector2(goalpos.x, goalpos.z).normalized;
		}
	}
	private Vector2 Forward2D{
		get {
			return new Vector2(Camera.forward.x, Camera.forward.z);
		}
	}
    private float Angle;



    void Update()
    {
		Angle = (Mathf.Atan2 (targetDir.y, targetDir.x) - Mathf.Atan2 (Forward2D.y, Forward2D.x)) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, Angle);
    }


}