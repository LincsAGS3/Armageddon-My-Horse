using UnityEngine;
using System.Collections;

public class waitToPlay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	float timer = 0;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > 7)
		{
			Application.LoadLevel(1);
		}
	}
}
