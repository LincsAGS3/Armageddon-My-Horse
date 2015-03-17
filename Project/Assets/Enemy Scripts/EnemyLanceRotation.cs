using UnityEngine;
using System.Collections;

public class EnemyLanceRotation : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float angle = Vector2.Angle (this.transform.parent.transform.up,
		                             player.transform.position - transform.position);
		if (angle > 360) {
			angle -= 360;
		}
		if ((angle < 60 && angle < 180) ) {
			Quaternion rotation = Quaternion.LookRotation (player.transform.position - transform.position,
			                                               transform.TransformDirection (Vector3.up));
			transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
		} else {
			transform.eulerAngles = transform.parent.transform.eulerAngles + new Vector3(0,0,-90);
		}
	}
}
