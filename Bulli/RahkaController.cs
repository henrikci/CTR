using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahkaController : MonoBehaviour {
	//rahkan tilastointi
	public static int amountOfRahka;
	private GameObject rahka;
	//rahkan kerääminen törmättäessä
	public void OnTriggerEnter2D(Collider2D rahka)
	{
		if (rahka.tag == "Quark") {
			PickUpRahka ();
			Destroy (rahka.gameObject);
			Debug.Log (amountOfRahka);

		}
	}

	//rahkan määrän tilastointi
	public void PickUpRahka(){
		amountOfRahka ++;
	}

}

