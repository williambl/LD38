
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float rotateForce = 1;
	public float moveForce = 1;
	public float jumpForce = 1;

	private Rigidbody rigid;

	private PlayerGravity gravity;

	public bool isGrounded = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		gravity = GetComponent<PlayerGravity> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Vertical") * moveForce;
		float y = Input.GetAxis ("Horizontal") * rotateForce;

		if (isGrounded) {
			rigid.AddRelativeForce (new Vector3 (0, 0, x));
			transform.localRotation *= Quaternion.Euler (new Vector3 (0, y, 0));

			if (Input.GetButtonDown ("Jump")) {
				rigid.AddRelativeForce (new Vector3 (0, jumpForce, 0));
			}
		}

		FixRotation ();
	}

	void FixRotation () {
		/*
		 * Here we want to align our up with the planet below us,
		 * unless we are in an artificial gravity field. Then we
		 * align with the surface below us.
		 */

		if (gravity.artificialGravityObject != null) {
			RaycastHit hit1;
			Physics.Raycast (transform.position, -transform.up, out hit1, 15f);
			transform.rotation = Quaternion.FromToRotation (transform.up, hit1.normal) * transform.rotation;
			return;
		}
		if (gravity.closestRigid == null) {
			return;
		}
		Vector3 planetDir = -(transform.position - gravity.closestRigid.transform.position);
		RaycastHit hit;
		Physics.Raycast (transform.position, planetDir, out hit, 15f);
		Debug.DrawRay (transform.position, planetDir, Color.cyan, 5f);
		Debug.DrawRay (hit.point, hit.normal, Color.green, 5f);
		Debug.DrawRay (transform.position, transform.up, Color.red, 5f);
		transform.rotation = Quaternion.FromToRotation (transform.up, hit.normal) * transform.rotation;
	}

	void OnCollisionEnter (Collision collision) 
	{
		isGrounded = true;
	}

	void OnCollisionExit (Collision collision) 
	{
		isGrounded = false;
	}
}
