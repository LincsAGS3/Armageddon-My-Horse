using UnityEngine;
using System.Collections;

public class MenuVictoryScript : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		if (WheelchairMovementScript.MovedFowards == true) {
			MenuGameMenuStateScript.MenuStateChange(3);
		}	
	}
}
