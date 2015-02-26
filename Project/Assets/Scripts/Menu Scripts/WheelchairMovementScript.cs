using UnityEngine;
using System.Collections;
using KinectNet20;
using KinectForWheelchair;

public class WheelchairMovementScript : MonoBehaviour
{
		public static float CurrentAngle;
		public static bool MovedFowards;
		// Use this for initialization
		void Start ()
		{
				CurrentAngle = 0;// sets the current angle to 0
				MovedFowards = false; //the player has not moved fowards
		}
	
		// Update is called once per frame
		void Update ()
		{
				//this is used for debugging to display the variables on the screen, can be removed later 
				OnGUI ();
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (600, 10, 200, 20), "CurrentAngle: " + CurrentAngle);  //  Display the CurrentAngle on a label in the top left
				GUI.Label (new Rect (600, 25, 200, 20), "Player MovedFowards: " + MovedFowards);  //  Display the MovedFowards on a label in the top left
		}
}
