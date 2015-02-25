using UnityEngine;
using System.Collections;

public class swordHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("sword hit");
			
		if (coll.transform.tag == "Enemy") {
				
			coll.gameObject.SendMessage ("damaged");
		}

	}
}
