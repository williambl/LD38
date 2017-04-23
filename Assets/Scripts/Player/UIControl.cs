using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public PlayerScore playerScore;

	public Image health;
	public Text score;

	// Use this for initialization
	void Start () {
		playerScore = GetComponent<PlayerScore> ();
	}
	
	// Update is called once per frame
	void Update () {
		health.fillAmount = playerScore.health / 8f;
		score.text = "Score: " + playerScore.score;
	}
}
