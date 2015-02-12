using UnityEngine;
using System.Collections;

public class MenuChangeSelectionScript : MonoBehaviour
{

		//Variables		
		bool Turned;
		public static bool MovedFowards;
		int CurrentSelection;
		public GameObject Quit_Button;			//0
		public GameObject Play_Button;			//1
		public GameObject Options_Button;		//2
		public GameObject Leaderboard_Button;	//3

		private bool reset;
		static GameObject MainMenu;		//0 = Main Menu
		static GameObject Options;		//1 = Options
		static GameObject Leaderboard;	//2 = Leaderboard

		static GameObject Icon;	//Options Icon
		static GameObject MainMenu_Button;
		Vector3 IconStartPosition;
		// Use this for initialization
		void Start ()
		{
				MovedFowards = false;
				Turned = false;
				CurrentSelection = 1; // defualt is Play button

				reset = false;

				MainMenu = GameObject.Find ("Main Menu"); 
				Options = GameObject.Find ("Options Menu");
				Leaderboard = GameObject.Find ("Leaderboard Menu");

				Icon = GameObject.Find ("Selection icon Image");
				MainMenu_Button = GameObject.Find ("Main Menu Button");
				IconStartPosition = new Vector3 (Icon.transform.localPosition.x, Icon.transform.localPosition.y, Icon.transform.localPosition.z);
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Turned == false) {
						if (WheelchairMovementScript.CurrentAngle < 315 && WheelchairMovementScript.CurrentAngle > 180) {
								Turned = true;
								CurrentSelection--;
								ChangeMenuSelection ();
								Debug.Log (CurrentSelection + "" + Turned);
						}
						if (WheelchairMovementScript.CurrentAngle > 45 && WheelchairMovementScript.CurrentAngle < 180) {
								Turned = true;
								CurrentSelection++;
								ChangeMenuSelection ();
								Debug.Log (CurrentSelection + "" + Turned);
						}
				} else if (Turned == true) {
						if (WheelchairMovementScript.CurrentAngle > 340 || WheelchairMovementScript.CurrentAngle < 20) {
								Turned = false;
								Debug.Log (Turned);
						}
				}
				if (reset == false) {
						if (MovedFowards == true) {
								Debug.Log ("MovedFowards Equals true");
								if (MainMenu.activeSelf) {
										MenuMainSelectionScript.ProcessSelection (CurrentSelection);
										CurrentSelection = 0; // reset the selection for next menu
								}
								reset = true;
						}
						if (MovedFowards == false) {
								Debug.Log ("MovedFowards Equals false");
								reset = false;
						}
						
				}

				OnGUI ();
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (10, 30, 200, 20), "CurrentSelection: " + CurrentSelection);  //  Display the CurrentSelection on a label in the top left
				GUI.Label (new Rect (10, 50, 200, 20), "Player Turned: " + Turned);  //  Display the turned bool on a label in the top left
				GUI.Label (new Rect (10, 70, 200, 20), "Player MovedFowards: " + MovedFowards);  //  Display the MovedFowards on a label in the top left
		}

		void ChangeMenuSelection ()
		{
				//Main menu

				if (MainMenu.activeSelf) {
						MainMenuSelection ();
						
				} 

				//Options Menu
				if (Options.activeSelf) {
						OptionsMenuSelection ();
				}
				//Leaderboard - Name Input

				//Leaderboard - Main
		}

		void MainMenuSelection ()
		{
				//cycle round the buttons
				if (CurrentSelection < 0) {
						CurrentSelection = 3;
				}
				if (CurrentSelection > 3) {
						CurrentSelection = 0;
				}
		
				//change which button is selected
				switch (CurrentSelection) {
				case 0:
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Quit_Button);
						break;
				case 1:
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Play_Button);
						break;
				case 2:
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Options_Button);
						break;
				case 3:
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Leaderboard_Button);
						break;
				}
		}

		void OptionsMenuSelection ()
		{
				//cycle round the buttons
				if (CurrentSelection < 0) {
						CurrentSelection = 4;
				}
				if (CurrentSelection > 4) {
						CurrentSelection = 0;
				}
				Debug.Log (IconStartPosition.x);
				//change which button is selected
				switch (CurrentSelection) {
				case 0:
						Debug.Log ("im here");
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y, IconStartPosition.y);
						break;
				case 1:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 25f, IconStartPosition.y);
						break;
				case 2:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 50f, IconStartPosition.y);
						break;
				case 3:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 75f, IconStartPosition.y);
						break;
				case 4:
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (MainMenu_Button);
						break;

				}
		}

		void LeaderboardNameInput ()
		{
		}

		void LeaderboardMenuSelection ()
		{
		}
}
