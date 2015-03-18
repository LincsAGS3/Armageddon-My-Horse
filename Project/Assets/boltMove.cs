using UnityEngine;
using System.Collections;

public class boltMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.transform.rigidbody2D.velocity = -transform.right * 20;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Player") {
			Player.hit (5);
			Destroy (this.gameObject);
		}
		if(coll.transform.tag == "Wall") {
			Destroy (this.gameObject);
		}

	}
}
