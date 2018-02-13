using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BullController : MonoBehaviour {
	//instanssimuuttujat
	private float bullSpeed = 12;
	private Rigidbody2D bull;
	private float maxSpeed = 180f;
	private Vector2 vertical = new Vector2 (0.4f,0f);

	//törmäys ja hypyn nollaaminen
	void OnCollisionEnter2D(Collision2D collision){
		transform.Translate (0, 0.1f, 0);
		isJumping = false;
	}

	void Start(){
		bull = GetComponent<Rigidbody2D>();
	}

	void Update(){

		if(bull.velocity.magnitude > maxSpeed)
		{
			bull.velocity = bull.velocity.normalized * maxSpeed;
		}

		//liikkuminen
		if (Input.GetKey (KeyCode.LeftArrow)) {
			bull.AddForce (-18 * vertical, ForceMode2D.Impulse);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			
			bull.AddForce(18 * vertical, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Pomppaus ();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			bull.transform.Translate (0, -0.001f * bullSpeed, 0);
		}
	}

	//hyppiminen
	private Vector2 jumppi = new Vector2 (0f, 10f);
	private bool isJumping = false;

	public void Pomppaus ()
	{

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
			bull.AddForce (14 * jumppi, ForceMode2D.Impulse);
			isJumping = true; 
		} 
	}

 
//	public void OnTriggerEnter (Collider player, Collider levelEnd)
//	{
//		if (player.tag == "Player" && levelEnd.tag == "LevelEnd") {
//			Application.LoadLevel ("levelSelectLevelVantaaOpened");
//	}
//}
}

