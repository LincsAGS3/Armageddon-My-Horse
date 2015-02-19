using UnityEngine;
using System.Collections;
using System;

//added for array.sort
using UnityEngine.UI;//added

public class MenuInputThreeInitials : MonoBehaviour
{

		int Acounter;
		int Bcounter;
		int Ccounter;
		string[]AlphabetArray = {" ","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
		string Name;
		static GameObject A;
		static GameObject B;
		static GameObject C;
		static GameObject Icon;	//Icon
		static GameObject MainMenu_Button; //Main menu button
		Vector3 IconStartPosition;
		bool Turned;
		private bool reset;
		int CurrentSelection;
		int Plus;
		int Minus;
		// Use this for initialization
		void Start ()
		{
				//counters which go from 0 to 27, blank space + the alphapbet
				Acounter = 0;
				Bcounter = 0;
				Ccounter = 0;

				//fins the the game objects which contain the players letters
				A = GameObject.Find ("TextFirstLetter");
				B = GameObject.Find ("TextSecondLetter");
				C = GameObject.Find ("TextThirdLetter");
	
				Icon = GameObject.Find ("Selection icon Image");
				MainMenu_Button = GameObject.Find ("Main Menu Button");

				IconStartPosition = new Vector3 (Icon.transform.localPosition.x, Icon.transform.localPosition.y, Icon.transform.localPosition.z); // starting position of the icon

				Turned = false;			
				reset = false;
				CurrentSelection = 0;

				Plus = 1;
				Minus = -1;
		}
	
		// Update is called once per frame
		void Update ()
		{

				//turning left and right
				if (Turned == false) {
						if (WheelchairMovementScript.CurrentAngle < 315 && WheelchairMovementScript.CurrentAngle > 180) {
								Turned = true;
								if (WheelchairMovementScript.MovedFowards == true) {
										ChangeSecondMenuSelection (Plus);
								} else {
										CurrentSelection--;
										ChangeMenuSelection ();
								}
						}
						if (WheelchairMovementScript.CurrentAngle > 45 && WheelchairMovementScript.CurrentAngle < 180) {
								Turned = true;
								if (WheelchairMovementScript.MovedFowards == true) {
										ChangeSecondMenuSelection (Minus);
								} else {
										CurrentSelection++;
										ChangeMenuSelection ();
								}
						}
				} else if (Turned == true) {
						if (WheelchairMovementScript.CurrentAngle > 340 || WheelchairMovementScript.CurrentAngle < 20) {
								Turned = false;
						}
				}

				//moving backwards and fowards
				if (reset == false) {
						if (WheelchairMovementScript.MovedFowards == true) {
								if (CurrentSelection == 3) {
										CreateName ();
								}
								reset = true;
						}					
				} else {

						if (WheelchairMovementScript.MovedFowards == false) {
								reset = false;
						}
				}

				//Updats the text on the GUI
				A.GetComponent<Text> ().text = AlphabetArray [Acounter];
				B.GetComponent<Text> ().text = AlphabetArray [Bcounter];
				C.GetComponent<Text> ().text = AlphabetArray [Ccounter];

				OnGUI (); // used for testing can be removed later on
		}

		void OnGUI ()
		{
				GUI.Label (new Rect (10, 30, 200, 20), "CurrentSelection: " + CurrentSelection);  //  Display the CurrentSelection on a label in the top left
				GUI.Label (new Rect (10, 50, 200, 20), "Player Turned: " + Turned);  //  Display the turned bool on a label in the top left
				GUI.Label (new Rect (10, 90, 200, 20), "A: " + Acounter + " B: " + Bcounter + " C: " + Ccounter);  //  Display the turned bool on a label in the top left
		}

		void ChangeMenuSelection ()
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
						UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (MainMenu_Button);
						break;
				}
		}

		public void ChangeSecondMenuSelection (int math)
		{
				switch (CurrentSelection) {
				case 0://ACounter
						Acounter = Acounter + math;
						break;
				case 1://BCounter
						Bcounter = Bcounter + math;
						break;
				case 2://CCounter
						Ccounter = Ccounter + math;
						break;

				}
				//cycle round the Counters

				//A Counter
				if (Acounter < 0) {
						Acounter = 26;
				}
				if (Acounter > 26) {
						Acounter = 0;
				}
	
				//B Counter
				if (Bcounter < 0) {
						Bcounter = 26;
				}
				if (Bcounter > 26) {
						Bcounter = 0;
				}

				//C Counter
				if (Ccounter < 0) {
						Ccounter = 26;
				}
				if (Ccounter > 26) {
						Ccounter = 0;
				}
		}

		void CreateName ()
		{
				Name = AlphabetArray [Acounter] + AlphabetArray [Bcounter] + AlphabetArray [Ccounter];

				//load in the CSV file for the leaderboard
				ReadFile.Load ("Assets/Data Files/TestLeaderboard.txt");
	
				int score = 500;// will be changed ot the attual score
				int TimeRank = 0;// used when looping to find the players rank

				for (int x = 0; x < ReadFile.CompletionTimeData.Count; x++) {
						if (ReadFile.CompletionTimeData [x].Data > score) {
								TimeRank = x;
						}
				}
				ReadFile.CompletionTimeData.Insert (TimeRank, new ReadFile.LeaderboardData (Name, score));


				int EnemiesRank = 0;// used when looping to find the players rank
				for (int x = 0; x < ReadFile.EnemiesKilledData.Count; x++) {
						if (ReadFile.EnemiesKilledData [x].Data > score) {
								EnemiesRank = x;					
						}
				}
				ReadFile.EnemiesKilledData.Insert (EnemiesRank, new ReadFile.LeaderboardData (Name, score));
			
				int DamageRank = 0;// used when looping to find the players rank
				for (int x = 0; x < ReadFile.LeastDamageData.Count; x++) {
						if (ReadFile.LeastDamageData [x].Data > score) {
								DamageRank = x;					
						}
				}
				ReadFile.LeastDamageData.Insert (DamageRank, new ReadFile.LeaderboardData (Name, score));
				SaveFile.SaveCSV ("Assets/Data Files/Leaderboard.txt");// added purely to test the save file
		MenuGameMenuStateScript.MenuStateChange (4);// change to leaderboard
	}
}
