using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for showing instructions on the first round of the train minigame
/// </summary>
public class TrainFirstRunSign : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
	private SpriteRenderer trainSign;
	private static bool firstTimeOnTheTrain = true;
	private BullTrainController control;

	/// <summary>
	/// Get object references and start the instructions coroutine. Also disables the instructions in case the player dies
	/// </summary>
	void Start ()
	{
		trainSign = GameObject.Find ("trainSign").GetComponent<SpriteRenderer> ();
		control = FindObjectOfType (typeof(BullTrainController)) as BullTrainController;
		if (firstTimeOnTheTrain) {
			StartCoroutine (TrainSign ());
			StopCoroutine (TrainSign ());
			firstTimeOnTheTrain = false;
		} else if (!firstTimeOnTheTrain) {
			StopAllCoroutines ();
			HideTrainSign ();
			control.EnableMovement ();
		}
	}

	/// <summary>
	/// Shows the instructions for 4 seconds and toggles player controls
	/// </summary>
	public IEnumerator TrainSign ()
	{
		control.DisableMovement ();
		ShowTrainSign ();
		yield return new WaitForSeconds (4f);
		HideTrainSign ();
		control.EnableMovement ();
	}

	/// <summary>
	/// Method for showing the instructions
	/// </summary>
	public void ShowTrainSign ()
	{
		trainSign.enabled = true;
	}

	/// <summary>
	/// Method for hiding the instructions
	/// </summary>
	public void HideTrainSign ()
	{
		trainSign.enabled = false;
	}
}
