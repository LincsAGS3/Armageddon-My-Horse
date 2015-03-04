using UnityEngine;
using System.Collections;

public class CavalrySpawner : MonoBehaviour {
	public GameObject cavalry;
	public GameObject lFort;
	public GameObject rFort;
	public int numCavalry;

	int health;
	Cavalry_movement cavalryHealth;
	
	int lFortNumCavalry;
	int rFortNumCavalry;
	
	// Use this for initialization
	void Start () 
	{
		lFortNumCavalry = 0;
		rFortNumCavalry = 0;
		health = cavalryHealth.health;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 lTemp = new Vector2 (lFort.transform.position.x + 100 + Random.Range(-20, 20), lFort.transform.position.y + 100 + Random.Range(-20, 20));
		Vector2 rTemp = new Vector2 (rFort.transform.position.x + 100 + Random.Range(-20, 20), rFort.transform.position.y + 100 + Random.Range(-20, 20));

		if (lFortNumCavalry < numCavalry)
		{
			GameObject tempCavalry = Instantiate(cavalry,lTemp,Quaternion.identity) as GameObject;
			tempCavalry.name = "LeftCavalry";
			lFortNumCavalry += 1;
		}
		
		if (rFortNumCavalry < numCavalry)
		{
			GameObject tempCavalry = Instantiate(cavalry,rTemp,Quaternion.identity) as GameObject;
			tempCavalry.name = "RightCavalry";
			rFortNumCavalry += 1;
		}

		if (health == 0 && name == "LeftCavalry") 
		{
			lFortNumCavalry = numCavalry - 1;
		}

		if (health == 0 && name == "RightCavalry") 
		{
			rFortNumCavalry = numCavalry - 1;
		}

	}
}
