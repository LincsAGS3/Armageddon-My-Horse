using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupPoint : MonoBehaviour {

	public bool vacancy = true;
	public int maxSize = 16;
	public int size=0;
	public List<GameObject> enemies = new List<GameObject>();
	public bool active = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Set the size
		size = enemies.Count;
		for (int i = 0; i < size; i++) {
			enemies[i].GetComponent<Infantry_Movement>().groupPoint = gameObject;
			if(enemies[i].GetComponent<Infantry_Movement>().dead)
			{
				enemies.RemoveAt(i);
				break;
				size -=1;
			}
		}
		//set the vacancy flag
		if (size < maxSize) {
			vacancy = true;
		} else
			vacancy = false;
		//if there is room look for free infantry
		if (active)
		if (vacancy) {
			//get all of the infantry
			GameObject[] infantry = GameObject.FindGameObjectsWithTag ("Enemy");
			//object ot hold the best infantry
			GameObject im = null;
			//float to store the closest distance
			float dist = float.MaxValue;
			//loop through all actors
			foreach(GameObject g in infantry)
			{
				//find out how close they are
				float tempDist = Vector2.Distance(this.transform.position, g.transform.position);
				//get eht script fromt he actor
				Infantry_Movement temp = g.GetComponent<Infantry_Movement>();
				//check if the player has already been assigned a group point
				if(!temp.alloc)
				{

					if(tempDist < dist)
					{
						im = g;
						dist = tempDist;
					}
				}
			}
			if(im != null)
			{
				Infantry_Movement temp = im.GetComponent<Infantry_Movement>();
				temp.alloc = true;
				temp.groupPoint = this.gameObject;
				enemies.Add(im);
			}
		}
	}
}
