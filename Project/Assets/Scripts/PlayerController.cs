using UnityEngine;
using System.Collections;
using KinectNet20;
using KinectForWheelchair;

public class PlayerController : MonoBehaviour
{
	//player controller
	/*Moved to Player.cs script as it was duplicated in two scripts
	//player speed
	public float speed = 5;
	//player rotate speed
	public float rotateSpeed = 50;
	//Player Health
	public float health = 10;
	*/
	public static float rotAngle = 0; 
	void Update ()
	{
		rotAngle = -Input.GetAxis ("Horizontal");
		//takes input from A,D LeftArrow AND RightArrow
		transform.Rotate (0, 0, rotAngle * Player.rotateSpeed * Time.deltaTime);
		//Takes input from W, S, UpArrow and DownArrow
		Player.speed += Input.GetAxis ("Vertical") * Player.speed * Time.deltaTime;
		//Sets minimum and maximum speed values
		Player.speed = Mathf.Clamp (Player.speed, 1, 10);
	}
	void FixedUpdate()
	{
		rigidbody2D.velocity = transform.up * Player.speed;
	}
	/*  Moved to Player.cs script as it was duplicated in two scripts
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