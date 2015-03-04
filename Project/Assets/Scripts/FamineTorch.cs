using UnityEngine;
using System.Collections;

public class FamineTorch : MonoBehaviour {
	bool famineDead = false;
	public Light light;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			famineDead = true;
			print ("Famine is Dead");
			light.enabled = false;
		}
		
		if(Input.GetKeyUp (KeyCode.Z)) 
		{
			famineDead = false;
			light.enabled = true;
			print ("Famine is not Dead");
		}
	
	}
}
