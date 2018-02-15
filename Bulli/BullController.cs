using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System;


public class BullController : MonoBehaviour {
	//instanssimuuttujat
	private Rigidbody2D bull;
	private Animator anim;
	private bool facingLeft = false;
	private bool playerMoving;
	private float maxSpeed = 140f;
	private Vector2 vertical = new Vector2 (120f,0f);
	//hyppiminen
	private Vector2 jumppi = new Vector2 (0f, 150f);
	private bool isJumping = false;
	//törmäys ja hypyn nollaaminen
	void OnCollisionEnter2D(Collision2D collision){
		isJumping = false;
	}

	void Start(){
		//Haetaan objektiviittaukset
		bull = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}

	void Update(){
		//bullin maksiminopeuden valvonta ja säätö	
		if(bull.velocity.magnitude > maxSpeed)
		{
			bull.velocity = bull.velocity.normalized * maxSpeed;
		}

		//liikkuminen
		if (Input.GetKey (KeyCode.LeftArrow)) {
			bull.AddForce (-30 * vertical, ForceMode2D.Force);
			anim.SetFloat("speed", Mathf.Abs(bull.velocity.x));
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			anim.SetFloat("speed", Mathf.Abs(bull.velocity.x));
			bull.AddForce(30 * vertical, ForceMode2D.Force);
		}
		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			Pomppaus ();
			}
		}
	void FixedUpdate(){
		//Tässä pyöritetään animaatiota kulkusuunnasta riippuen
		float h = Input.GetAxis ("Horizontal");
		if (h < 0 && !facingLeft)
			reverseImage ();
		else if (h > 0 && facingLeft)
			reverseImage ();
	}

	//Hyppymekaniikka
	public void Pomppaus ()
	{

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			bull.AddForce (29 * jumppi, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}
	//Metodi, jolla Bullin juoksuanimaatio käännetään y-akselin suhteen peilikuvaksi
	void reverseImage()
	{
		// Get and store the local scale of the RigidBody2D
		Vector2 theScale = bull.transform.localScale;
		facingLeft = !facingLeft;
		// Flip it around the other way
		theScale.x *= -1;
		bull.transform.localScale = theScale;
	}
}
