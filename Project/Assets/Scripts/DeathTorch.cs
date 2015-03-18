using UnityEngine;
using System.Collections;

public class DeathTorch : MonoBehaviour {
	public static bool deathDead = false;
	public Light light;

	// Use this for initialization
	void Start () 
	{
		//torch = light.GetComponent ("Light");
		//torch.enabled = deathDead;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Z) || deathDead == true) 
		{
			print ("Death is Dead");
			light.enabled = false;
		}

		if(Input.GetKeyUp (KeyCode.Z) || deathDead == false) 
		{
			light.enabled = true;
			print ("Death is not Dead");
		}
	}
}
