using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Main menu button controller script.
/// </summary>
public class MainMenuButtons : MonoBehaviour {


	/// <summary>
	/// Loads the scenes by their index numbers.
	/// </summary>
	/// <param name="sceneIndex">Scene index.</param>
	public void LoadByIndex (int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	/// <summary>
	/// Exits the game.
	/// </summary>
	public void ExitTheGame()
	{
		Application.Quit ();

	}
}

