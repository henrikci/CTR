using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MorssiController : MonoBehaviour
{

	public Sprite morssiSpriteIdle; // Sprite for morssiSpriteIdle
	public Sprite morssiSpriteKick; // Sprite for morssiSpriteKick
	public Sprite morssiSpriteDead;
	private FightController bC;
	private bool morssiIsDead = false;
	private SpriteRenderer spriteRendererMorssi;
	private GameObject lifeBarBull;
	private static bool firstRoundFightingMorssi = true;
	private bool isAttacking = false;
	private float hitpoint = 45.0f;
	private float damage = 2.5f;


	void Start ()
	{
		spriteRendererMorssi = GetComponent<SpriteRenderer> (); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRendererMorssi.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRendererMorssi.sprite = morssiSpriteIdle; // set the sprite to sprite1
		if (firstRoundFightingMorssi) {
			StartCoroutine (FirstRoundDelay ());
			StartCoroutine (morssiAttackSystem ());
			firstRoundFightingMorssi = false;
		} else if (!firstRoundFightingMorssi) {
//			StopCoroutine (FirstRoundDelay ());
			StopCoroutine(morssiAttackSystem());

			isAttacking = true;
			StartCoroutine (DelayBetweenRounds ());
			StopCoroutine (DelayBetweenRounds ());
//			StartCoroutine (morssiAttackSystem ());
		}

		lifeBarBull = GameObject.Find ("lifeBarBullHealth");

		bC = FindObjectOfType (typeof(FightController)) as FightController;
	}

	void Update ()
	{

		if (hitpoint <= 0) {
			morssiKnocksOutBull ();
		}
	}
		
	public IEnumerator morssiAttackSystem() {
		while (morssiIsDead == false && hitpoint >= 0 && isAttacking) {
			spriteRendererMorssi.sprite = morssiSpriteIdle; // idle to kick
			yield return new WaitForSecondsRealtime(0.2f); // hold idle sprite in screen
			spriteRendererMorssi.sprite = morssiSpriteKick; // idle to kick
			healthReduceBull();
			yield return new WaitForSecondsRealtime(0.2f); // hold kick sprite in screen
		}
	}

	void healthReduceBull() {
		lifeBarBull.gameObject.transform.localScale -= new Vector3 (damage,0,0);
		hitpoint -= damage;
	}

	void morssiKnocksOutBull() {
		bC.bullDeathScript ();
	}

	public void AllowAttacking(){
		isAttacking = true;
	}

	public void DisableAttacking(){
		isAttacking = false;
	}


	public IEnumerator DelayBetweenRounds(){
		DisableAttacking ();
		yield return new WaitForSeconds (3.0f);
		AllowAttacking ();
		StartCoroutine (morssiAttackSystem ());
	}

	public IEnumerator FirstRoundDelay(){
		DisableAttacking ();
		yield return new WaitForSeconds (3.0f);
		AllowAttacking ();
		StartCoroutine (morssiAttackSystem ());
	}

//	public IEnumerator WaitBetweenAttacks(){
//		yield return new WaitForSeconds (0.2f);
//	}

//	public void Attack(){
//		while (!morssiIsDead && hitpoint >= 0 && isAttacking) {
//			spriteRendererMorssi.sprite = morssiSpriteIdle;
//			StartCoroutine (WaitBetweenAttacks ());
//			spriteRendererMorssi.sprite = morssiSpriteKick;
//			StopCoroutine (WaitBetweenAttacks ());
//			StartCoroutine (WaitBetweenAttacks ());
//			healthReduceBull ();
//			StopCoroutine (WaitBetweenAttacks ());
//		}
//	}
	public void morssiDeathScript() {
		spriteRendererMorssi.sprite = morssiSpriteDead;
		morssiIsDead = true;
		//yield return new WaitForSecondsRealtime(3.0f); // hold kick sprite in screen
		SceneManager.LoadScene("gameFinished");
	}
}





