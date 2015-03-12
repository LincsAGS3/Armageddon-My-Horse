using UnityEngine;
using System.Collections;

public class EnterFort : MonoBehaviour {

	public GameObject fort;
	public GameObject fortRoof;
	public GameObject Boss;
	public static bool inFort;
	// Use this for initialization
	void Start () 
	{
		inFort = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag == "Player") 
		{
			fort.GetComponent<CircleCollider2D>().enabled = false;
			fortRoof.GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,0.1f);
			Instantiate(Boss,new Vector2(30,35),Quaternion.identity);
			print ("Player in box");
		}
	}

	void OnTriggerExit2D (Collider2D c)
	{

		if (c.gameObject.tag == "Player") 
		{
			//fort.GetComponent<CircleCollider2D>().enabled = true;
			print ("Player out box");
			//fortRoof.GetComponent<SpriteRenderer>().color = new Color (1f,1f,1f,1f);
			inFort = true;
		}
	}
}
