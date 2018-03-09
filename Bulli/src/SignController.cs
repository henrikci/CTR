using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Sign controller script.
/// </summary>
public class SignController : MonoBehaviour
{
	/// <summary>
	/// Setting instance variables
	/// </summary>
	private SpriteRenderer stageClearSign;
	private SpriteRenderer getReadySign;
	private SpriteRenderer youDiedSign;
	private BullController control;

	/// <summary>
	/// Get object references and show the Get Ready -sign
	/// </summary>
	void Start ()
	{
		stageClearSign = GameObject.Find ("stageClearSign").GetComponent<SpriteRenderer> ();
		getReadySign = GameObject.Find ("getReadySign").GetComponent<SpriteRenderer> ();
		youDiedSign = GameObject.Find ("youDiedSign").GetComponent<SpriteRenderer> ();
		control = FindObjectOfType (typeof(BullController)) as BullController;
		youDiedSign.enabled = false;
		stageClearSign.enabled = false;

		StartCoroutine (GetReady ());
		StopCoroutine (GetReady ());

	}


	/// <summary>
	/// Shows the death sign for 1.5 seconds on death and hides it afterwards
	/// </summary>
	public IEnumerator DeathSign ()
	{
		ShowYouDiedSign ();
		yield return new WaitForSeconds (1.5f);
		HideYouDiedSign ();
	}

	/// <summary>
	/// Shows the get ready sign for 2 seconds, hides it afterwards and enables the player's movement
	/// </summary>
	public IEnumerator GetReady ()
	{
		ShowGetReadySign ();
		yield return new WaitForSeconds (2f);
		HideGetReadySign ();
		control.EnableMovement ();
	}

	/// <summary>
	/// Method for showing the Stage Clear sign upon reaching the gym of that level
	/// </summary>
	/// <param name="end">Checks to see if the collided object is the player</param>
	public void OnTriggerEnter2D (Collider2D end)
	{
		if (end.tag == "Player") {
			stageClearSign.enabled = true;
		}
	}

	/// <summary>
	/// Method for showing the get ready-sign
	/// </summary>
	public void ShowGetReadySign ()
	{
		getReadySign.enabled = true;
	}

	/// <summary>
	/// Method for hiding the get ready-sign
	/// </summary>
	public void HideGetReadySign ()
	{
		getReadySign.enabled = false;
	}

	/// <summary>
	/// Method for showing the you died-sign
	/// </summary>
	public void ShowYouDiedSign ()
	{		
		youDiedSign.enabled = true;
	}

	/// <summary>
	/// Method for hiding the you died-sign
	/// </summary>
	public void HideYouDiedSign ()
	{
		youDiedSign.enabled = false;
	}
}
