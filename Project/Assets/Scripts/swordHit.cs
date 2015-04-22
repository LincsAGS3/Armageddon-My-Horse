using UnityEngine;
using System.Collections;

public class swordHit : MonoBehaviour {

	// Use this for initialization
	public Sprite scyth;
	bool first = true;
    public AudioClip[] audioClip;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (first) {
			if (GUIScript.DeathKilled) {
				this.GetComponent<SpriteRenderer> ().sprite = scyth;
				BoxCollider2D b = transform.collider2D as BoxCollider2D;
				b.size = new Vector2 (0.14f, 0.39f);
				first = false;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log ("sword hit");
			
		if (coll.transform.tag == "Enemy" ||coll.transform.tag == "Rider") {
			Debug.Log("sending message");
			if(GUIScript.DeathKilled)
			{
			coll.gameObject.SendMessage ("damaged",5);
			}
			else
			{
				coll.gameObject.SendMessage ("damaged",1);
			}
        playSound(UnityEngine.Random.Range(0,5));
		}
        

	}
    void playSound(int Clip)
    {
        audio.clip = audioClip[Clip];
        audio.Play();
    }
}
