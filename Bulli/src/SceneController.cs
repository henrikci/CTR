using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Scene controller script.
/// </summary>
public class SceneController : MonoBehaviour
{
	
	/// <summary>
	/// Loads the next scene in the build index on collision with a trigger zone
	/// </summary>
	/// <param name="other">Collider to check if the collider is the player character</param>
	public void OnTriggerEnter2D (Collider2D player)
	{
		if (player.tag == "Player") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
		}
	}
}