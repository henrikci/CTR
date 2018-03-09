using UnityEngine;
using System.Collections;
/// <summary>
/// Vagabond controller script.
/// </summary>
public class VagabondController : MonoBehaviour
{

	/// <summary>
	/// Setting instance variables
	/// </summary>
	public Transform pointA;
	public Transform pointB;
	public bool isRight = true;
	public bool isPatroling;
	private float vagabondSpeed = 1.8f;
	public Transform player;
	public bool superPatrol = false;
	public bool nikoPatrol = false;
	private Vector3 pointAPosition;
	private Vector3 pointBPosition;

	/// <summary>
	/// Setting vectors to act as endpoints for the vagabond patrol mechanics
	/// </summary>
	void Start ()
	{
		pointAPosition = new Vector3 (pointA.position.x, 0, 0);
		pointBPosition = new Vector3 (pointB.position.x, 0, 0);
	}


	/// <summary>
	/// Checker to see which type of patrol has been selected for the vagabonds and moving them accordingly
	/// </summary>
	void Update ()
	{
		if (isPatroling && superPatrol) {
			SuperPatrol ();
		} else if (isPatroling && nikoPatrol) {
			NikoPatrol ();
		} else if (isPatroling) {
			Patrol ();
		}
	}


	/// <summary>
	/// Basic method for patroling between point A and B
	/// </summary>
	public void Patrol ()
	{
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

	/// <summary>
	/// Sets the patrol speed to an insane level
	/// </summary>
	public void SuperPatrol ()
	{
		this.vagabondSpeed = 7f;
		Patrol ();
	}


	/// <summary>
	/// Sets the patrol speed to a fast but not insane level
	/// </summary>
	public void NikoPatrol ()
	{
		this.vagabondSpeed = 3.5f;
		Patrol ();
	}
}
