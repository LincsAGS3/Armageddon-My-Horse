using UnityEngine;
using System.Collections;

public class MenuStateScript : MonoBehaviour
{
		static GameObject MainMenu;		//0 = Main Menu
		static GameObject Options;		//1 = Options
		static GameObject Leaderboard;	//2 = Leaderboard
	
		// Use this for initialization
		void Start ()
		{
				//finds the menu holder objects
				MainMenu = GameObject.Find ("Main Menu"); 
				Options = GameObject.Find ("Options Menu");
				Leaderboard = GameObject.Find ("Leaderboard Menu");
				MenuStateChange (0); // game starts on main menu
		}

		public static void MenuStateChange (int MenuState)
		{
				switch (MenuState) {
				case 0: //Main Menu
						MainMenu.SetActive (true); // displays the menu
						Options.SetActive (false);// hides the options menu
						Leaderboard.SetActive (false); // hides the leaderboard
						MenuChangeSelectionScript.CurrentSelection = 1; // changes the current selection to 1 which is the play button
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (GameObject.Find ("Play button")); // sets the Play button to the active button
						break;
				case 1: //Options
						MainMenu.SetActive (false); // hides the main menu
						Options.SetActive (true); // displays the option menu
						Leaderboard.SetActive (false);// hides the leaderboard
						MenuChangeSelectionScript.CurrentSelection = 0; // resets the current selection to 0
						break;
				case 2: //Leaderboard
						MainMenu.SetActive (false);// hides the main menu
						Options.SetActive (false); // hides the options menu
						Leaderboard.SetActive (true); // displays the leaderboard
						MenuChangeSelectionScript.CurrentSelection = 0;// resets the current selection to 0
						break;
				}
		}
}
