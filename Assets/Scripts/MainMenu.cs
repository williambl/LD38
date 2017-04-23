using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	void Update ()
	{
		if (Input.GetButtonUp ("Jump")) {
			SceneManager.LoadScene (1);
		}
	}
}
