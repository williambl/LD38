using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float rotateSpeed = 1;
	public float moveSpeed = 1;

	private Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = Input.GetAxis ("Vertical") * rotateSpeed;
		float y = Input.GetAxis ("Horizontal") * moveSpeed;

		rigid.AddRelativeForce (new Vector3 (x, 0, 0));
		transform.localRotation *= Quaternion.Euler (new Vector3 (0, y, 0));
	}
}
