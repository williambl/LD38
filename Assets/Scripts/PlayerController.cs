using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float rotateForce = 1;
	public float moveForce = 1;

	private Rigidbody rigid;

	private Gravity gravity;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		gravity = GetComponent<Gravity> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Vertical") * rotateForce;
		float y = Input.GetAxis ("Horizontal") * moveForce;

		rigid.AddRelativeForce (new Vector3 (x, 0, 0), ForceMode.VelocityChange);
		transform.localRotation *= Quaternion.Euler (new Vector3 (0, y, 0));
	}

	void FixRotation () {
		/*
		 * Here we want to align our up with the planet below us
		 * Let's see if this works:
		 */

		Vector3 up = (gravity.closestRigid.transform.position - transform.position).normalized;
		transform.rotation *= Quaternion.FromToRotation (transform.up, up);
	}
		
}
