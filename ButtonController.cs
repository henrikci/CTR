using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	private bool buttonPressed = false;

	public void OnPointerDown(PointerEventData e){
		buttonPressed = true;
	}

	public bool getButtonPressed(){
		return buttonPressed;
	}

	public void OnPointerUp(PointerEventData e){
		buttonPressed = false;
	}
}
