using UnityEngine;
using System.Collections;

public class Sword_Swing : MonoBehaviour {
	//flag to say which direction is swinging/ will be swinging
	bool top = false;
	//should the sword be swinging
	bool swing = false;
    bool startSwing = false;
	float time = 0;
	public GameObject swordSprite;
    public Collider2D[] colliders;
    public AudioClip[] audioClip;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        startSwing = false;
        colliders = Physics2D.OverlapCircleAll(transform.position, 20.0f);
        foreach (Collider2D col in colliders)
        {
            if ((col.gameObject.tag == "Enemy") || (col.gameObject.tag == "Cavalry") || (col.gameObject.tag == "Famine") || (col.gameObject.tag == "Death") || (col.gameObject.tag == "Conquest"))
            {
                Debug.Log("startSwing = true");
                startSwing = true;
                break;
            }
            
        }
        if (startSwing == false)
            swing = false;
        else
            swing = true;


		if (Input.GetKeyDown (KeyCode.Space)) {
			swing = !swing;
		}
		if (swing) {
			swordSprite.collider2D.enabled = true;
		} else {
			swordSprite.collider2D.enabled = false;
		}
		if (top) {
			if (time > 1) 
            {
				if (swing) {
					time = 0;
					top = false;
                    playSound(UnityEngine.Random.Range(0, 4));
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
                    playSound(UnityEngine.Random.Range(0,4));
				}
			} else {
				this.transform.Rotate (new Vector3 (0, 0, -(180 * Time.deltaTime)));
				time += Time.deltaTime;
			}
		}
	}
    void playSound(int Clip)
    {
        audio.clip = audioClip[Clip];
        audio.Play();
    }
}
