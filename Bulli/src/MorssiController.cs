using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Final boss controller script
/// </summary>
public class MorssiController : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
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
	private float damage = 2.9f;


	void Start ()
	{
		///Get object references and toggle the boss' sprites to show attacks
		lifeBarBull = GameObject.Find ("lifeBarBullHealth");
		bC = FindObjectOfType (typeof(FightController)) as FightController;
		spriteRendererMorssi = GetComponent<SpriteRenderer> ();
		if (spriteRendererMorssi.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRendererMorssi.sprite = morssiSpriteIdle; // set the sprite to sprite1
		///Coroutines to wait for the instructions to pass and then start attacking on the first round
		if (firstRoundFightingMorssi) {
			StartCoroutine (FirstRoundDelay ());
			StartCoroutine (morssiAttackSystem ());
			firstRoundFightingMorssi = false;
		/// Coroutines to run after the first round to wait for the sign to disappear
		} else if (!firstRoundFightingMorssi) {
			StopCoroutine(morssiAttackSystem());
			isAttacking = true;
			StartCoroutine (DelayBetweenRounds ());
			StopCoroutine (DelayBetweenRounds ());
		}
	}

	/// <summary>
	/// Check if the player is alive
	/// </summary>
	void Update ()
	{
		if (hitpoint <= 0) {
			morssiKnocksOutBull ();
		}
	}
		
	/// <summary>
	/// Attack mechanic for the boss
	/// </summary>
	public IEnumerator morssiAttackSystem() {
		while (morssiIsDead == false && hitpoint >= 0 && isAttacking) {
			spriteRendererMorssi.sprite = morssiSpriteIdle; // idle to kick
			yield return new WaitForSecondsRealtime(0.2f); // hold idle sprite in screen
			spriteRendererMorssi.sprite = morssiSpriteKick; // idle to kick
			healthReduceBull();
			yield return new WaitForSecondsRealtime(0.2f); // hold kick sprite in screen
		}
	}
	/// <summary>
	/// Method for doing damage to the player
	/// </summary>
	void healthReduceBull() {
		lifeBarBull.gameObject.transform.localScale -= new Vector3 (damage,0,0);
		hitpoint -= damage;
	}

	/// <summary>
	/// Runs the death script for the player in case of loss
	/// </summary>
	void morssiKnocksOutBull() {
		bC.bullDeathScript ();
	}

	/// <summary>
	/// Method for allowing the boss to attack
	/// </summary>
	public void AllowAttacking(){
		isAttacking = true;
	}

	/// <summary>
	/// Method for disabling the boss attacks
	/// </summary>
	public void DisableAttacking(){
		isAttacking = false;
	}

	/// <summary>
	/// Waiting coroutine between rounds
	/// </summary>
	public IEnumerator DelayBetweenRounds(){
		DisableAttacking ();
		yield return new WaitForSeconds (3.0f);
		AllowAttacking ();
		StartCoroutine (morssiAttackSystem ());
	}

	/// <summary>
	/// Waiting coroutine for the instructions on the first round
	/// </summary>
	public IEnumerator FirstRoundDelay(){
		DisableAttacking ();
		yield return new WaitForSeconds (3.0f);
		AllowAttacking ();
		StartCoroutine (morssiAttackSystem ());
	}

	/// <summary>
	/// Method for the boss dying, loads the final scene of the game
	/// </summary>
	public void morssiDeathScript() {
		spriteRendererMorssi.sprite = morssiSpriteDead;
		morssiIsDead = true;
		SceneManager.LoadScene("gameFinished");
	}
}





