using UnityEngine;
using System.Collections;

public class WheelchairMovementScript : MonoBehaviour {
	public static float CurrentAngle;
	public static bool MovedFowards;
	// Use this for initialization
	void Start () {
		CurrentAngle = 0;
		MovedFowards = false;
	}
	
	// Update is called once per frame
	void Update () {
		OnGUI ();
	}

	void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 200, 20), "CurrentAngle: " + CurrentAngle);  //  Display the CurrentAngle on a label in the top left
		GUI.Label (new Rect (10, 70, 200, 20), "Player MovedFowards: " + MovedFowards);  //  Display the MovedFowards on a label in the top left
	}
}
