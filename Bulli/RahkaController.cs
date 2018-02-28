using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahkaController : MonoBehaviour {

	public static int amountOfRahka;
		
	private GameObject rahka;
	public void OnTriggerEnter2D(Collider2D rahka)
	{
		if (rahka.tag == "Quark" && rahka.gameObject.name == "quark") {
			PickUpRahka ();
			Destroy (rahka.gameObject);
			Debug.Log (amountOfRahka);

		}
	}

	public void PickUpRahka(){
		amountOfRahka ++;
	}

}

