using UnityEngine;
using System.Collections;

public class ScytheSwing : MonoBehaviour {

	bool top = false;
	//should the sword be swinging
	bool swing = true;
	float time = 0;
	public GameObject scytheSprite;
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () {
		if (swing) {
			scytheSprite.collider2D.enabled = false;
		} else {
			scytheSprite.collider2D.enabled = true;
		}
		if (top) {
			if (time > 1) {
				if (swing) {
					time = 0;
					top = false;
				}
			} else {
				this.transform.Rotate (new Vector3 (0, 0, (360 * Time.deltaTime)));
				time += Time.deltaTime;
			}
		} else {
			if (time > 1) {
				if (swing) {
					time = 0;
					top = true;
				}
			} else {
				this.transform.Rotate (new Vector3 (0, 0, -(360 * Time.deltaTime)));
				time += Time.deltaTime;
			}
		}
	}
}
