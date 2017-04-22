﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : Gravity {

	public Rigidbody artificialGravityObject;

	public void FixedUpdate () {

		if (artificialGravityObject != null) {
			rigidBody.AddForce (Vector3.down * g * ((rigidBody.mass * artificialGravityObject.mass) 
				/ Mathf.Pow(Vector3.Distance (transform.position, artificialGravityObject.transform.position), 2f)));
	
			return;
		}

		float closestDist = 999;
		foreach (Rigidbody rigid in rigids) {
			float dist = Vector3.Distance (transform.position, rigid.transform.position);

			if (dist < closestDist) {
				closestDist = dist;
				closestRigid = rigid;
			}
		}

		double force = g * ((rigidBody.mass * closestRigid.mass) / Mathf.Pow(closestDist, 2f));

		rigidBody.AddForce ((closestRigid.transform.position - transform.position) * (float)force, ForceMode.Acceleration);
	}
}
