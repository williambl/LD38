using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialGravityField : MonoBehaviour {

	Rigidbody rigid;

	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}

		other.GetComponent<PlayerGravity> ().artificialGravityObject = rigid;
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}

		other.GetComponent<PlayerGravity> ().artificialGravityObject = null;
	}
}
