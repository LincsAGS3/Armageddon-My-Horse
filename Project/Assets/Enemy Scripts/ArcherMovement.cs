using UnityEngine;
using System.Collections;
using System;

public class ArcherMovement : MonoBehaviour {
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
	//is it dead
	public bool dead = false;
	//reached first point
	bool donefirst = false;
	bool hit = false;

	public AudioClip[] audioClip;

	public GameObject arrow;

	float timer;
	
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

		timer = Time.time + 3;
	}
	
	
	void Update () {
		
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
					if(gotoPoint != (Vector2)transform.position)
					{
						donefirst = true;
					}
					gotoPoint = FindNextPoint (groupPoint.transform.position);
					//Debug.Log (gotoPoint);//output new target for bug testing
				}
			}else{
				if(dead)
				{
					this.collider2D.enabled = false;
					playerFound = false;
					this.GetComponent<SpriteRenderer>().color = Color.red;
					this.rigidbody2D.velocity = new Vector2 (0, 0);
					
				}
				if(playerFound)
				{
					//enemy position
					Vector2 This_pos = new Vector2 ((int)this.transform.position.x,(int)this.transform.position.y);
					//choose where to goto
					//gotoPoint = new Vector2(0,0);
					{
						/*int current = 0;
						
						This_pos.x += 1;
						if(current-1 < PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y])
						{
							gotoPoint = This_pos;
							current = PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y]+1;
						}
						This_pos.x -= 2;
						if(current < PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y])
						{
							gotoPoint = This_pos;
							gotoPoint.x -=1;
							current = PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y];
						}
						This_pos.x += 1;
						This_pos.y -= 1;
						if(current < PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y])
						{
							gotoPoint = This_pos;
							current = PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y];
						}
						This_pos.y += 2;
						if(current-1 < PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y])
						{
							gotoPoint = This_pos;
							gotoPoint.y +=1;
							current = PathFinding.buffer1[(int)This_pos.x,(int)This_pos.y];
						}*/

						if(timer < Time.time)
						{
							GameObject shot = Instantiate(arrow, transform.position + (transform.forward * 2), transform.rotation) as GameObject;
							shot.rigidbody2D.AddForce(transform.forward * 1000);

							timer = Time.time + 3;
						}

					}
					
					//move
					float rotation = (float)Math.Atan2 (this.transform.position.y - gotoPoint.y, this.transform.position.x - gotoPoint.x);
					//calculate the different components of the sprites speed
					speed.x += -((float)Math.Cos (rotation) * 4*Time.deltaTime);
					speed.y += -((float)Math.Sin (rotation) * 4*Time.deltaTime);
					//apply the movement
					
					//this.rigidbody2D.velocity = speed*60;
					//transform.position = Vector2.MoveTowards(transform.position, gotoPoint,0.01f);
				}
			}
			//move the character
			if (StateControl.State != StateControl.state.Pause) {
				if(!dead)
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
		if (!donefirst) {
			if (currentSpeed < maxSpeed*2) {
				currentSpeed += (maxSpeed - currentSpeed) / 10;
			}
		} else {
			if (currentSpeed < maxSpeed) {
				currentSpeed += (maxSpeed - currentSpeed) / 10;
			}
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
		
		//commented out due to lag
		
		//if (coll.gameObject.tag == this.tag) {
		//	//move away from the enemy
		//	float rotation = (float)Math.Atan2 (this.transform.position.y - coll.transform.position.y,this.transform.position.x - coll.transform.position.x);
		//	Vector2 moveAway = new Vector2((-(float)Math.Cos(rotation)),(-(float)Math.Sin(rotation)));
		//	this.rigidbody2D.velocity = moveAway*6f;
		//}
		
		Debug.Log(donefirst);
		//if we hit a wall
		if(coll != null)
		if (coll.gameObject.tag !="Player") {
			
			//goto a new point
			gotoPoint = FindNextPoint (groupPoint.transform.position);
			
		}
	}

	void OnTriggerStay2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			Vector2 temp = (transform.position.normalized - player.transform.position.normalized) * currentSpeed;
			transform.Translate(temp);
			
			print ("running");
		}
	}

	void damaged()
	{
		if(hit)
		{
			Debug.Log("killed");
			dead = true;
			Player.TotalEnemiesKilled += 1; // added for GUI to add to total of enemies killed
		}
		
		else
		{
			Debug.Log("hit");
			hit = true;
		}
	}
	
	void PlaySound(int clip)
	{
		audio.clip = audioClip [clip];
		audio.panLevel = 0;
		audio.Play ();
	}
	
}