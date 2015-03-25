using UnityEngine;
using System.Collections;

public class RoofDisappear : MonoBehaviour {
	public GameObject roof;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{


	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			roof.GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,0.1f);
			print ("Player in box");
		}
	}
}
