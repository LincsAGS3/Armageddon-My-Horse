using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FamineBehavior : MonoBehaviour {
	public float health = 30;
	
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

	static GameObject FamineHealthImage;
	static GameObject HealthBackgroundImage;
	public RuntimeAnimatorController FamineDyingController;
	bool destroyed = false;
	void Start () {
		rider = this.transform.GetChild (0).gameObject;
		//find a group point
		CurrentIdlePos = GameObject.FindGameObjectWithTag ("Group").transform.position;
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
		Ai = AiType.Intercept;
		FamineHealthImage =  GameObject.Find("FamineHealthBar");
		FamineHealthImage.SetActive (true);
		HealthBackgroundImage =  GameObject.Find("BossHealthBarBackground");
		HealthBackgroundImage.SetActive (true);
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
		//Debug.Log ("Health " + health);
		if (mounted) {
			damage = 5*(1f-((float)health / 30f) +0.5f);
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
		if (health < 15) {
			Ai = AiType.Follow;
		}
		if (health > 0 ) {
			FamineHealthImage.GetComponent<Image> ().fillAmount = health / 30;
			if((StateControl.State != StateControl.state.Pause))
			{
			if (playerFound) {
				if (!Alert) {
					if (Vector2.Distance (transform.position, GotoPos) < 4) {
						GotoPos = FindNextPoint (CurrentIdlePos);
					}
					move ();
				} else {
					Vector2 DircetTowards;
					float angle;
						//if(!audio.isPlaying)
							//PlaySound(0);
					switch (Ai) {
					case AiType.Intercept:
					//player speed and our speed
						Vector2 pSpeed = player.rigidbody2D.velocity;
						Vector2 eSpeed = this.rigidbody2D.velocity;
					//player pos in x seconds
						GotoPos = (Vector2)player.transform.position - pSpeed.normalized + pSpeed * Itime;
						float dist = Vector2.Distance (GotoPos, this.transform.position);
						float TimeToIntercept = dist / eSpeed.magnitude;
						if (TimeToIntercept < Itime) {
							Itime -= 0.1f;
						}
						if (TimeToIntercept > Itime) {
							Itime += 0.1f;
						}
						if (AttackCool > 0) {
							AttackCool -= Time.deltaTime;
						} else {
							move ();
						}
						break;
					case AiType.Follow:
					
					//are we infront of the player?
						DircetTowards = this.transform.position - player.transform.position;
						angle = Vector2.Angle (player.transform.up, DircetTowards);
						if (angle > 90) {
							this.rigidbody2D.velocity = new Vector2 (0, 0);
							//behind
							GotoPos = player.transform.position - player.transform.up * 3;
						} else {
							//infront
							//create points at either side of and behind the player
							Vector2 left = player.transform.position - (player.transform.right * 3) - player.transform.up;
							Vector2 right = player.transform.position + (player.transform.right * 3) - player.transform.up;
							if (Vector2.Distance (this.transform.position, left) > Vector2.Distance (this.transform.position, right)) {
								//on the right
								GotoPos = right;
							} else {
								//on the left
								GotoPos = left;
							}
						}
						move ();
						break;
						}
					}
				}
			}
		} else {
			FamineHealthImage.SetActive(false);
			HealthBackgroundImage.SetActive(false);
			if (destroyed == false)
			{
				destroyed = true;
				StartCoroutine(destroyFamine());
			}
			//tell player death is dead
			GameObject[] forts = GameObject.FindGameObjectsWithTag("Fort");
			GameObject fort = forts[0];
			float dist = float.MaxValue;
			foreach(GameObject g in forts)
			{
				if(dist> Vector2.Distance(transform.position,g.transform.position))
				{
					fort = g;
					dist = Vector2.Distance(transform.position,g.transform.position);
				}
			}
			fort.SendMessage("BossDefeated");
			GUIScript.FamineKilled = true;
		}
		
	}
	
	void move()
	{
		if (mounted) {
			transform.rigidbody2D.velocity = transform.up * CurrentSpeed;
			Vector3 vectorToTarget = GotoPos - (Vector2)transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			angle -= 90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, Time.deltaTime * 3);
		} else {
			transform.rigidbody2D.velocity = new Vector2(0,0);
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
		}
	}
	public void attacked()
	{
		AttackCool = 2;
		attacking = false;
	}
	IEnumerator destroyFamine()
	{
		this.GetComponent<Animator>().runtimeAnimatorController = FamineDyingController;
		yield return new WaitForSeconds (1);
		Destroy (this.gameObject);
		
	}
}
