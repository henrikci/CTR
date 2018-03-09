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

	private Button deathCount;
	private Button rahkaCount;
	public Text deathText;
	public Text rahkaText;
	private int finalDeathCount;
	private int finalRahkaCount;
	void Start(){
		///Get object references
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
	/// <summary>
	/// Gets the final death count and converts to string
	/// </summary>
	public void GetFinalDeathCount(){
		finalDeathCount = BullController.amountOfDeaths;
		deathCount.GetComponentInChildren<Text> ().text = finalDeathCount.ToString();
	}

	/// <summary>
	/// Gets the final rahka count and converts to string
	/// </summary>
	public void GetFinalRahkaCount(){
		finalRahkaCount = RahkaController.amountOfRahka;
		rahkaCount.GetComponentInChildren<Text> ().text = finalRahkaCount.ToString ();
	}
}

