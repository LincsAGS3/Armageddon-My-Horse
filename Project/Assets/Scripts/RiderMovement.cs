using UnityEngine;
using System.Collections;

public class RiderMovement : MonoBehaviour {

	public bool Mounted = true;
	bool fallen = false;
	GameObject Horse;
	Vector2 direction = new Vector2(0,0);
	float speed = 5;
	float timer = 5;
	void Start () {
		Horse = this.transform.parent.gameObject;
	}

	void Update () {
		if (!Mounted && !fallen) {
			this.gameObject.AddComponent<Rigidbody2D>();
			rigidbody2D.gravityScale = 0;
			rigidbody2D.fixedAngle = true;
			fallen = true;
			Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
			direction = this.transform.position - playerPos;
			direction.Normalize();
			transform.parent = null;
		}
		if (timer < 0&& !Mounted) {
			rigidbody2D.velocity = new Vector2(0,0);
			direction = this.transform.position - Horse.transform.position;
			direction.Normalize();
			transform.position = Vector2.MoveTowards(transform.position,Horse.transform.position,
			                                         2*Time.deltaTime);
			if(Vector2.Distance(this.transform.position, Horse.transform.position)<2)
			{
				Mounted = true;
				this.transform.parent = Horse.transform;
				fallen = false;
				speed = 5;
				timer = 5;
				this.transform.localPosition = new Vector3(0,0,-1);
				Horse.GetComponent<FamineBehavior>().mounted = true;
				Destroy(rigidbody2D);
			}
		}
		else if (!Mounted) {
			timer -= Time.deltaTime;
			if(speed > 0)
			{
				transform.Translate(direction*speed*Time.deltaTime);
				speed -= 1*Time.deltaTime;
			}
			else
			{
				speed = 0;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			if (Player.speed > 8) {
				Debug.Log ("trample");
				Horse.GetComponent<Cavalry_movement> ().health -= 1;
			}
		}
	}
	void damaged()
	{
		Debug.Log("sword");
		if (Horse.tag == "Cavalry") {
			Horse.GetComponent<Cavalry_movement> ().health -= 1;
		}
		if (Horse.tag == "Famine") {
			Horse.GetComponent<FamineBehavior> ().health -= 1;
		}
	}
}
