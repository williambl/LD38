using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}

		other.GetComponent<PlayerController> ().Win ();
	}
}
