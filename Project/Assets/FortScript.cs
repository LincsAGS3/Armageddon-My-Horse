using UnityEngine;
using System.Collections;

public class FortScript : MonoBehaviour {
	public GroupPoint[] groups;
	public GameObject[] doors;
	public GameObject enemySpawn;
	int halfEnemies = 32;
	float timer = 0;
	int spawned = 0;
	bool opened=false;
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
		if (enemies < halfEnemies) {
			if(!opened)
			{
			foreach(GameObject d in doors)
			{
				d.SendMessage("changeDoorState");
					opened = true;
			}
			}
		}
		else
		{
			if(opened)
			{
				foreach(GameObject d in doors)
				{
					d.SendMessage("changeDoorState");
					opened = false;
				}
			}
		}
		if (enemies < halfEnemies) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				timer = 0.625f;
				Instantiate(enemySpawn,transform.position+transform.up*15,transform.rotation);
				spawned ++;
				if(spawned >= 16)
				{
					timer =10;
					spawned = 0;
				}
			}
		}
	}
}
