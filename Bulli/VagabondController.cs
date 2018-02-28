using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class VagabondController : MonoBehaviour { 

	public Transform pointA;
	public Transform pointB;
	public Transform whoToFollow;
	public static int amountOfDeaths;
	public bool  isRight = true;
	public bool followPlayer;
	public bool isPatroling;
	private float vagabondSpeed = 1.8f;
	private float vagabondChaseSpeed = 2f;
	public Transform player;
	public bool superPatrol = false;
	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	void Start(){

		pointAPosition = new Vector3 (pointA.position.x, 0, 0);
		pointBPosition = new Vector3 (pointB.position.x, 0, 0);
	}

	void Update() {
		if (followPlayer) {
			FollowThePlayer ();
		} else if (isPatroling && superPatrol){
			SuperPatrol ();

		} else if (isPatroling) {
			Patrol ();
		}
	}

	public void FollowThePlayer ()
	{
		followPlayer = true;
		Vector3 newPosition = new Vector3(whoToFollow.position.x, 0,0 );

		transform.LookAt (player);
		if (Vector3.Distance (transform.position, player.position) >= 1) {
			transform.position += transform.forward * vagabondChaseSpeed * Time.deltaTime;
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
		
}
