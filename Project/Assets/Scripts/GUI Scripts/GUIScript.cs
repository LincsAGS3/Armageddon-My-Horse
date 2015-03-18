using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

					
	public static float CurrentTime = 100;


	//text
	static GameObject TimePlayed;
	static GameObject EnemiesKilled;

	//images
	static GameObject Death;
	static GameObject Famine;
	static GameObject Conquest;
	static GameObject HealthImage;

	 public GameObject Ltorch;
	 public GameObject Rtorch;
	public GameObject Gate;
	//sprites
	public Sprite DeathAlive;
	public Sprite DeathDead;

	public Sprite FamineAlive;
	public Sprite FamineDead;

	public Sprite ConquestAlive;
	public Sprite ConquestDead;

	public Sprite torchOff;
	public Sprite torchOn;

	public static bool DeathKilled = true;
	public static bool FamineKilled = true;
	public static bool ConquestKilled = false;

	float startTime;
	float ElapsedTime;
	// Use this for initialization
	void Start () {

		startTime = Time.time;
		ElapsedTime = 0;
		TimePlayed = GameObject.Find ("TimePlayed");
		EnemiesKilled = GameObject.Find ("EnemiesKilled");

		Death = GameObject.Find ("Death");
		Famine = GameObject.Find ("Famine");
		Conquest = GameObject.Find ("Conquest");

		HealthImage =  GameObject.Find("HealthBar");

		Death.GetComponent<Image> ().sprite = DeathAlive;
		Famine.GetComponent<Image>().sprite = FamineAlive;
		Conquest.GetComponent<Image> ().sprite = ConquestAlive;
	}
	
	// Update is called once per frame
	void Update () {
		ElapsedTime = Time.time - startTime;
		TimePlayed.GetComponent<Text> ().text = "Time : " + ElapsedTime.ToString ("0.");
		EnemiesKilled.GetComponent<Text> ().text = "Enemies Killed : " + Player.TotalEnemiesKilled.ToString ();

		HealthImage.GetComponent<Image> ().fillAmount = Player.PlayerHealth / 100;
		if (DeathKilled == true) {
			Death.GetComponent<Image> ().sprite = DeathDead;
			Rtorch.GetComponent<SpriteRenderer> ().sprite = torchOn;
		}
		if (FamineKilled == true) {
			Famine.GetComponent<Image> ().sprite = FamineDead;
			Ltorch.GetComponent<SpriteRenderer> ().sprite = torchOn;
		}
		if (ConquestKilled == true) {
			Conquest.GetComponent<Image> ().sprite = ConquestDead;
		}
		if (DeathKilled && FamineKilled) {
			Gate.collider2D.enabled = false;
			Gate.renderer.enabled = false;
		}
		if (Player.PlayerHealth < 0) {
			Application.LoadLevel (2);
		}
		if (ConquestKilled) {
			Application.LoadLevel(3);
		}
	}
	}
}
