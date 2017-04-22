using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

	public float force;

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}

		other.transform.position = transform.position;

		Rigidbody rigid = other.GetComponent<Rigidbody> ();
		rigid.velocity = Vector3.zero;
		rigid.angularVelocity = Vector3.zero;
		rigid.AddForce (transform.up * force);
		Debug.Log (transform.up * force);
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}
		other.transform.localPosition += transform.up.normalized * 2;
		other.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		other.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
	}
}
