using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerAssignController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		activateNext ();
	}

	private bool activateNext(){
		var player = GameObject.FindGameObjectWithTag ("InactivePlayer");
		if (player != null) {
			player.GetComponent<PlayerMovement>().Activate();
			return true;
		}
		return false;
	}

	private GameObject[] inactivePlayers(){
		return GameObject.FindGameObjectsWithTag ("InactivePlayer");
	}
}
