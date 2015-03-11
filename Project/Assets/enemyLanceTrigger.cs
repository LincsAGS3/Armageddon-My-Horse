using UnityEngine;
using System.Collections;

public class enemyLanceTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			this.transform.parent.parent.SendMessage("attacked");
			if(this.transform.parent.parent.tag == "Famine")
			{
				Player.hit((int)this.transform.parent.parent.GetComponent<FamineBehavior>().damage);
			}
			else
			{
				Player.hit((int)this.transform.parent.parent.GetComponent<Cavalry_movement>().damage);
			}
		}
	}
}
