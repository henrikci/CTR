using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullController : MonoBehaviour {
	//instanssimuuttujat
	private float bullSpeed = 8;
	private Rigidbody2D bull;

	//törmäys ja hypyn nollaaminen
	void OnCollisionEnter2D(Collision2D collision){
		transform.Translate (0, 0.1f, 0);
		isJumping = false;
	}

	void Start(){
		bull = GetComponent<Rigidbody2D>();
	}

	void Update(){
		//liikkuminen
		if (Input.GetKey (KeyCode.LeftArrow)) {
			bull.transform.Translate (-0.5f * bullSpeed, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			bull.transform.Translate (0.5f * bullSpeed, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Pomppaus ();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			bull.transform.Translate (0, -0.00000001f * bullSpeed, 0);
		}
	}

	//hyppiminen
	private Vector2 jumppi = new Vector2 (0f, 60f);
	private bool isJumping = false;

	public void Pomppaus ()
	{

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			bull.AddForce (5 * jumppi, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}

}


