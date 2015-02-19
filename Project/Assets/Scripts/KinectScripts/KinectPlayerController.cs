using UnityEngine;
using System.Collections;
using KinectForWheelchair;

public class KinectPlayerController : MonoBehaviour
{
	public KinectInputController kinectInputController;

	// Use this for initialization
	void Start ()
	{
		return;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Get the input info
		SeatedInfo inputInfo = this.kinectInputController.InputInfo;
		if (inputInfo == null)
			return;

		// Set the player position and direction
		if (inputInfo.Features == null)
			return;

		//Debug.Log (inputInfo.Features.Position);
		this.transform.position = new Vector3(inputInfo.Features.Position.x, inputInfo.Features.Position.y, 0) * 5;
		this.transform.forward = new Vector3(inputInfo.Features.Direction.x, inputInfo.Features.Direction.y, 0) * 5;
		WheelchairMovementScript.CurrentAngle = inputInfo.Features.Angle / 20;
		return;
	}
}
