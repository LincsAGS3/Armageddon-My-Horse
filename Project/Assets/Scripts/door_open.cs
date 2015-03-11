using UnityEngine;
using System.Collections;

public class door_open : MonoBehaviour {

	public GameObject left_door;
	public GameObject right_door;
	float time = 0;
	public bool closed = true;
	Vector3 move;
	bool moving = false;
	bool moved = false;
	bool open = false;
	public GroupPoint[] groups;
	public GameObject enemySpawn;
	int halfEnemies = 64;
	float timer = 0;
	int spawned = 0;

	public bool inTheFort;
	void Start () {
		move = new Vector3 (0, 0, 90);
		inTheFort = EnterFort.inFort;
	}
	
	// Update is called once per frame
	void Update () {
		int enemies = 0;
		foreach (GroupPoint g in groups) {
			enemies += g.size;
		}
		bool prev = open;
		if (enemies < halfEnemies) {
			open = true;
		} else {
			open = false;
		}
		Debug.Log (enemies);
		if (prev != open) {
			changeDoorState();
		}
		if (enemies < 128) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				timer = 0.625f;
				if (inTheFort == false)
				{
				Instantiate(enemySpawn,transform.position+transform.up*5,transform.rotation);
				spawned ++;
				}
				if(spawned >= 16)
				{
					timer =10;
					spawned = 0;
				}
			}
		}
		if (moving && !moved) {
			if(closed)
			{
				left_door.transform.Rotate (move*-1*Time.deltaTime);
				right_door.transform.Rotate (move * Time.deltaTime);
			}
			else 
			{
			left_door.transform.Rotate (move*Time.deltaTime);
			right_door.transform.Rotate (move*-1 * Time.deltaTime);
			inTheFort = true;
			}
			time += Time.deltaTime;
			if(time >= 1)
			{
				time = 0;
				moved = true;

				closed = !closed;
			}

		}
		if(Input.GetKeyDown(KeyCode.L) || Player.TotalEnemiesKilled >= 64)
		{
			changeDoorState();
		}
	}

	void changeDoorState()
	{

		moved = false;
		moving = true;
	}
}
