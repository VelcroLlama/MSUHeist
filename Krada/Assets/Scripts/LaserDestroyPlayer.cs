using UnityEngine;
using System.Collections;

public class LaserDestroyPlayer : MonoBehaviour {

    public GameObject targetGameObject;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player") {
			Destroy (collider.gameObject, 0.1f);
            targetGameObject.GetComponent<PlayerCounter>().ArtLost++;
		}
	}
}
