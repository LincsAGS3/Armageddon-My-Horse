using UnityEngine;
using System.Collections;

public class Cavalry_movement : MonoBehaviour {

	public int health = 5;

	float maxSpeed = 11;
	float MaxTurningSpeed = 4;
	float Acceleration = 11;
	float MaxRotationSpeed = 30;

	float CurrentSpeed = 5;

	Vector2 CurrentIdlePos = new Vector2(-1,-1);
	Vector2 GotoPos = new Vector2(0,0);

	void Start () {
		//find a group point
		CurrentIdlePos = GameObject.FindGameObjectWithTag ("Group").transform.position;
		GotoPos = FindNextPoint (CurrentIdlePos);
	}
	
	// Update is called once per frame
	void Update () {
		//move forwards
		transform.rigidbody2D.velocity = transform.up * CurrentSpeed;
		Vector3 vectorToTarget = GotoPos - (Vector2)transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		angle -= 90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3);
		if (Vector2.Distance (transform.position, GotoPos) < 4) {
			GotoPos = FindNextPoint(CurrentIdlePos);
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
			Debug.Log ("collision");
			//goto a new point
			GotoPos = FindNextPoint (CurrentIdlePos);
		}
	}
}
