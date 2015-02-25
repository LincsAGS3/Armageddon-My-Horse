using UnityEngine;
using System.Collections;

public class MenuGameMenuStateScript : MonoBehaviour {
											//0 No menu
	static GameObject VictoryMenu;			//1 = victory
	static GameObject DefeatMenu;			//2 = Defeat
	static GameObject ThreeCharInputMenu;	//3 = ThreeCharInput
	static GameObject LeaderboardMenu;		//4 = Leaderboard

	static GameObject SmokeEffect;
	
	// Use this for initialization
	void Start ()
	{
		//finds the menu holder objects
		VictoryMenu = GameObject.Find ("VictoryMenu"); 
		DefeatMenu = GameObject.Find ("DefeatMenu");
		ThreeCharInputMenu = GameObject.Find ("NameInputMenu");
		LeaderboardMenu = GameObject.Find ("LeaderboardMenu");
		SmokeEffect = GameObject.Find ("MenuSmoke");
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
			SmokeEffect.SetActive(false); 
			break;
		case 1: 
			VictoryMenu.SetActive (true); //Displays the Victory Menu
			break;
		case 2: 
			DefeatMenu.SetActive (true); // Displays the Defeat Menu
			break;
		case 3: 
			VictoryMenu.SetActive (false); // Hides the victory menu
			ThreeCharInputMenu.SetActive (true); //displays the three char input menu
			SmokeEffect.SetActive(true); 
			break;
		case 4: 
			ThreeCharInputMenu.SetActive (false); // hides the three char input menu
			LeaderboardMenu.SetActive (true); //displays the Leaderboard menu
			SmokeEffect.SetActive(true); 
			break;
		}
	}
}
