using UnityEngine;
using UnityEngine.AI;
using System.Collections;

/// <summary>
/// Controller script for the conductor in the train minigame
/// </summary>
public class PoliceController : MonoBehaviour
{
	/// <summary>
	/// Instance variables
	/// </summary>
	public Transform pointA;
	public Transform pointB;
	public static bool firstRound = true;
	public bool isPatroling;
	private float policeSpeed = 6.20f;
	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	/// <summary>
	/// Starts a coroutine on the first round of the game to wait for the instructions screen to disappear before moving.
	/// After the first round stops the coroutine and starts patroling instantly
	/// </summary>
	void Start ()
	{
		if (firstRound) {
			StartCoroutine (WaitForStart ());
			firstRound = false;
		} else if (!firstRound) {
			StopAllCoroutines ();
			isPatroling = true;
			Patrol ();
		}
	}

	/// <summary>
	///Moving the conductor according to the patrol mechanic.
	/// </summary>
	void Update ()
	{
		if (isPatroling) {
			Patrol ();
		}
	}


	/// <summary>
	/// Moving the conductor from point A towards point B
	/// </summary>
	public void Patrol ()
	{
		transform.position = Vector3.MoveTowards (transform.position, pointB.position, policeSpeed);
	}

	/// <summary>
	/// Coroutine to wait for the instructions screen to disappear
	/// </summary>

	public IEnumerator WaitForStart ()
	{
		isPatroling = false;
		yield return new WaitForSeconds (4f);
		isPatroling = true;
	}
}
