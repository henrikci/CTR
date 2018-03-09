using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	void Update ()
	{
		///Loads the main menu if the player presses Esc to allow quitting the game
		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}
}
