using UnityEngine;
using System.Collections;

public class VaultAnimatorAndTrigger : MonoBehaviour {

    public Animator vault;
    private Animator screen;
    private bool count = false;
    private float lastTime=0;
    private float timePassed=0;
    private bool CanClose=false;


	void Start () {
		screen = GameObject.FindGameObjectWithTag ("BlackScreen").GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Trigger entered!");
		if (other.tag == "Player") {
			vault.SetBool("Entered", true);
			Destroy(other.gameObject, 0.4f);
			count = true;
			lastTime = Time.timeSinceLevelLoad;
			CanClose=true;
			if (screen != null){
				Time.timeScale = 0;
				screen.SetBool("Open", true);
			}
		}
	}

	// Update is called once per frame
	void Update () {
        if (CanClose)
		{
			if (screen != null)
				screen.SetBool("Open", false);
            CanClose = false;
        }

        if (count)
        {
            timePassed += (Time.timeSinceLevelLoad - lastTime);
            lastTime = Time.timeSinceLevelLoad;
            if (timePassed > 4)
            {
                count = false;
                timePassed = 0;
                lastTime = 0;
                Time.timeScale = 1;
            }
        }

	}
}
