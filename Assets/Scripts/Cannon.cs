using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public Vector3 force;

	void OnTriggerEnter (Collider other)
	{
		other.GetComponent<Rigidbody> ().AddRelativeForce (force);
	}
}
