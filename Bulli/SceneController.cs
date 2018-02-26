using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {
	
	// Use this for initialization
	void Start ()
	{

	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
	
		}
	}


}