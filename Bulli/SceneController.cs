using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class SceneController : MonoBehaviour {
	private bool gameStarting;
	private float startTimer;
	private float endTimer;
	// Use this for initialization
	void Start ()
	{



	}

	void Update() {
	}


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
		}
	
	

	}
}