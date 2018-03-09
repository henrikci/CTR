using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Player controls for the train minigame
/// </summary>
public class BullTrainController : MonoBehaviour
{
	///Instance variables
	private Rigidbody2D bull;
	private static int amountOfDeaths;
	private Animator anim;
	public SignTrainController signs;
	private float maxSpeed = 350f;
	private Vector2 vertical = new Vector2 (300f, 0f);
	private Vector2 trainJump = new Vector2 (0f, 375f);
	private bool isJumping = false;
	public bool movementAllowed;

	void Start ()
	{
		///Get object references
		signs = FindObjectOfType (typeof(SignTrainController)) as SignTrainController;	
		bull = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}


	void Update ()
	{
		///Normalizing the player's speed and checking it doesn't exceed the maxSpeed
		if (bull.velocity.magnitude > maxSpeed) {
			bull.velocity = bull.velocity.normalized * maxSpeed;
		}
		///Movement mechanics
		if (movementAllowed) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				MoveLeft ();
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				MoveRight ();
			}
			if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
				TrainJump ();
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				MoveDown ();
			}
		}
	}


	/// <summary>
	/// Method for jumping on the train
	/// </summary>
	public void TrainJump ()
	{

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			bull.AddForce (29 * trainJump, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}

	/// <summary>
	/// Moves the player down.
	/// </summary>
	public void MoveDown(){
		bull.AddForce (-20 * trainJump, ForceMode2D.Force);
	}
	/// <summary>
	/// Check collision for resetting jumping, forbidding double jumps from the roof and dying if the conductor touches the player
	/// </summary>
	/// <param name="collider">Collider.</param>
	void OnCollisionEnter2D (Collision2D collider)
	{
		if (collider.gameObject.tag == "roof") {
			isJumping = true;
		}
		isJumping = false;
		if (collider.gameObject.tag == "police") {
			DieOnTheTrain ();
		}
	}

	/// <summary>
	/// Moves the player character to the left and shows the flipped animation
	/// </summary>
	public void MoveLeft ()
	{
		anim.SetBool ("isMoving", true);
		anim.SetBool ("facingLeft", true);
		bull.AddForce (-30 * vertical, ForceMode2D.Force);
	}

	/// <summary>
	/// Moves the player character to the right and shows the normal animation for running.
	/// </summary>
	public void MoveRight ()
	{
		anim.SetBool ("isMoving", true);
		anim.SetBool ("facingLeft", false);
		bull.AddForce (30 * vertical, ForceMode2D.Force);
	}

	/// <summary>
	/// Death mechanic for the train minigame
	/// </summary>
	public void DieOnTheTrain ()
	{
		SceneManager.LoadScene (6);
		signs.DisableSignCoroutines ();
		EnableMovement ();
		BullController.amountOfDeaths++;
	}

	/// <summary>
	/// Disables player movement.
	/// </summary>
	public void DisableMovement ()
	{
		movementAllowed = false;
	}

	/// <summary>
	/// Enables player movement
	/// </summary>
	public void EnableMovement ()
	{
		movementAllowed = true;
	}

}