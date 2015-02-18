using UnityEngine;
using System.Collections;

using KinectForWheelchair;

public class PlayerController : MonoBehaviour
{

	public InputController inputController;

	// Use this for initialization
	void Start ()
	{
		return;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Get the input info
		SeatedInfo inputInfo = this.inputController.InputInfo;
		if (inputInfo == null)
			return;

		// Set the player position and direction
		if (inputInfo.Features == null)
			return;

		//Debug.Log (inputInfo.Features.Position);
		this.transform.position = new Vector3(inputInfo.Features.Position.x, 0, inputInfo.Features.Position.y) * 5;
		this.transform.forward = new Vector3(inputInfo.Features.Direction.x, 0, inputInfo.Features.Direction.y) * 5;

		return;
	}
}
