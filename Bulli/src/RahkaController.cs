using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Rahka controller script.
/// </summary>
public class RahkaController : MonoBehaviour {
	///Instance variables
	public static int amountOfRahka = 0;
	public GameObject rahka;
	public AudioClip rahkaPickup;
	public Sprite[] rahkaSprites;
	private SpriteRenderer rahkaSpriteRenderer;
	private AudioSource rahkaSounds;

	/// <summary>
	/// Get object references
	/// </summary>
	void Start(){
//		
		rahkaSpriteRenderer = GameObject.Find ("rahkaSpriteRenderer").GetComponent<SpriteRenderer> ();
		rahkaSounds = GetComponent<AudioSource> ();
		rahkaSpriteRenderer.sprite = rahkaSprites [amountOfRahka];
	}

	/// <summary>
	/// Collects the rahka on collision and destroys that gameobject to prevent collecting same item multiple times
	/// </summary>
	/// <param name="rahka">Rahka.</param>
	public void OnTriggerEnter2D(Collider2D rahka)
	{
		if (rahka.tag == "Quark") {
			PickUpRahka ();
			Destroy (rahka.gameObject);
		}
	}

	/// <summary>
	/// Increments the amount of rahka the player has.
	/// Also plays a sound effect and displays the correct number of rahka on the screen
	/// </summary>
	public void PickUpRahka(){
		rahkaSounds.clip = rahkaPickup;
		rahkaSounds.Play ();
		amountOfRahka ++;
		rahkaSpriteRenderer.sprite = rahkaSprites [amountOfRahka];

	}
}

