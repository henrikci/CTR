using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player controller.
/// </summary>
public class BullController : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
	public Rigidbody2D bull;
	private static int amountOfDeaths;
	private Animator anim;
	public bool isMoving;
	public AudioClip jumpSound;
	public AudioClip deathSound;
	public SignController signs;
	private bool playerMoving;
	public float maxSpeed = 140f;
	public AudioSource audioSystem;
	public Vector2 vertical = new Vector2 (120f, 0f);
	public bool isJumping = false;
	public bool movementAllowed;
	public bool facingLeft;

	/// <summary>
	/// Start this instance and get object references
	/// </summary>
	void Start ()
	{
		
		isMoving = false;
		signs = FindObjectOfType (typeof(SignController)) as SignController;	
		bull = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audioSystem = GetComponent<AudioSource> ();


	}


	void Update ()
	{
		/// Check player's velocity and make sure it never surpasses maxSpeed	
		if (bull.velocity.magnitude > maxSpeed) {
			bull.velocity = bull.velocity.normalized * maxSpeed;
		}
		/// Movement logic via methods
		if (movementAllowed) {
			//liikkuminen
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

	///Jumping mechanics via vectors
	public Vector2 jump = new Vector2 (0f, 150f);

	public void Jump ()
	{
		audioSystem.clip = jumpSound;

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			audioSystem.Play ();
			bull.AddForce (29 * jump, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}


	///Dying and respawn mechanics, includes a sound effect
	public void Die ()
	{	
		audioSystem.clip = deathSound;
		audioSystem.Play ();
		Vector3 deathVector = new Vector3 (100, 10, 0);
		bull.transform.position = deathVector;
		amountOfDeaths++;
		StartCoroutine (signs.DeathSign ());
	}

	/// <summary>
	/// Collision mechanic to reset boolean for jumping and dying if the player touches a vagabond
	/// </summary>
	/// <param name="bullCollider">Collider for the player character</param>
	void OnCollisionEnter2D (Collision2D bullCollider)
	{
		isJumping = false;

		if (bullCollider.gameObject.tag == "vagabond") {
			Die ();
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
	/// Moves the player character to the left and shows the flipped animation for the player character.
	/// </summary>
	public void MoveLeft ()
	{
		isMoving = true;
		anim.SetBool ("isMoving", true);
		facingLeft = true;
		anim.SetBool ("facingLeft", true);
		bull.AddForce (-30 * vertical, ForceMode2D.Force);
	}

	/// <summary>
	/// Moves the player character to the right and shows the normal animation for running.
	/// </summary>
	public void MoveRight ()
	{
		facingLeft = false;
		anim.SetBool ("isMoving", true);
		anim.SetBool ("facingLeft", false);
		bull.AddForce (30 * vertical, ForceMode2D.Force);
	}

	/// <summary>
	/// Checks if the player is jumping. Needed for using the jump mechanic from GUI.
	/// </summary>
	/// <returns><c>true</c>, if player is jumping, <c>false</c> otherwise.</returns>
	public bool CheckIfJumping ()
	{
		return isJumping;
	}
}