using UnityEngine;
using System.Collections;

public class conquestEnemiesSpawn : MonoBehaviour {

	public GroupPoint[] groups;
	public GameObject enemySpawn;
	public GameObject boss;
	int halfEnemies = 96;
	float timer = 0;
	int spawned = 0;
	bool opened=false;
	bool entered  = false;
	bool bossing = false;
	bool spwan = true;
	float init = 0;
	// Use this for initialization
	void Start () {
		//spawn initial infantry
		foreach (GroupPoint g in groups) {
			Vector2 point = g.transform.position;
			for(int i = 0;i<8;i++)
			{
				Instantiate(enemySpawn,point,transform.rotation);
				point.y += 1;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		int enemies = 0;
		init += Time.deltaTime;
		foreach (GroupPoint g in groups) {
			enemies += g.size;
		}
		if (spwan) {
			if (enemies < halfEnemies * 2) {
				timer -= Time.deltaTime;
				if (timer < 0) {
					foreach(GroupPoint g in groups)
					{
						if(g.size<g.maxSize)
						{
							Instantiate (enemySpawn, g.transform.position, transform.rotation);
						}
					}
					timer = 10;
					spawned = 0;
				}
			}
		}
		if (init > 5)
		if (!bossing)
		if (enemies < halfEnemies) {
			Debug.Log ("triggered");
			opened = false;
			Instantiate (boss, transform.position, transform.rotation);
			bossing = true;
            Player.conquestFound = true;
            Debug.Log("Conquest found");
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"&&!bossing ) {

		}
	}
}
