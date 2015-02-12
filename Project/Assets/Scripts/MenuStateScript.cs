using UnityEngine;
using System.Collections;

public class MenuStateScript : MonoBehaviour {

	static GameObject MainMenu;		//0 = Main Menu
	static GameObject Options;		//1 = Options
	static GameObject Leaderboard;	//2 = Leaderboard
	
	// Use this for initialization
	void Start () {
		//finds the menu holder objects
		MainMenu = GameObject.Find("Main Menu"); 
		Options = GameObject.Find("Options Menu");
		Leaderboard = GameObject.Find("Leaderboard Menu");
		MenuStateChange(0); // game starts on main menu
	}

	public static void MenuStateChange(int MenuState)
	{
		switch (MenuState) {
		case 0: //Main Menu
			MainMenu.SetActive(true);
			Options.SetActive(false);
			Leaderboard.SetActive(false);
			break;
		case 1: //Options
			MainMenu.SetActive(false);
			Options.SetActive(true);
			Leaderboard.SetActive(false);
			break;
		case 2: //Leaderboard
			MainMenu.SetActive(false);
			Options.SetActive(false);
			Leaderboard.SetActive(true);
			break;
				}
	}
}
