using UnityEngine;
using System.Collections;

public class LanceTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Cavalry"||other.tag == "Famine"||other.tag == "Death") {
			if(GUIScript.FamineKilled)
			{
				int dam =(int)( 5f*(1f-((float)Player.PlayerHealth / 30f) +0.5f));
				Debug.Log("damage"+dam);
			other.SendMessage("takeDamage",dam);
			}
			else
			{
				other.SendMessage("takeDamage",5);
			}
		}
	}
}
