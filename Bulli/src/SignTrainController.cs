using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTrainController : MonoBehaviour {
	private SpriteRenderer stageClearSign;
	private SpriteRenderer getReadySign;
	private SpriteRenderer youDiedSign;
	private SpriteRenderer trainSign;
	private float startTimer;
	public float deathTimer;
	private BullTrainController control;
	// Use this for initialization
	void Start () {
		
		stageClearSign = GameObject.Find ("stageClearSign").GetComponent<SpriteRenderer> ();
		getReadySign = GameObject.Find ("getReadySign").GetComponent<SpriteRenderer> ();
		youDiedSign = GameObject.Find ("youDiedSign").GetComponent<SpriteRenderer> ();

		control = FindObjectOfType (typeof(BullTrainController)) as BullTrainController;
		youDiedSign.enabled = false;
		stageClearSign.enabled = false;

	}
	// Update is called once per frame
	void Update () {		
	}
	public IEnumerator DeathSign(){
		ShowYouDiedSign ();
		yield return new WaitForSeconds (1.5f);
		HideYouDiedSign ();
	}

	public IEnumerator GetReady(){
		ShowGetReadySign ();
		control.EnableMovement ();
		yield return new WaitForSeconds(2f);
		HideGetReadySign();
	}

	public void OnTriggerEnter2D(Collider2D end){
		if (end.tag == "Player") {
			stageClearSign.enabled = true;
		}
	}
	public void ShowGetReadySign(){
		getReadySign.enabled = true;
	}

	public void HideGetReadySign(){
		getReadySign.enabled = false;
	}

	public void ShowYouDiedSign() {		
		youDiedSign.enabled = true;
	}
	public void HideYouDiedSign() {
		youDiedSign.enabled = false;
	}


	public void DisableSignCoroutines(){
		StopAllCoroutines ();

	}

}
