using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
	//instanssimuuttujat
	private Rigidbody2D bull;
	private GameObject ball;
	private ButtonController bLeft;
	//	private ButtonController bRight;
	//	private ButtonController bUp;
	//	private ButtonController bDown;
	private float ballSpeed = 20;
	private Vector3 offset;
	// Use this for initialization
	void Start ()
	{
//		Debug.Log ("SWAG YOLO");
//		ball = GameObject.Find ("Ball");
		//pelihahmo
		bull = GetComponent<Rigidbody2D> ();
//		Vector3 move = new Vector3 (2.0f, 4.0f, 0);
//		ball.transform.Translate (2f, 4f, 0);
//		bLeft = GameObject.Find("ButtonLeft").GetComponent<ButtonController>();
//		bRight = GameObject.Find ("ButtonRight").GetComponent<ButtonController> ();
//		bUp = GameObject.Find ("ButtonUp").GetComponent<ButtonController> ();
//		bDown = GameObject.Find ("ButtonDown").GetComponent<ButtonController> ();
//		ball.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (3f, 13f));
		//kamera-offsetti
		offset = transform.position - bull.transform.position;
//		bLeft.onClick.AddListener ();
	}
	//törmäys-hitbox -juttu ja hypyn nollaaminen
	void OnCollisionEnter2D (Collision2D collision)
	{

		//		Debug.Log (collision.gameObject);
		//		collision.gameObject.transform.Translate (0, 0, 0);
		transform.Translate (0, 0.1f, 0);
		isJumping = false;
	}
	// Update is called once per frame
	void Update ()
	{
		// liikkuminen nuolinäppäimillä
		if (Input.GetKey (KeyCode.LeftArrow)) {
			bull.transform.Translate (-0.5f * ballSpeed, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			bull.transform.Translate (0.5f * ballSpeed, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
//			ball.transform.Translate (0, 0.05f * ballSpeed, 0);
			Pomppaus ();
		} 
		if (Input.GetKey (KeyCode.DownArrow)) {
			bull.transform.Translate (0, -0.00000001f * ballSpeed, 0);
		}
//		ball.transform.Translate (0.01f, 0.001f, 0);
//		Debug.Log (bLeft.getButtonPressed ());

	}

	void LateUpdate ()
	{
		//kameran sijainnin päivitys
		transform.position = bull.transform.position + offset;
	}
	//hyppiminen
	private Vector2 jumppi = new Vector2 (0.5f, 40f);
	public bool isJumping = false;

	public void Pomppaus ()
	{

		if (Input.GetKeyDown (KeyCode.Space) && isJumping == false) {
//			ball.transform.Translate(0,0.1f * ballSpeed,0);
			bull.AddForce (3 * jumppi, ForceMode2D.Impulse);
			isJumping = true; 
		} 


	}
}
