using UnityEngine;
using System.Collections;

public class StateControl : MonoBehaviour {

	public enum state {Pause,Play};
	public static state State = state.Play;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			if(State == state.Pause)
			{
				State = state.Play;
			}
			else if(State == state.Play)
			{
				State = state.Pause;
			}
			Debug.Log (State);
		}
	}
}
