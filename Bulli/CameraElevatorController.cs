using UnityEngine;
using System.Collections;

public class CameraElevatorController : MonoBehaviour {
	//instanssimuuttujat
	public Transform bullero;       
	private Vector3 offset;         
	void Start () 
	{
		//Alustetaan kameran seurausetäisyys
		offset = transform.position - bullero.transform.position;
	}
		
	void LateUpdate () 
	{
		//Seurataan pelihahmoa sen liikkuessa
		transform.position = bullero.transform.position + offset;
	}
}