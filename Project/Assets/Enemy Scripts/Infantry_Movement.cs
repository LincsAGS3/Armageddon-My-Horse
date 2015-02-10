using UnityEngine;
using System.Collections;
using System;

public class Infantry_Movement : MonoBehaviour {

	public GameObject groupPoint;
	public float maxSpeed = 4;
	float currentSpeed = 0;
	Vector2 speed = new Vector2(0,0) ;
	public float wanderRadius = 15;
	Vector2 gotoPoint = new Vector2();
	void Start () {
		gotoPoint = this.transform.position;
	}
	

	void Update () {
		//new point if the old one is reached 
		if ( Vector2.Distance(gotoPoint,this.transform.position)<1) {
			gotoPoint = FindNextPoint (groupPoint.transform.position);
			//Debug.Log (gotoPoint);//output new target for bug testing
		}
		//move the character
		move ();
	}
	Vector2 FindNextPoint(Vector2 centre)//calculate a point around the centre within a 15 unit radius
	{
		//create a random vector 2 with a magnitude of 1
		Vector2 rnd = UnityEngine.Random.insideUnitCircle;
		//multiply that by the maximum range
		rnd *= wanderRadius;
		//return new value
		return centre+rnd;

	}
	void move()//smoothly move towards gotoPoint
	{
		//if speed isnt at the max then increase the speed
		if (currentSpeed < maxSpeed) {
			currentSpeed += (maxSpeed - currentSpeed)/10;
		}
		//find the angle between the current position and the goal
		float rotation = (float)Math.Atan2 (this.transform.position.y - gotoPoint.y, this.transform.position.x - gotoPoint.x);
		//calculate the different components of the sprites speed
		speed.x += -(speed.x -(-(float)Math.Cos (rotation) * currentSpeed*Time.deltaTime))*0.1f;
		speed.y += -(speed.y-(-(float)Math.Sin (rotation) * currentSpeed*Time.deltaTime))*0.1f;
		//apply the movement
		this.transform.Translate (speed);
	}
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log ("collision");
		//if we are colliding with another enemy
		if (coll.gameObject.tag == this.tag) {
			//move away from the enemy
			float rotation = (float)Math.Atan2 (this.transform.position.y - coll.transform.position.y,this.transform.position.x - coll.transform.position.x);
			Vector2 moveAway = new Vector2((-(float)Math.Cos(rotation)),(-(float)Math.Sin(rotation)));
			this.transform.Translate(moveAway*0.1f);
		}
	}
}
