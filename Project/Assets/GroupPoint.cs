using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupPoint : MonoBehaviour {

	public bool vacancy = true;
	public int maxSize = 16;
	public int size=0;
	public List<GameObject> enemies = new List<GameObject>();
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		size = enemies.Count;
	}
}
