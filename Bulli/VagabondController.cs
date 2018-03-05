using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class VagabondController : MonoBehaviour { 

	public Transform pointA;
	public Transform pointB;
	public bool  isRight = true;
	public bool isPatroling;
	private float vagabondSpeed = 1.8f;
	public Transform player;
	public bool superPatrol = false;
	public bool nikoPatrol = false;
	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	void Start(){

		pointAPosition = new Vector3 (pointA.position.x, 0, 0);
		pointBPosition = new Vector3 (pointB.position.x, 0, 0);
	}

	void Update() {
		 if (isPatroling && superPatrol) {
			SuperPatrol ();
		}else if (isPatroling && nikoPatrol) {
			NikoPatrol ();
		} else if (isPatroling) {
			Patrol ();
		}
	}

	public void Patrol() {
		isPatroling = true;

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
	public void SuperPatrol() {
		this.vagabondSpeed = 7f;
		Patrol ();
	}

	public void NikoPatrol(){
		this.vagabondSpeed = 3.5f;
		Patrol ();
	}

	public void PolicePatrol(){
		this.vagabondSpeed = 2f;
		Patrol ();
	}
		
}
