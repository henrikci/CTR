using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Boss fight minigame sign controller.
/// </summary>
public class BossFightSignController : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
	private SpriteRenderer ringSign;
	private SpriteRenderer getReadySign;
	private static bool firstRoundBossFight = true;
	private FightController bullControls;
	private MorssiController bossControls;

	void Start ()
	{
		///Get object references
		ringSign = GameObject.Find ("ringSign").GetComponent<SpriteRenderer> ();
		getReadySign = GameObject.Find ("getReadySign").GetComponent<SpriteRenderer> ();
		bullControls = FindObjectOfType (typeof(FightController)) as FightController;
		bossControls = FindObjectOfType (typeof(MorssiController)) as MorssiController;

		///Coroutines to toggle instruction signs on the first round and showing a different sign afterwards
		if (firstRoundBossFight) {
			StartCoroutine (FirstRoundShowSign ());
			StopCoroutine (FirstRoundShowSign ());
			firstRoundBossFight = false;
		} else if (!firstRoundBossFight) {
			StopCoroutine (FirstRoundShowSign ());
			StartCoroutine (DelayBetweenRounds ());
		}
	}

	/// <summary>
	/// Shows the get ready-sign
	/// </summary>
	public void EnableGetReadySign ()
	{
		getReadySign.enabled = true;
	}

	/// <summary>
	/// Disables the get ready-sign.
	/// </summary>
	public void DisableGetReadySign ()
	{
		getReadySign.enabled = false;
	}

	/// <summary>
	/// Shows the instructions
	/// </summary>
	public void EnableRingSign ()
	{	
		ringSign.enabled = true;
	}

	/// <summary>
	/// Hides the instructions
	/// </summary>
	public void DisableRingSign ()
	{
		ringSign.enabled = false;
	}

	/// <summary>
	/// Coroutine to show the instructions and toggle player and boss controls
	/// </summary>
	public IEnumerator FirstRoundShowSign ()
	{
		bullControls.DisableControls ();
		bossControls.DisableAttacking ();
		EnableRingSign ();
		yield return new WaitForSeconds (3.0f);
		DisableRingSign ();
		bullControls.AllowControls ();
		bossControls.AllowAttacking ();

	}

	/// <summary>
	/// Coroutine to show the get ready sign and wait between rounds
	/// </summary>
	public IEnumerator DelayBetweenRounds ()
	{
		DisableRingSign ();
		EnableGetReadySign ();
		bullControls.DisableControls ();
		yield return new WaitForSeconds (3.0f);
		DisableGetReadySign ();
		bullControls.AllowControls ();

	}

}
