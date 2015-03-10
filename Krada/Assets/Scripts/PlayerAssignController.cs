using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerAssignController : MonoBehaviour {

	private bool gameFinished;
	
	void Update(){
		// If there is no active player, try activate it.
		if (GameObject.FindGameObjectsWithTag("Player").Length == 0) {
			// If the activation is not succesful, game is finished. Otherwise,
			// everything continues
			gameFinished = !activateNext();
		}
	}

	private bool activateNext(){
		var player = GameObject.FindGameObjectWithTag ("InactivePlayer");
		if (player != null) {
			player.tag = "Player";
			player.GetComponent<PlayerMovement>().Activate();
			return true;
		}
		return false;
	}

	private GameObject[] inactivePlayers(){
		return GameObject.FindGameObjectsWithTag ("InactivePlayer");
	}
}
