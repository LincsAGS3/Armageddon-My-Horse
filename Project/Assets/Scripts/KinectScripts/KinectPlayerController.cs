﻿using UnityEngine;
using System.Collections;
using KinectNet20;
using KinectForWheelchair;

public class KinectPlayerController : MonoBehaviour
{
	public KinectInputController kinectInputController;
	/*Moved to Player.cs script as it was duplicated in two scripts
	//player speed
	public float speed = 5;
	//player rotate speed
	public float rotateSpeed = 50;
	//Player Health
	public float health = 10;
	*/
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
		//this.transform.position = new Vector2(0, -(inputInfo.Features.Position.y)) * 5;
		//this.transform.forward = new Vector2(0, -(inputInfo.Features.Direction.y)) * 5;
		
		//this.transform.rotation = new Quaternion(0, 0, -1*(inputInfo.Features.Angle/(90)) * rotateSpeed * Time.deltaTime, 1);

		transform.Rotate(0, 0, -1 * (inputInfo.Features.Angle / (90)) * Player.rotateSpeed * Time.deltaTime);

		Player.speed += inputInfo.Features.Position.y * Player.speed * Time.deltaTime;

		Player.speed = Mathf.Clamp(Player.speed, 1, 10);

		return;
	}
	void FixedUpdate()
	{
		rigidbody2D.velocity = transform.up * Player.speed;
	}
	/* Moved to Player.cs script as it was duplicated in two scripts
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.tag == "Enemy")
		//if (collider.tag == "Boss){ lose more health--;} and so-on
		{
			//Function can be changed to remove health decrementally or provide insta kill
			health--;
		}
		if (health == 0)
		{
			//Game Over...
			MenuGameMenuStateScript.MenuStateChange(2);
		}
	}
	*/
}
