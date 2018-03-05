using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainFirstRunSign : MonoBehaviour {
	private SpriteRenderer trainSign;
	public static bool firstTimeOnTheTrain = true;
	private BullTrainController control;
	// Use this for initialization
	void Start () {
		trainSign = GameObject.Find ("trainSign").GetComponent<SpriteRenderer> ();
		control = FindObjectOfType (typeof(BullTrainController)) as BullTrainController;
		if (firstTimeOnTheTrain) {
			StartCoroutine (TrainSign ());
			StopCoroutine (TrainSign ());
			firstTimeOnTheTrain = false;
		} else if (!firstTimeOnTheTrain){
			StopAllCoroutines ();
			HideTrainSign ();
			control.EnableMovement ();
		}
	}

	public IEnumerator TrainSign(){
		control.DisableMovement ();
		ShowTrainSign ();
		yield return new WaitForSeconds (4f);
		HideTrainSign ();
		control.EnableMovement ();
	}

	public void ShowTrainSign() {
		trainSign.enabled = true;
	}

	public void HideTrainSign() {
		trainSign.enabled = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
