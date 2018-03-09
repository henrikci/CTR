using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

/// <summary>
/// Player controls for the elevator minigame.
/// </summary>
public class BullElevatorController : MonoBehaviour
{
	///Instance variables
	private Rigidbody2D bull;
	private Animator anim;
	private AudioSource elevatorSound;
	public AudioClip jumpSound;
	private bool playerMoving;
	private float maxSpeed = 140f;
	private Vector2 vertical = new Vector2 (120f, 0f);
	private bool movementAllowed = true;
	private Vector2 jump = new Vector2 (0f, 250f);
	private bool isJumping = false;
	public bool facingLeft;

	/// <summary>
	/// Resets the player's ability to jump on collision
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionEnter2D (Collision2D collision)
	{
		isJumping = false;
	}

	void Start ()
	{
		///Get object references
		elevatorSound = GetComponent<AudioSource> ();
		bull = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		/// Normalize and check the player character's speed
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
				Jump ();
			}
		}
	}

	/// <summary>
	/// Jumping method and sound effect
	/// </summary>
	public void Jump ()
	{
		elevatorSound.clip = jumpSound;
		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			elevatorSound.Play ();
			bull.AddForce (29 * jump, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}

	/// <summary>
	/// Disables player movement.
	/// </summary>
	public void DisableMovement ()
	{
		movementAllowed = false;
	}

	/// <summary>
	/// Enables player movement.
	/// </summary>
	public void EnableMovement ()
	{
		movementAllowed = true;
	}

	/// <summary>
	/// Method for moving the player to the left and showing the flipped animation
	/// </summary>
	public void MoveLeft ()
	{
		anim.SetBool ("isMoving", true);
		facingLeft = true;
		anim.SetBool ("facingLeft", true);
		bull.AddForce (-30 * vertical, ForceMode2D.Force);
	}

	/// <summary>
	/// Method for moving the player to the right and showing the right animation
	/// </summary>
	public void MoveRight ()
	{
		facingLeft = false;
		anim.SetBool ("isMoving", true);
		anim.SetBool ("facingLeft", false);
		bull.AddForce (30 * vertical, ForceMode2D.Force);
	}
}
