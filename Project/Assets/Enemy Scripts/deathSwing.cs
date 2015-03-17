using UnityEngine;
using System.Collections;

public class deathSwing : MonoBehaviour {

	bool top = false;
	//should the sword be swinging
	bool swing = true;
	float time = 0;
	public GameObject swordSprite;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (StateControl.State != StateControl.state.Pause) {
			if (top) {
				if (time > 1) {
					if (swing) {
						time = 0;
						top = false;
					}
				} else {
					this.transform.Rotate (new Vector3 (0, 0, (180 * Time.deltaTime)));
					time += Time.deltaTime;
				}
			} else {
				if (time > 1) {
					if (swing) {
						time = 0;
						top = true;
					}
				} else {
					this.transform.Rotate (new Vector3 (0, 0, -(180 * Time.deltaTime)));
					time += Time.deltaTime;
				}
			}
		}
	}
}