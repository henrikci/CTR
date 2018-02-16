using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			SceneManager.LoadScene("levelSelectLevelVantaaOpened", LoadSceneMode.Single);
		}
	}
}