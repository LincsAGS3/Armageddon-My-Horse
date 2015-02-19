using UnityEngine;
using System.Collections;

public class MenuChangeSelectionScript : MonoBehaviour
{
		//Variables		
		bool Turned;
		public static int CurrentSelection;
		public GameObject Quit_Button;			//0
		public GameObject Play_Button;			//1
		public GameObject Options_Button;		//2
		public GameObject Leaderboard_Button;	//3

		static GameObject Button_Bar;

		private bool reset;
		private bool MenuSwitch;
		static GameObject MainMenu;		//0 = Main Menu
		static GameObject Options;		//1 = Options
		static GameObject Leaderboard;	//2 = Leaderboard

		static GameObject Icon;	//Options Icon
		static GameObject MainMenu_Button;//Main menu button
		static GameObject MainMenu_Controls_image;
		Vector3 IconStartPosition;

		//leaderboard menu stuff
		static GameObject CompletionTimePanel;
		static GameObject EnemiesKilledPanel;
		static GameObject LeastDamagePanel;
		static GameObject MainMenu_Button2;//Main menu button

	Vector3 StartPosition;
	Vector3 EndPosition;

		// Use this for initialization
		void Start ()
		{
				Turned = false; //Player has not turned
				CurrentSelection = 1; // defualt is Play button

				reset = false;// used to reset the moving fowards and backwards
				MenuSwitch = false; // used to check if the player has just changed menus
				//finding the game objects in the scene
				MainMenu = GameObject.Find ("Main Menu"); //main menu holder
				Options = GameObject.Find ("Options Menu");//options holder
				Leaderboard = GameObject.Find ("Leaderboard Menu");//leaderboard holder
				Button_Bar = GameObject.Find ("Button Panel");
				Icon = GameObject.Find ("Selection icon Image");// icon used to display selection
				MainMenu_Button = GameObject.Find ("Main Menu Button");// main menu button
				MainMenu_Controls_image = GameObject.Find ("WheelChairControls image");
				IconStartPosition = new Vector3 (Icon.transform.localPosition.x, Icon.transform.localPosition.y, Icon.transform.localPosition.z);//icons start position

				//leaderboard pannels
				CompletionTimePanel = GameObject.Find ("Completion Time Panel");
				EnemiesKilledPanel = GameObject.Find ("Enemies Killed Panel");
				LeastDamagePanel = GameObject.Find ("Least Damage Panel");
				MainMenu_Button2 = GameObject.Find ("Main Menu Button2");// main menu button used on leaderboard


		StartPosition = new Vector3(Button_Bar.transform.localPosition.x,Button_Bar.transform.localPosition.y,Button_Bar.transform.localPosition.y);
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				//turning left and right
				if (Turned == false) {
						if (WheelchairMovementScript.CurrentAngle < 315 && WheelchairMovementScript.CurrentAngle > 180) {
								Turned = true;
								if (WheelchairMovementScript.MovedFowards == true && Options.activeSelf) {
										MenuOptionsSelectionScript.SubSelection--;
										MenuOptionsSelectionScript.ProcessSelection (CurrentSelection);
								} else {
										CurrentSelection--;
										ChangeMenuSelection ();
										Debug.Log (CurrentSelection + "" + Turned);
								}
						}
						if (WheelchairMovementScript.CurrentAngle > 45 && WheelchairMovementScript.CurrentAngle < 180) {
								Turned = true;
								if (WheelchairMovementScript.MovedFowards == true && Options.activeSelf) {
										MenuOptionsSelectionScript.SubSelection++;
										MenuOptionsSelectionScript.ProcessSelection (CurrentSelection);
								} else {
										CurrentSelection++;
										ChangeMenuSelection ();
										Debug.Log (CurrentSelection + "" + Turned);
								}
						}
				} else if (Turned == true) {
						if (WheelchairMovementScript.CurrentAngle > 340 || WheelchairMovementScript.CurrentAngle < 20) {
								Turned = false;
								Debug.Log (Turned);
						}
				}

				//moving backwards and fowards
				if (reset == false) {
						if (WheelchairMovementScript.MovedFowards == true) {

								Debug.Log ("MovedFowards Equals true");

								//main menu
								if (MainMenu.activeSelf) {
										MenuMainSelectionScript.ProcessSelection (CurrentSelection);
										CurrentSelection = 0; // reset the selection for next menu
										MenuSwitch = true;
								}
								//options menu
								if (Options.activeSelf) {
										Debug.Log ("Options" + CurrentSelection);

										MenuOptionsSelectionScript.ProcessSelection (CurrentSelection);
								}

								if (Leaderboard.activeSelf && MenuSwitch != true) {
										MenuStateScript.MenuStateChange (0); // changes to the Main menu state
										MenuSwitch = true;
								}
								reset = true;
						}
				} else {
						if (WheelchairMovementScript.MovedFowards == false) {
								Debug.Log ("MovedFowards Equals false");
								if (Options.activeSelf) {
										MenuOptionsSelectionScript.SubSelection = 0; // reset the subselection
							}
								MenuSwitch = false;
								reset = false;
						}					
				}
		if (Leaderboard.activeSelf)
		{
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (MainMenu_Button2); // sets he only button on the leaderboard to active 
				}
				OnGUI (); // used to display variable to the screen to debug
		}

		void OnGUI ()
		{
				//used for debugging, can be removed in main game
				GUI.Label (new Rect (10, 30, 200, 20), "CurrentSelection: " + CurrentSelection);  //  Display the CurrentSelection on a label in the top left
				GUI.Label (new Rect (10, 50, 200, 20), "Player Turned: " + Turned);  //  Display the turned bool on a label in the top lef
				GUI.Label (new Rect (10, 90, 200, 20), "SubSelection: " + MenuOptionsSelectionScript.SubSelection);  //  Display the turned bool on a label in the top left
				GUI.Label (new Rect (10, 110, 200, 20), "Menu Switched: " + MenuSwitch);  //  Display the turned bool on a label in the top left
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
				if (Leaderboard.activeSelf) {

						LeaderboardMenuSelection ();
				}
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
				MainMenu_Controls_image.SetActive (false);

				switch (CurrentSelection) {
				case 0:
			//Play_Button.GetComponent<Animator>().Play("Slide");
			//
			//Debug.Log(StartPosition);
			//EndPosition = new Vector3(100,0,0);
			//Debug.Log(EndPosition);
			//Quit_Button.gameObject.transform.localPosition = new Vector3(Quit_Button.transform.localPosition.x+100,Quit_Button.transform.localPosition.y,Quit_Button.transform.localPosition.y);

			Button_Bar.transform.localPosition = new Vector3(StartPosition.x+400,StartPosition.y,StartPosition.z);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Quit_Button);
						
						break;
				case 1:
			Button_Bar.transform.localPosition = new Vector3(StartPosition.x,StartPosition.y,StartPosition.z);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Play_Button);
						break;
				case 2:
			Button_Bar.transform.localPosition = new Vector3(StartPosition.x-400,StartPosition.y,StartPosition.z);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Options_Button);
						break;
				case 3:
			Button_Bar.transform.localPosition = new Vector3(StartPosition.x-800,StartPosition.y,StartPosition.z);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (Leaderboard_Button);
						break;
				}
		}

		//this hole thing needs to be moved to its own file at some point
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
				//change which button is selected aswell as moving the selection icon
				switch (CurrentSelection) {
				case 0:
						
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y, IconStartPosition.y);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (null);
						break;
				case 1:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 25f, IconStartPosition.y);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (null);
						break;
				case 2:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 50f, IconStartPosition.y);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (null);
						break;
				case 3:
						Icon.transform.localPosition = new Vector3 (IconStartPosition.x, IconStartPosition.y - 75f, IconStartPosition.y);
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (null);
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
				//cycle round the buttons
				if (CurrentSelection < 0) {
						CurrentSelection = 2;
				}
				if (CurrentSelection > 2) {
						CurrentSelection = 0;
				}

				switch (CurrentSelection) {
				case 0: // comp time is selected
						LeastDamagePanel.transform.localPosition = new Vector3 (750, 0, 0);
						CompletionTimePanel.transform.localPosition = new Vector3 (0, 0, 0);
						EnemiesKilledPanel.transform.localPosition = new Vector3 (-750, 0, 0);

						break;
				case 1: // enermies kileld is selected
						CompletionTimePanel.transform.localPosition = new Vector3 (750, 0, 0);
						EnemiesKilledPanel.transform.localPosition = new Vector3 (0, 0, 0);
						LeastDamagePanel.transform.localPosition = new Vector3 (-750, 0, 0);

						break;
				case 2: // least damage is selected
						EnemiesKilledPanel.transform.localPosition = new Vector3 (750, 0, 0);
						LeastDamagePanel.transform.localPosition = new Vector3 (0, 0, 0);
						CompletionTimePanel.transform.localPosition = new Vector3 (-750, 0, 0);

						break;

				}
		}
}