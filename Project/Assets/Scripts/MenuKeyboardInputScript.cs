using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;//added

public class MenuKeyboardInputScript : MonoBehaviour
{
		// Update is called once per frame
		void Update ()
		{
				//turn left
				if (Input.GetKey (KeyCode.LeftArrow)) {
						Debug.Log ("Clicked left arrow");
						if (WheelchairMovementScript.CurrentAngle < 0) {
								WheelchairMovementScript.CurrentAngle = 359;
						} else {
								WheelchairMovementScript.CurrentAngle = WheelchairMovementScript.CurrentAngle - 0.5f; // was WheelchairMovementScript.CurrentAngle-- but moved way to fast
						}
				}
				//turn right
				if (Input.GetKey (KeyCode.RightArrow)) {
						Debug.Log ("Clicked right arrow");
						if (WheelchairMovementScript.CurrentAngle > 359) {
								WheelchairMovementScript.CurrentAngle = 0;
						} else {
								WheelchairMovementScript.CurrentAngle = WheelchairMovementScript.CurrentAngle + 0.5f; // was WheelchairMovementScript.CurrentAngle++ but moved way to fast
						}
				}
				//move fowards
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						Debug.Log ("Clicked up arrow");
						if (MenuChangeSelectionScript.MovedFowards == false) {
								MenuChangeSelectionScript.MovedFowards = true;
						}
						
				}
	
				//move backwards
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
						Debug.Log ("Clicked down arrow");
						if (MenuChangeSelectionScript.MovedFowards == true) {
								MenuChangeSelectionScript.MovedFowards = false;
						}
				}
		}
}
