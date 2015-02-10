using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//player controller
	//player speed
	public float speed = 5;
	//player rotate speed
	public float rotateSpeed = 50;
	//Player Health
	public float health = 10;
	//player movement
	void Update ()
	{	
		//takes input from A,D LeftArrow AND RightArrow
		transform.Rotate (0, 0, -Input.GetAxis ("Horizontal") * rotateSpeed * Time.deltaTime);
		//Takes input from W, S, UpArrow and DownArrow
		speed += Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		//Sets minimum and maximum speed values
		speed = Mathf.Clamp (speed, 1, 10);
	}
	void FixedUpdate()
	{
		rigidbody.velocity = transform.up * speed;
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Enemy")
		{
			//Function can be changed to remove health decrementally, orm in this case, "insta-kill"
			health--;
		}
	}
}