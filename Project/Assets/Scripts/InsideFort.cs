using UnityEngine;
using System.Collections;

public class InsideFort : MonoBehaviour {
	public GameObject fort;
	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			fort.GetComponent<CircleCollider2D>().enabled = false;
			print ("Player in box");
		}
	}
}
