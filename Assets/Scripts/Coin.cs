using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public PlayerScore playerScore;

	void Start ()
	{
		playerScore = GameObject.Find ("Player").GetComponent<PlayerScore> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag != "Player") {
			return;
		}
		playerScore.AddScore (1);
		Destroy (this.gameObject);
	}
}
