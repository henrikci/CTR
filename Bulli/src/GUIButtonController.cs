using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// GUI button controller script.
/// </summary>
public class GUIButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	/// <summary>
	/// Instance variables
	/// </summary>
	private bool buttonPressed = false;
	private BullController cont;
	public Sprite jumpButton;
	public Sprite rightButton;
	public Sprite leftButton;
	public AudioClip jumpUpSound;
	public bool buttonJumping;
	private Button user;

	/// <summary>
	/// Get object references
	/// </summary>
	void Start ()
	{
		cont = FindObjectOfType (typeof(BullController)) as BullController;
		buttonJumping = false;
		jumpButton = GameObject.Find ("jumpButton").GetComponent<Sprite> ();
		rightButton = GameObject.Find ("rightButton").GetComponent<Sprite> ();
		leftButton = GameObject.Find ("leftButton").GetComponent<Sprite> ();
	}

	/// <summary>
	/// Really funny way of moving the player with GUI buttons
	/// </summary>
	void OnMouseOver ()
	{
		if (gameObject.name == "rightButton") {
			cont.MoveRight ();
		} else if (gameObject.name == "leftButton") {
			cont.MoveLeft ();
		}
	}

	/// <summary>
	/// Jump mechanic for the GUI button.
	/// </summary>
	void OnMouseDown ()
	{
		if (gameObject.name == "jumpButton") {
			JumpButton ();
		}
	}

	/// <summary>
	/// button press toggler
	/// </summary>
	/// <param name="e">E.</param>
	public void OnPointerDown (PointerEventData e)
	{
		buttonPressed = true;
	}

	/// <summary>
	/// Gets the button pressed.
	/// </summary>
	/// <returns><c>true</c>, if button pressed was gotten, <c>false</c> otherwise.</returns>
	public bool getButtonPressed ()
	{
		return buttonPressed;
	}

	/// <summary>
	/// Button press releaser
	/// </summary>
	/// <param name="e">E.</param>
	public void OnPointerUp (PointerEventData e)
	{
		buttonPressed = false;
	}

	/// <summary>
	/// Jump mechanism for the GUI button
	/// </summary>
	public Vector2 jumpUp = new Vector2 (0, 150f);

	public void JumpButton ()
	{
		
		cont.audioSystem.clip = jumpUpSound;
		if (cont.isJumping == false) {
			cont.isJumping = true;
			cont.bull.AddForce (29 * jumpUp, ForceMode2D.Impulse);
			cont.audioSystem.Play ();

		}
	}
}