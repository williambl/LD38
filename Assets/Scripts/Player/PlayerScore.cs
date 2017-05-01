using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	public int score = 0;

	public int health = 8;

	public PlayerController controller;

	void Start ()
	{
		controller = GetComponent<PlayerController> ();
	}

	public void AddScore (int amount)
	{
		score += amount;
		controller.PlaySound (Sound.PICKUP);
	}

	void Update ()
	{
		if (health < 1) {
			controller.Die ();
		}
	}
}
