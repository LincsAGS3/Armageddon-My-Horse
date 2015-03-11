using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static float TotalEnemiesKilled;
	//Player Health
	public static float PlayerHealth;
	//player speed
	public static float speed;
	//player rotate speed
	public static float rotateSpeed;
	// Use this for initialization
	void Start () {
		//these are here so that if you restart the game there values are reset
		TotalEnemiesKilled = 0;
		PlayerHealth = 100;
		speed = 5;
		rotateSpeed = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.tag == "Enemy")
			//if (collider.tag == "Boss){ lose more health--;} and so-on
		{
			//Function can be changed to remove health decrementally or provide insta kill
			PlayerHealth--;
		}
		if (PlayerHealth == 0)
		{
			//Game Over...
			MenuGameMenuStateScript.MenuStateChange(2);
		}
	}
	public static void hit(int damage)
	{
		PlayerHealth -= damage;
	}
}
