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
		if (other.tag == "Cavalry"||other.tag == "Famine") {
			other.SendMessage("takeDamage",1);
		}
	}
}
