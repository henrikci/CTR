using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Camera controller script.
/// </summary>
public class CameraController : MonoBehaviour {
	/// <summary>
	/// Instance variables
	/// </summary>
	public Transform target;
	private float cameraSpeed = 15f;

	void Update () {
		///Set the camera to follow the player's transform property
		Vector3 newPosition = new Vector3(target.position.x, transform.position.y,transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPosition, cameraSpeed * Time.deltaTime);
	}
}
