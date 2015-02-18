using UnityEngine;
using System.Collections;

public class MenuGameMenuStateScript : MonoBehaviour {
											//0 No menu
	static GameObject VictoryMenu;			//1 = victory
	static GameObject DefeatMenu;			//2 = Defeat
	static GameObject ThreeCharInputMenu;	//3 = ThreeCharInput
	static GameObject LeaderboardMenu;		//4 = Leaderboard
	
	// Use this for initialization
	void Start ()
	{
		//finds the menu holder objects
		VictoryMenu = GameObject.Find ("VictoryMenu"); 
		DefeatMenu = GameObject.Find ("DefeatMenu");
		ThreeCharInputMenu = GameObject.Find ("NameInputMenu");
		LeaderboardMenu = GameObject.Find ("LeaderboardMenu");
		MenuStateChange (0); // game starts  with showing nothing
	}
	
	public static void MenuStateChange (int MenuState)
	{
		switch (MenuState) {
		case 0: //hide everything
			VictoryMenu.SetActive(false); 
			DefeatMenu.SetActive(false); 
			ThreeCharInputMenu.SetActive(false); 
			LeaderboardMenu.SetActive(false); 
			break;
		case 1: 
			VictoryMenu.SetActive (true); 
			break;
		case 2: 
			DefeatMenu.SetActive (true); 
			break;
		case 3: 
			Debug.Log("entred");
			VictoryMenu.SetActive (false); 
			ThreeCharInputMenu.SetActive (true); 
			break;
		case 4: 
			ThreeCharInputMenu.SetActive (false);
			LeaderboardMenu.SetActive (true); 
			break;
		}
	}
}
