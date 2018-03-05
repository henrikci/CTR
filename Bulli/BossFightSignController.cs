using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightSignController : MonoBehaviour {
	private SpriteRenderer ringSign;
	private SpriteRenderer getReadySign;
	private static bool firstRoundBossFight = true;
	private FightController bullControls;
	private MorssiController bossControls;
	// Use this for initialization
	void Start () {
		ringSign = GameObject.Find ("ringSign").GetComponent<SpriteRenderer> ();
		getReadySign = GameObject.Find ("getReadySign").GetComponent<SpriteRenderer> ();
		bullControls = FindObjectOfType (typeof(FightController)) as FightController;
		bossControls = FindObjectOfType (typeof(MorssiController)) as MorssiController;
	
		if (firstRoundBossFight) {
			StartCoroutine (FirstRoundShowSign ());
			StopCoroutine (FirstRoundShowSign ());
			firstRoundBossFight = false;
		} else if (!firstRoundBossFight) {
			StopCoroutine (FirstRoundShowSign ());
			StartCoroutine (DelayBetweenRounds ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EnableGetReadySign(){
		getReadySign.enabled = true;
	}

	public void DisableGetReadySign(){
		getReadySign.enabled = false;
	}

	public void EnableRingSign(){	
		ringSign.enabled = true;
	}

	public void DisableRingSign(){
		ringSign.enabled = false;
	}

	public IEnumerator FirstRoundShowSign(){
		bullControls.DisableControls ();
		bossControls.DisableAttacking ();
		EnableRingSign ();
		yield return new WaitForSeconds (3.0f);
		DisableRingSign ();
		bullControls.AllowControls ();
		bossControls.AllowAttacking ();

	}

	public IEnumerator DelayBetweenRounds(){
		DisableRingSign ();
		EnableGetReadySign ();
		bullControls.DisableControls ();
//		bossControls.DisableAttacking ();
		yield return new WaitForSeconds (3.0f);
		DisableGetReadySign ();
		bullControls.AllowControls ();
//		bossControls.AllowAttacking ();
	}

}
