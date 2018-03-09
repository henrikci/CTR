using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Elevator sign controller.
/// </summary>
public class ElevatorSignController : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
	private SpriteRenderer elevatorSign;
	private BullElevatorController controls;

	/// <summary>
	/// Get object references and start the sign coroutine
	/// </summary>
	void Start ()
	{
		elevatorSign = GameObject.Find ("elevatorSign").GetComponent<SpriteRenderer> ();
		elevatorSign.enabled = false;
		controls = FindObjectOfType (typeof(BullElevatorController)) as BullElevatorController;
		StartCoroutine (ElevatorSign ());
	}

	/// <summary>
	/// Method for disabling player controls, showing the instructions for 3 seconds and hiding them afterwards and enabling movement after the sign has been disabled
	/// </summary>
	public IEnumerator ElevatorSign ()
	{
		controls.DisableMovement ();
		ShowElevatorSign ();
		yield return new WaitForSeconds (3f);
		HideElevatorSign ();
		controls.EnableMovement ();
	}

	/// <summary>
	/// Method for showing the instructions
	/// </summary>
	void ShowElevatorSign ()
	{
		elevatorSign.enabled = true;
	}

	/// <summary>
	/// Method for hiding the instructions
	/// </summary>
	void HideElevatorSign ()
	{
		elevatorSign.enabled = false;
		elevatorSign.gameObject.SetActive (false);
	}
}
