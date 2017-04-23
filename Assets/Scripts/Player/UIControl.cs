using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {

	public PlayerScore playerScore;

	public Image health;
	public Text score;

	public Image end;

	// Use this for initialization
	void Start () {
		playerScore = GetComponent<PlayerScore> ();
		end.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		health.fillAmount = playerScore.health / 8f;
		score.text = "Score: " + playerScore.score;
	}

	public void Lose () {
		end.gameObject.SetActive (true);

		end.GetComponentInChildren<Text> ().text = "You lost. Better luck next time!";
	}

	public void Win () {
		end.gameObject.SetActive (true);

		end.GetComponentInChildren<Text> ().text = "You win! Well done!";
	}
}
