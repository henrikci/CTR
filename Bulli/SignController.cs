using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour {
	private SpriteRenderer stageClearSign;
	private SpriteRenderer getReadySign;
	private bool gameStarting;
	private float startTimer;
	// Use this for initialization
	void Start () {
		stageClearSign =GameObject.Find("stageClearSign").GetComponent<SpriteRenderer> ();
		getReadySign = GameObject.Find("getReadySign").GetComponent<SpriteRenderer> ();
		stageClearSign.enabled = false;
		gameStarting = true;
		getReadySign.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameStarting) {
			this.startTimer += Time.deltaTime;

			if (this.startTimer >= 2f) {
				this.gameStarting = false;
				getReadySign.enabled = false;
				this.startTimer = 0f;
			}
		}
		
	
	}

	public void OnTriggerEnter2D(Collider2D end){
		if (end.tag == "Player") {
			stageClearSign.enabled = true;
		}
	}
}
