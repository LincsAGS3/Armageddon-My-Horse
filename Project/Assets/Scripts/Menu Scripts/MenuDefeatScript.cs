using UnityEngine;
using System.Collections;

public class MenuDefeatScript : MonoBehaviour {
	// Update is called once per frame
	void Update () {
	
		if (WheelchairMovementScript.MovedFowards == true) {
			Application.LoadLevel ("MainMenu"); //returns the player to the main menu
		}					
	}
}
