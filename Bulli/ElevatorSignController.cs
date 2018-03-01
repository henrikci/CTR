using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSignController : MonoBehaviour {
	private SpriteRenderer elevatorSign;
	private BullElevatorController controls;
	// Use this for initialization
	void Start () {
		elevatorSign = GameObject.Find ("elevatorSign").GetComponent<SpriteRenderer> ();
		elevatorSign.enabled = false;
		controls = FindObjectOfType (typeof(BullElevatorController)) as BullElevatorController;
		StartCoroutine (ElevatorSign ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public IEnumerator ElevatorSign(){
		controls.DisableMovement ();
		ShowElevatorSign ();
		yield return new WaitForSeconds (3f);
		HideElevatorSign ();
		controls.EnableMovement ();
	}

	void ShowElevatorSign(){
		elevatorSign.enabled = true;
	}

	void HideElevatorSign() {
		elevatorSign.enabled = false;
	}
}
