using UnityEngine;
using System.Collections;

public class WheelchairMovementScript : MonoBehaviour {
	public static float CurrentAngle;

	// Use this for initialization
	void Start () {
		CurrentAngle = 0;
	}
	
	// Update is called once per frame
	void Update () {
		OnGUI ();
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 200, 20), "CurrentAngle: " + CurrentAngle);  //  Display the CurrentAngle on a label in the top left
	}
}
