using UnityEngine;
using System.Collections;
/// <summary>
/// Camera elevator controller script.
/// </summary>
public class CameraElevatorController : MonoBehaviour {
	/// <summary>
	/// Instance variables
	/// </summary>
	public Transform Bull;       
	private Vector3 offset;  

	void Start () 
	{
		/// Set an offset vector to track the player's position on x and y-scales
		offset = transform.position - Bull.transform.position;
	}
		
	void LateUpdate () 
	{
		/// Following the player character from the offset vectors distance.
		transform.position = Bull.transform.position + offset;
	}
}