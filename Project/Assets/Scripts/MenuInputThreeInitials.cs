using UnityEngine;
using System.Collections;
using System;//added for array.sort
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
				Acounter = 0;
				Bcounter = 0;
				Ccounter = 0;

				A = GameObject.Find ("TextFirstLetter");
				B = GameObject.Find ("TextSecondLetter");
				C = GameObject.Find ("TextThirdLetter");

				Icon = GameObject.Find ("Selection icon Image");
				MainMenu_Button = GameObject.Find ("Main Menu Button");

				IconStartPosition = new Vector3 (Icon.transform.localPosition.x, Icon.transform.localPosition.y, Icon.transform.localPosition.z);

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
								Debug.Log ("Entred");
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

				A.GetComponent<Text> ().text = AlphabetArray [Acounter];
				B.GetComponent<Text> ().text = AlphabetArray [Bcounter];
				C.GetComponent<Text> ().text = AlphabetArray [Ccounter];

				OnGUI ();
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
				Debug.Log (Name);

				//load in the CSV file for the leaderboard
				ReadFile.Load ("Assets/Data Files/TestLeaderboard.txt");

				//Old code used when using arrays
				//ReadFile.LeaderboardCompletionTimeArray [10, 0] = Name;
				//ReadFile.LeaderboardCompletionTimeArray [10, 1] = "0";

				ReadFile.CTD.Add(new ReadFile.LeaderboardCompletionTimeData{PlayerName = Name, CompletionTime = "0"});
				//ReadFile.CTD.Sort ();
				int TimeRank;// used when looping to find the players rank
			

				//Old code used when using arrays
				//ReadFile.LeaderboardEnemiesKilledArray [10, 0] = Name;
				//ReadFile.LeaderboardEnemiesKilledArray [10, 1] = "1000";
				ReadFile.EKD.Add (new ReadFile.LeaderboardEnemiesKilledData{PlayerName = Name, EnemiesKilled = "1000"});
				//ReadFile.EKD.Sort ();
				int EnemiesRank;// used when looping to find the players rank

				//Old code used when using arrays
				//ReadFile.LeaderboardLeastDamageArray [10, 0] = Name;
				//ReadFile.LeaderboardLeastDamageArray [10, 1] = "0";
				ReadFile.LDD.Add (new ReadFile.LeaderboardLeastDamageData{PlayerName = Name, LeastDamage = "1000"});
				//ReadFile.LDD.Sort ();
				int DamageRank;// used when looping to find the players rank
				
				SaveFile.SaveCSV ("Assets/Data Files/TestLeaderboard3.txt");// added purely to test the save file
		}
}
