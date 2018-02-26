using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class VagabondController : MonoBehaviour { 

	public Transform pointA;
	public Transform pointB;
	public bool  isRight = true;
	private float vagabondSpeed = 2f;

	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	void Start(){

		pointAPosition = new Vector3 (pointA.position.x, 0, 0);
		pointBPosition = new Vector3 (pointB.position.x, 0, 0);
	}

	void Update() {
		Vector3 thisPosition = new Vector3 (transform.position.x, 0, 0);
		if (isRight) {
			transform.position = Vector3.MoveTowards (transform.position, pointB.position, vagabondSpeed);
			if (thisPosition.Equals (pointBPosition)) {
				isRight = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, pointA.position, vagabondSpeed);
			if (thisPosition.Equals (pointAPosition)) {
				isRight = true;
			}
		}

	}

}
