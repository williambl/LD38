using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public float g = 0.1f;

	public Rigidbody[] rigids;

	protected Rigidbody rigidBody;

	public Rigidbody closestRigid;

	public void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	public void FixedUpdate () {

		float closestDist = 999;
		foreach (Rigidbody rigid in rigids) {
			float dist = Vector3.Distance (transform.position, rigid.transform.position);

			if (dist < closestDist) {
				closestDist = dist;
				closestRigid = rigid;
			}

			double force = g * ((rigidBody.mass * rigid.mass) / Mathf.Pow(dist, 2f));

			rigidBody.AddForce ((rigid.transform.position - transform.position) * (float)force);

		}

	}
}
