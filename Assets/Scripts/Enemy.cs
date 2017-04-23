using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	NavMeshAgent agent;

	public List<Vector3> points = new List<Vector3>();
	public Transform player;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

		foreach (GameObject point in GameObject.FindGameObjectsWithTag ("navPoint")) {
			points.Add (point.transform.position);
		}
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * If player is within 10m, we go to them.
		 * If the player is closer than 0.5m, we stop moving.
		 * If not, then we go between a fixed set of points.
		 * Once we are within 0.5m of a point, then we find a new one.
		 */


		if (Vector3.Distance (player.position, transform.position) < 0.5) {
			agent.destination = transform.position;
			agent.enabled = false;
			return;
		} else if (Vector3.Distance (player.position, transform.position) < 10) {
			agent.destination = player.position;
			agent.enabled = true;
			return;
		} else if (points.Contains (agent.destination)) {
			if (agent.remainingDistance < 0.5) {
				agent.destination = points [Mathf.RoundToInt (Random.value * points.Count)];
			}
		} else {
			agent.destination = points [Mathf.RoundToInt (Random.value * points.Count)];
		}

	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag != "Player") {
			return;
		}
		PlayerScore score = collision.gameObject.GetComponent<PlayerScore> ();

		score.health--;
		transform.localPosition += new Vector3 (0, -1, 0);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag != "Player") {
			return;
		}
		collider.gameObject.GetComponent<PlayerScore> ().score += 5;
		Destroy (gameObject);
	}
}
