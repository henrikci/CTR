using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightController : MonoBehaviour
{

	public Sprite ryuSpriteIdle; // Drag your first sprite here
	public Sprite ryuSpriteKick; // Drag your second sprite here
	public Sprite ryuSpriteDead; // Drag your second sprite here
	private MorssiController mC; 
	private bool bullIsDead = false; 
	private SpriteRenderer spriteRendererBull;

	private SpriteRenderer youDiedSign;
	private GameObject lifeBarMorssi;
	private static bool firstRoundFighting = true;
	private bool attackingAllowed;
	private float hitpoint = 45.0f;
	private float damage = 0.60f;

	void Start ()
	{
		youDiedSign = GameObject.Find ("youDiedSign").GetComponent<SpriteRenderer> ();
		HideYouDied ();
		spriteRendererBull = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRendererBull.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRendererBull.sprite = ryuSpriteIdle; // set the sprite to ryuSpriteIdle

		lifeBarMorssi = GameObject.Find ("lifeBarMorssiHealth");

		mC = FindObjectOfType (typeof(MorssiController)) as MorssiController;

		if (firstRoundFighting) {
//			StartCoroutine (StartDelay ());
			firstRoundFighting = false;
		} else if (!firstRoundFighting) {
//			StopCoroutine (StartDelay ());
//			StopAllCoroutines ();

		}
			
		//StartCoroutine (bullDeathScript());
	}

	void Update ()
	{
		bullAttackSystem (); // summon for bullAttackSystem

		if (hitpoint <= 0) {
			bullKnockOutsMorssi ();
		}
	}

	void bullAttackSystem () { //bull's attack system
		if (attackingAllowed) {
			if (Input.GetKey (KeyCode.Space) && hitpoint >= 0 && !bullIsDead) { // If the spacebar is pushed down...
				spriteRendererBull.sprite = ryuSpriteKick; // idle to kick
				healthReduceMorssi ();
			} else {
				spriteRendererBull.sprite = ryuSpriteIdle; // kick to idle
			}
		}
	}

	public void AllowControls(){
		attackingAllowed = true;
	}

	public void DisableControls(){
		attackingAllowed = false;
	}
	
	void healthReduceMorssi () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			lifeBarMorssi.gameObject.transform.localScale -= new Vector3 (damage, 0, 0);
			hitpoint -= damage;
		}
	}

	void bullKnockOutsMorssi () {
		mC.morssiDeathScript ();
	}

	public void bullDeathScript () {
		spriteRendererBull.sprite = ryuSpriteDead; // idle to kick
		bullIsDead = true;
	
		//yield return new WaitForSecondsRealtime(2.0f);
		SceneManager.LoadScene(10);
	}



	public void ShowYouDied(){
		youDiedSign.enabled = true;
	}

	public void HideYouDied(){
		youDiedSign.enabled = false;
	}
//	public IEnumerator StartDelay(){
//		yield return new WaitForSeconds (2.0f);
//		attackingAllowed = true;
//
//	}

	public IEnumerator SecondRound(){
		ShowYouDied ();
		DisableControls ();
		yield return new WaitForSeconds (3.0f);
		AllowControls ();
		HideYouDied ();
	}
}