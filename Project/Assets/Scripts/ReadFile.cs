using UnityEngine;
using System.Collections;
using System.Text;//added
using System.IO;  //added
using System.Collections.Generic;//added
public class ReadFile : MonoBehaviour
{
		//struct which is used to hold the leaderboard data
		public	struct LeaderboardData
		{
				public string Name;
				public float Data;

				public LeaderboardData (string name, float data)
				{
						Name = name;
						Data = data;
				}
		}
		
		//lists created using the struct above
		public static List<LeaderboardData> CompletionTimeData = new List<LeaderboardData> ();
		public static List<LeaderboardData> EnemiesKilledData = new List<LeaderboardData> ();
		public static List<LeaderboardData> LeastDamageData = new List<LeaderboardData> ();

		public static void Load (string FileName)
		{	
				try {
						StreamReader FileReader = new StreamReader (FileName, Encoding.Default); // used to read the file in
						string CurrentLine;//string used to hold the current line of the file
						//varables used for a counter
						int TimeNumber = 0;
						int EnemiesNumber = 0;
						int DamageNumber = 0;

						using (FileReader) {
								do {
										CurrentLine = FileReader.ReadLine (); // puts the current line of the file into the currentline string
										if (CurrentLine != null) {
												string[] SplitLine = CurrentLine.Split (','); // splits the currentline up and places the contents in an array
												if (SplitLine [0] == "Time") {// checks if the current line in the CSV has the label "Time"
														CompletionTimeData.Add (new LeaderboardData (SplitLine [1], float.Parse (SplitLine [2]))); // adds the data to the completionTimeData list
														TimeNumber++;
												}

												if (SplitLine [0] == "Killed") {// checks if the current line in the CSV has the label "Killed"
														EnemiesKilledData.Add (new LeaderboardData (SplitLine [1], float.Parse (SplitLine [2])));// adds the data to the EnemiesKilledData list
														EnemiesNumber++;
												}

												if (SplitLine [0] == "Damage") {// checks if the current line in the CSV has the label "Damage"
														LeastDamageData.Add (new LeaderboardData (SplitLine [1], float.Parse (SplitLine [2])));// adds the data to the LeastDamageData list
														DamageNumber++;
												}
										}
								} while (CurrentLine != null); // makes sure its not the end of the file
								FileReader.Close (); // close the StreamReader
						}
				} catch (FileNotFoundException) {
				}
		}
}
