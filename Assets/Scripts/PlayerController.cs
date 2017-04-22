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
		float x = Input.GetAxis ("Vertical") * moveForce;
		float y = Input.GetAxis ("Horizontal") * rotateForce;

		rigid.AddRelativeForce (new Vector3 (x, 0, 0));
		transform.localRotation *= Quaternion.Euler (new Vector3 (0, y, 0));

		FixRotation ();
	}

	void FixRotation () {
		/*
		 * Here we want to align our up with the planet below us
		 * Let's see if this works:
		 */

		RaycastHit hit;
		Physics.Raycast (transform.position, -transform.up, out hit, 10f);
		Vector3 up = transform.position - gravity.closestRigid.transform.position;
		up = Vector3.Normalize (up);
		Debug.DrawRay (transform.position, up, Color.cyan);
		Debug.DrawRay (transform.position, hit.normal, Color.green);
		Debug.DrawRay (transform.position, transform.up, Color.red);
		//transform.rotation *= Quaternion.FromToRotation (transform.up, hit.normal);
		transform.up = hit.normal;
	}
		
}
