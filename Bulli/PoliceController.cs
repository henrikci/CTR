using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PoliceController : MonoBehaviour { 

	public Transform pointA;
	public Transform pointB;
	public static bool firstRound = true;

	public bool isPatroling;
	private float policeSpeed = 11.5f;


	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	void Start(){
		if (firstRound) {
			StartCoroutine (WaitForStart ());
			firstRound = false;
		} else if (!firstRound) {
			StopAllCoroutines ();
			isPatroling = true;
			Patrol ();
		}
	}

	void Update() {
		if (isPatroling) {
			Patrol ();
		}
	}

	public void Patrol() {

		transform.position = Vector3.MoveTowards (transform.position, pointB.position, policeSpeed);
		}


	public IEnumerator WaitForStart(){
		isPatroling = false;
		yield return new WaitForSeconds (4f);
		isPatroling = true;
	}


}
