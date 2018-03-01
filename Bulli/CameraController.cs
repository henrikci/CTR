using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//instanssimuuttujat
	public Transform target;
	private float cameraSpeed = 15f;
	// Update is called once per frame
	void Update () {
		//kameran seuraaminen
		Vector3 newPosition = new Vector3(target.position.x, transform.position.y,transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPosition, cameraSpeed * Time.deltaTime);
	}
}
