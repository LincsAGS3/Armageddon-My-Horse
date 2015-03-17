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
	float initTimer = 0;

	void Start () {
		move = new Vector3 (0, 0, 90);
	}
	
	// Update is called once per frame
	void Update () {
		if (initTimer > 10) {
			if (moving && !moved) {
				if (closed) {
					left_door.transform.Rotate (move * -1 * Time.deltaTime);
					right_door.transform.Rotate (move * Time.deltaTime);
				} else {
					left_door.transform.Rotate (move * Time.deltaTime);
					right_door.transform.Rotate (move * -1 * Time.deltaTime);
				}
				time += Time.deltaTime;
				if (time >= 1) {
					time = 0;
					moved = true;

					closed = !closed;
				}

			}
			if (Input.GetKeyDown (KeyCode.L)) {
				changeDoorState ();
			}
		} else {
			initTimer += Time.deltaTime;
			moving = false;
		}
	}
	void changeDoorState()
	{

		moved = false;
		moving = true;
	}
}
