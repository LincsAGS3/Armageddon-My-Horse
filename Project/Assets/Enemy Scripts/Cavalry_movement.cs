using UnityEngine;
using System.Collections;

public class Cavalry_movement : MonoBehaviour {

	public int health = 20;

	float maxSpeed = 8;
	float MaxTurningSpeed = 4;
	float Acceleration = 11;
	float MaxRotationSpeed = 30;

	float CurrentSpeed = 11;

	Vector2 CurrentIdlePos = new Vector2(-1,-1);
	Vector2 GotoPos = new Vector2(0,0);

	bool Alert = false;

	enum AiType {Intercept, Follow, Circle};
	AiType Ai = AiType.Circle;
	float AttackCool = 0;

	//player game object reference
	GameObject player;
	//is there a player
	bool playerFound = false;

	bool clockWise = false;
	bool rotateNow = false;
	float RotAngle = 0;
	float attackTimer = 0;
	bool attacking = false;
	public bool mounted = true;

	public float damage = 5;

	GameObject rider;

	float Itime = 5;

	public AudioClip[] audioClip;
	bool soundPlaying = false;

	void Start () {
		rider = this.transform.GetChild (0).gameObject;
		//find a group point
		GameObject[] g = GameObject.FindGameObjectsWithTag ("Group");
		float dist = float.MaxValue;
		foreach (GameObject G in g) {
			if(dist > Vector2.Distance(G.transform.position,transform.position))
			{
				dist = Vector2.Distance(G.transform.position,transform.position);
				CurrentIdlePos = G.transform.position;
			}
		}
		GotoPos = FindNextPoint (CurrentIdlePos);
		//find the player
		player = GameObject.FindGameObjectWithTag("Player");
		//if there isnt a player then still move 
		if (player == null) {
			playerFound = false;
		} else {
			playerFound = true;
		}
		//random AI
		switch (Random.Range ((int)0, (int)3)) {
		case 0:
			Ai = AiType.Circle;
			break;
		case 1:
			Ai = AiType.Follow;
			break;
		case 2:
			Ai = AiType.Intercept;
			break;
		}
	}
	void takeDamage(int damage)
	{
		if (mounted) {
			health -= damage;
			rider.GetComponent<RiderMovement> ().Mounted = false;
			mounted = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (mounted) {
			damage = 5;
		} else {
			damage = 0;
		}
		//move forwards
		if (Vector2.Distance (this.transform.position, player.transform.position) < 15) {
			Alert = true;
		} else {
			Alert = false;
			Itime = 5;
			rotateNow = false;
			attackTimer = 0;
		}
		if(playerFound) 
		{
			if (!Alert) 
			{
				if (Vector2.Distance (transform.position, GotoPos) < 4) {
					GotoPos = FindNextPoint (CurrentIdlePos);
				}
				move ();
			} else {
				Vector2 DircetTowards;
				float angle;
				if(!audio.isPlaying && soundPlaying == false)
				{
					//playSound(0);
					soundPlaying = true;
				}
				else if (audio.isPlaying)
				{
					return;
				}
				switch(Ai)
				{
				case AiType.Intercept:
					//player speed and our speed
					Vector2 pSpeed = player.rigidbody2D.velocity;
					Vector2 eSpeed = this.rigidbody2D.velocity;
					//player pos in x seconds
					GotoPos = (Vector2)player.transform.position + pSpeed*Itime;
					float dist = Vector2.Distance(GotoPos, this.transform.position);
					float TimeToIntercept = dist/eSpeed.magnitude;
					if(TimeToIntercept <Itime)
					{
						Itime -=0.1f;
					}
					if(TimeToIntercept >Itime)
					{
						Itime +=0.1f;
					}
					if(AttackCool> 0)
					{
						AttackCool -= Time.deltaTime;
					}
					else
					{
						move ();
					}
					break;
				case AiType.Follow:

					//are we infront of the player?
					DircetTowards = this.transform.position- player.transform.position;
					angle = Vector2.Angle(player.transform.up, DircetTowards );
					if(angle > 90)
					{
						this.rigidbody2D.velocity = new Vector2(0,0);
						//behind
						GotoPos = player.transform.position - player.transform.up*2;
					}
					else
					{
						//infront
						//create points at either side of and behind the player
						Vector2 left = player.transform.position -(player.transform.right*3) - player.transform.up;
						Vector2 right = player.transform.position +(player.transform.right*3) - player.transform.up;
						if(Vector2.Distance(this.transform.position,left)> Vector2.Distance(this.transform.position, right))
						{
							//on the right
							GotoPos = right;
						}
						else
						{
							//on the left
							GotoPos = left;
						}
					}
					move ();
					//move around the player

					//attack in the rear
					break;
				case AiType.Circle:
					//are we infront of the player?
					DircetTowards = this.transform.position- player.transform.position;
					angle = Vector2.Angle(player.transform.up, DircetTowards );
					if(!rotateNow)
					{
						attacking = false;
						if(angle > 90)
						{
							Vector2 left = player.transform.position -(player.transform.right*3);
							Vector2 right = player.transform.position +(player.transform.right*3);
							if(Vector2.Distance(this.transform.position,left)> Vector2.Distance(this.transform.position, right))
							{
								//on the right
								clockWise = false;
								GotoPos = right;
								if(Vector2.Distance(this.transform.position,right)<4)
								{
									rotateNow = true;
									RotAngle = Mathf.Acos((right.x-player.transform.position.x)/3);
								}
							}
							else
							{
								//on the left
								clockWise = true;
								GotoPos = left;
								if(Vector2.Distance(this.transform.position,left)<4)
								{
									rotateNow = true;
									RotAngle = Mathf.Acos((left.x-player.transform.position.x)/3);
								}
							}
						}
						else
						{
							//infront
							//create points at either side of and behind the player
							Vector2 left = player.transform.position -(player.transform.right*3);
							Vector2 right = player.transform.position +(player.transform.right*3);
							if(Vector2.Distance(this.transform.position,left)> Vector2.Distance(this.transform.position, right))
							{
								//on the right
								clockWise = true;
								GotoPos = right;
								if(Vector2.Distance(this.transform.position,right)<4)
								{
									rotateNow = true;
									RotAngle = Mathf.Acos((right.x-player.transform.position.x)/3);
								}
							}
							else
							{
								//on the left
								clockWise = false;
								GotoPos = left;
								if(Vector2.Distance(this.transform.position,left)<4)
								{
									rotateNow = true;
									RotAngle = Mathf.Acos((left.x-player.transform.position.x)/3);
								}
							}
						}
						move ();
					}
					else
					{
						if(attackTimer <= 0)
						{
							attackTimer = Random.Range(10,15);
							GotoPos = player.transform.position;
							Debug.Log("Attack!");
							attacking = true;
						}
						if(!attacking)
						{
						GotoPos.x = player.transform.position.x +7*Mathf.Cos(RotAngle);
						GotoPos.y = player.transform.position.y +7*Mathf.Sin(RotAngle);
						if(Vector2.Distance(this.transform.position, GotoPos)<2)
						{
							if(clockWise)
							{
								RotAngle+= 20;
							}
							else
							{
								RotAngle-=20;
							}
						}
						attackTimer -= Time.deltaTime;
						}
						else
						{
							GotoPos = player.transform.position;
						}
						move();
					}

					break;
				}
			}
		}

	}

	void move()
	{
		if (StateControl.State != StateControl.state.Pause) {
			if (health > 0) {
				if (mounted) {
					transform.rigidbody2D.velocity = transform.up * CurrentSpeed;
					Vector3 vectorToTarget = GotoPos - (Vector2)transform.position;
					float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
					angle -= 90;
					Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
					transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 1);
				} else {
					transform.rigidbody2D.velocity = new Vector2 (0, 0);
				}
			} else {
				this.collider2D.enabled = false;
				transform.rigidbody2D.velocity = transform.up * CurrentSpeed;
			}
		}
	}

	Vector2 FindNextPoint(Vector2 centre)//calculate a point around the centre within a 15 unit radius
	{
		//create a random vector 2 with a magnitude of 1
		Vector2 rnd = UnityEngine.Random.insideUnitCircle;
		//multiply that by the maximum range
		rnd *= 15;
		//return new value
		return centre+rnd;
	}

	void OnCollisionStay2D(Collision2D coll) {
		//if we hit another enemy
		if (coll.gameObject.tag == this.tag) {
			//move away from the enemy
			float rotation = (float)Mathf.Atan2 (this.transform.position.y - coll.transform.position.y,this.transform.position.x - coll.transform.position.x);
			Vector2 moveAway = new Vector2((-(float)Mathf.Cos(rotation)),(-(float)Mathf.Sin(rotation)));
			this.rigidbody2D.velocity = moveAway*6f;
		}
		//if we hit a wall
		if (coll.gameObject.tag !="Player") {
			//goto a new point
			GotoPos = FindNextPoint (CurrentIdlePos);
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Player") {
			AttackCool = 2;
			attacking = false;
		}
	}
	public void attacked()
	{
		AttackCool = 2;
		attacking = false;
	}

	void playSound(int Clip)
	{
		audio.clip = audioClip [Clip];
		audio.Play ();
	}
}
