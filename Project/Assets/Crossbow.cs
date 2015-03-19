using UnityEngine;
using System.Collections;

public class Crossbow : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	public GameObject bolt;
	float timer = 0;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rotation = Quaternion.LookRotation ((player.transform.position+player.transform.up*player.rigidbody2D.velocity.magnitude*2) - transform.position,
		                                               transform.TransformDirection (Vector3.up));
		transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		//what is the players equation
		timer += Time.deltaTime;
		if (timer > 5) {
			Instantiate (bolt, (Vector2)this.transform.position- (Vector2)this.transform.right*2, this.transform.rotation);
			timer = 0;
		}
	}
}
