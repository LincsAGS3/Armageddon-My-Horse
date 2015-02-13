using UnityEngine;
using System.Collections;
using System;

public class Infantry_Movement : MonoBehaviour {
	//point to move around (is assigned by the grouppoint itself)
	public GameObject groupPoint;
	//bool for if the actor has been allocated a grouppoint
	public bool alloc = false;
	//the maximum speed the actor can travel
	public float maxSpeed = 4;
	//the current speed of the actor - for acceleration
	float currentSpeed = 0;
	//the velocity vector
	Vector2 speed = new Vector2(0,0);
	//ther radius of the group point
	public float wanderRadius = 15;
	//the point that the actor is currently trying to reach
	Vector2 gotoPoint = new Vector2();
	//bool for the alert state
	bool alert = false;
	//player game object reference
	GameObject player;
	//is there a player
	bool playerFound = false;

	void Start () {
		gotoPoint = this.transform.position;
		groupPoint = null;
		//look for the player
		player = GameObject.FindGameObjectWithTag("Player");
		//if there isnt a player then still move 
		if (player == null) {
			playerFound = false;
		} else {
			playerFound = true;
		}
	}
	

	void Update () {
		//new point if the old one is reached 
		if (alloc) {
			if(playerFound)
			{
			//look for the player
				if(Vector2.Distance(this.transform.position, player.transform.position)<15)
				{
					alert = true;
				}
				else
				{
					alert = false;
				}
			}
			//if alerted to the player
			if(!alert)
			{
				if (Vector2.Distance (gotoPoint, this.transform.position) < 1) {
					gotoPoint = FindNextPoint (groupPoint.transform.position);
				//Debug.Log (gotoPoint);//output new target for bug testing
				}
			}else{

			}
			//move the character
			if (StateControl.State != StateControl.state.Pause) {
				move ();
			} else {
				this.rigidbody2D.velocity = new Vector2 (0, 0);
			}
		}
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
		speed.x += -(speed.x -(-(float)Math.Cos (rotation) * currentSpeed*Time.deltaTime));
		speed.y += -(speed.y-(-(float)Math.Sin (rotation) * currentSpeed*Time.deltaTime));
		//apply the movement
		this.rigidbody2D.velocity = speed*60;
		//this.transform.Translate (speed);
	}
	//check for continuous collisions
	void OnCollisionStay2D(Collision2D coll) {
		//if we hit another enemy
		if (coll.gameObject.tag == this.tag) {
			//move away from the enemy
			float rotation = (float)Math.Atan2 (this.transform.position.y - coll.transform.position.y,this.transform.position.x - coll.transform.position.x);
			Vector2 moveAway = new Vector2((-(float)Math.Cos(rotation)),(-(float)Math.Sin(rotation)));
			this.rigidbody2D.velocity = moveAway*6f;
		}
		//if we hit a wall
		if (coll.gameObject.tag == "Wall") {
			Debug.Log ("collision");
			//goto a new point
			gotoPoint = FindNextPoint (groupPoint.transform.position);
		}
	}
}
