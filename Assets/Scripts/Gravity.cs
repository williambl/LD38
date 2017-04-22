using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public float g = 0.1f;

	public Rigidbody[] rigids;

	private Rigidbody rigidBody;

	public void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	public void FixedUpdate () {
		foreach (Rigidbody rigid in rigids) {
			//do you like spaghetti?
			double force = g * ((rigidBody.mass * rigid.mass) / Mathf.Pow((Vector3.Distance (transform.position, rigid.transform.position)), 2f));

			rigidBody.AddForce ((rigid.transform.position - transform.position) * (float)force);
		}
	}
}
