using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// Credit button controller script.
/// </summary>
public class CreditMenuButtons : MonoBehaviour {
	/// <summary>
	/// Instance variables
	/// </summary>
	private BullController statistics;
	private RahkaController rahkaStats;
	private Button deathCount;
	private Button rahkaCount;
	public Text deathText;
	public Text rahkaText;
	public int finalDeathCount;
	public int finalRahkaCount;
	void Start(){
		///Get object references
		statistics = FindObjectOfType (typeof(BullController)) as BullController;
		rahkaStats = FindObjectOfType (typeof(RahkaController)) as RahkaController;
		deathCount = GameObject.Find ("deathCount").GetComponent<Button> ();
		rahkaCount = GameObject.Find ("rahkaCount").GetComponent<Button> ();
		GetFinalDeathCount ();
		GetFinalRahkaCount ();
	}

	/// <summary>
	/// Exits the game.
	/// </summary>
	public void ExitTheGameAtCredits()
	{
		Application.Quit ();

	}

	public void GetFinalDeathCount(){
		finalDeathCount = BullController.amountOfDeaths;
		deathCount.GetComponentInChildren<Text> ().text = finalDeathCount.ToString();
	}

	public void GetFinalRahkaCount(){
		finalRahkaCount = RahkaController.amountOfRahka;

		rahkaCount.GetComponentInChildren<Text> ().text = finalRahkaCount.ToString ();
	}
}

