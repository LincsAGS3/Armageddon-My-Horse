using UnityEngine;
using System.Collections;
using KinectNet20;
using KinectForWheelchair;

public class WheelchairMovementScript : MonoBehaviour
{
	public KinectInputController kinectInputController;

	public static float CurrentAngle;
	public static bool MovedFowards;
	float forwards;
	float backwards;
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

		// Get the input info
		SeatedInfo inputInfo = this.kinectInputController.InputInfo;
		if (inputInfo == null)
			return;

		// Set the player position and direction
		if (inputInfo.Features == null)
			return;
		//this should get the angle and feed it to the public variable
		CurrentAngle = -(inputInfo.Features.Angle);
		//Does the following make sense???
		if(/*current*/inputInfo.Features.Position.y < /*previous*/inputInfo.Features.Position.y)
		{
			//then
			MovedFowards = true;
		}
		if(/*current*/inputInfo.Features.Position.y > /*previous*/inputInfo.Features.Position.y)
		{
			//then
			MovedFowards = false;
		}
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (10, 10, 200, 20), "CurrentAngle: " + CurrentAngle);  //  Display the CurrentAngle on a label in the top left
		GUI.Label (new Rect (10, 70, 200, 20), "Player MovedFowards: " + MovedFowards);  //  Display the MovedFowards on a label in the top left
	}
}
