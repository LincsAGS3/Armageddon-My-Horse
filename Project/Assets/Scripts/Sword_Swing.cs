using UnityEngine;
using System.Collections;

public class Sword_Swing : MonoBehaviour {
	//flag to say which direction is swinging/ will be swinging
	bool top = false;
	//should the sword be swinging
	bool swing = false;
	float time = 0;
	public GameObject swordSprite;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			swing = !swing;
		}
		if (swing) {
			swordSprite.collider2D.enabled = true;
		} else {
			swordSprite.collider2D.enabled = false;
		}
			if(top)
			{
				if(time > 1)
				{
					if(swing)
					{
						time = 0;
						top = false;
					}
				}
				else
				{
					this.transform.Rotate (new Vector3 (0, 0, (180*Time.deltaTime)));
					time += Time.deltaTime;
				}
			}
			else
			{
				if(time > 1)
				{
					if(swing)
					{
						time = 0;
						top = true;
					}
				}
				else
				{
					this.transform.Rotate (new Vector3 (0, 0, -(180*Time.deltaTime)));
					time += Time.deltaTime;
				}
			}
		}

}
