using UnityEngine;
using System.Collections;

public class PlayerCounter : MonoBehaviour {

	public int PlayersLeft {
		get {
			return GameObject.FindGameObjectsWithTag("InactivePlayer").Length;
		}
	}
}
