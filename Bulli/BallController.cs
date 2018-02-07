using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
	
//		Debug.Log (collision.gameObject);
//		collision.gameObject.transform.Translate (0, 0, 0);
		transform.Translate (0, 0.1f, 0);
	}
	
}
