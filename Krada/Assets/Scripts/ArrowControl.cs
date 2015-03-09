using UnityEngine;
using System.Collections;

public class ArrowControl : MonoBehaviour
{

    public Transform Goal;
    public Transform Camera;

    private Vector3 GoalPosition;
    private Vector3 CameraPosition;
    private Vector3 targetDir;
    private Vector3 Forward;
    private float Angle;



    void Update()
    {

        GoalPosition = new Vector3(Goal.position.x, 0, Goal.position.z);
        CameraPosition = new Vector3(Camera.position.x, 0, Camera.position.z);
        targetDir = GoalPosition - CameraPosition;
        Forward = Camera.transform.forward;
        Angle = Vector3.Angle(targetDir, Forward);
        if(true)
        transform.localRotation = Quaternion.Euler(0, 0, Angle);
     
    }


}