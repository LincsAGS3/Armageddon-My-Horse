using UnityEngine;
using System.Collections;

public class ScytheHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Debug.Log ("Scythe hit");
		
		if (c.transform.tag == "Player" ) {
			Debug.Log("sending message");
			this.transform.parent.parent.SendMessage("attacked");
			//c.gameObject.SendMessage ("damaged");
		}
		
	}
}
