using UnityEngine;
using System.Collections;

public class FortScript : MonoBehaviour {
	public GroupPoint[] groups;
	public GameObject[] doors;
	public GameObject enemySpawn;
	public GameObject boss;
    public GameObject bossHealth;
    public GameObject bossHealthBackground;
    public GameObject GUI;
	int halfEnemies = 32;
	float timer = 0;
	int spawned = 0;
	bool opened=false;
	bool entered  = false;
	bool bossing = false;
	bool spwan = true;
    bool famineDeath = false;
    bool deathDeath = false;
    bool conquestDeath = false;
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
		foreach (GroupPoint g in groups) {
			enemies += g.size;
		}
		if (!bossing) {
			if (enemies < halfEnemies) {
				if (!opened) {
					foreach (GameObject d in doors) {
						d.SendMessage ("changeDoorState");
						opened = true;
					}
				}
			} else {
				if (opened) {
					foreach (GameObject d in doors) {
						d.SendMessage ("changeDoorState");
						opened = false;
					}
				}
			}
		}
		if (spwan) {
			if (enemies < halfEnemies) {
				timer -= Time.deltaTime;
				if (timer < 0) {
					timer = 0.625f;
					Instantiate (enemySpawn, transform.position + transform.up * 17, transform.rotation);
					spawned ++;
					if (spawned >= 16) {
						timer = 10;
						spawned = 0;
					}
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"&&!bossing ) 
        {
            if (entered == false)
            {
                entered = true;
                Debug.Log("triggered");
                foreach (GameObject d in doors)
                {
                    d.SendMessage("changeDoorState");
                }
                opened = false;
                Instantiate(boss, transform.position, transform.rotation);
                bossHealth.SetActive(true);
                bossHealthBackground.SetActive(true);
                other.audio.Stop();
                if (boss.name == "Famine")
                {
                    Player.famineFound = true;
                    Debug.Log("Famine found");
                }
                if (boss.name == "Death")
                {
                    Player.deathFound = true;
                    Debug.Log("Death found");
                }
                if (boss.name == "Conquest")
                {
                    Player.conquestFound = true;
                    Debug.Log("Conquest found");
                }
                bossing = true;
            }
		}
	}
	void BossDefeated()
	{
        
		if (!opened) {
			foreach(GroupPoint g in groups)
			{
				g.active = false;
			}
			opened = true;
			foreach (GameObject d in doors) {
				d.SendMessage ("changeDoorState");
				spwan = false;
			}
		}
        if ((boss.name == "Famine")&&(famineDeath == false))
        {
            Player.famineFound = false;
            Player.soundPlaying = false;
            Debug.Log("Famine lost");
            famineDeath = true;
            bossHealth.SetActive(false);
            bossHealthBackground.SetActive(false);
        }
        if ((boss.name == "Death") && (deathDeath == false))
        {
            Player.deathFound = false;
            Player.soundPlaying = false;
            Debug.Log("Death lost");
            deathDeath = true;
            bossHealth.SetActive(false);
            bossHealthBackground.SetActive(false);
        }

	}
}
