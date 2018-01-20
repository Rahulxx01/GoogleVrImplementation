using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextInteraction : MonoBehaviour {
	public float gazeTime = 4f;
	private float timerVirtualTour;
	private float timerFreeRoaming;
	private bool gazedVirtualTour;
	private bool gazedFreeRoaming;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (gazedVirtualTour) {
			timerVirtualTour += Time.deltaTime;
			Transform child = transform.GetChild (0);



			//Vector3 newScale = new Vector3 (child.localScale.x, child.localScale.y, timerVirtualTour+10);
			//child.localScale = newScale;
			Vector3 newPosition = new Vector3 (child.localPosition.x, child.localPosition.y, -timerVirtualTour);
			child.localPosition = newPosition;

			/*RectTransform rt = child.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(25, 25);*/

			if (timerVirtualTour >= gazeTime) {
				//Action performed//
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler);
				timerVirtualTour = 0f;
				//GetComponent<Collider> ().enabled = false;
			} 
				
		} 

		if (gazedFreeRoaming) {
			timerFreeRoaming += Time.deltaTime;

			Transform child = transform.GetChild (0);

			//Vector3 newScale = new Vector3 (child.localScale.x, child.localScale.y, timerVirtualTour+10);
			//child.localScale = newScale;
			Vector3 newPosition = new Vector3 (child.localPosition.x, child.localPosition.y, -timerFreeRoaming);
			child.localPosition = newPosition;

			/*RectTransform rt = child.GetComponent<RectTransform>();
			rt.sizeDelta = new Vector2(25, 25);*/

			if (timerFreeRoaming >= gazeTime) {
				//Action performed
				ExecuteEvents.Execute (gameObject, new PointerEventData (EventSystem.current), ExecuteEvents.pointerClickHandler);
				timerFreeRoaming = 0f;
				//GetComponent<Collider> ().enabled = false;
			}


		} 

		
	}
	//Enter Virtual Tour
	public void PointerEnterVirtualTour(){
		gazedVirtualTour = true;
	}
	//Exit Virtual Tour
	public void PointerExitVirtualTour(){
		gazedVirtualTour = false;
	}
	//Enter Free Roaming
	public void PointerEnterFreeRoaming(){
		gazedFreeRoaming = true;
	}

	//Exit Free Roaming
	public void PointerExitFreeRoaming(){
		gazedFreeRoaming = false;
	}

	public void PointerUp(){
		Debug.Log ("Pointer up");
	}
	public void PointerDown(){
		Debug.Log ("Pointer Down");
	}
	public void PointerClickVirtualTour(){
		Debug.Log ("Virtual Tour Begins");
	}
	public void PointerClickFreeRoaming(){
		Debug.Log ("Let the Game Begin");
	}



}
