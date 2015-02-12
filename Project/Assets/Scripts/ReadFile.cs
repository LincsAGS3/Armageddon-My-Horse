using UnityEngine;
using System.Collections;
using System.Text;

//added
using System.IO;  //added
using System.Collections.Generic;//added
public class ReadFile : MonoBehaviour
{
		//Old code used when using arrays
		//public static string[,] LeaderboardCompletionTimeArray = new string[11, 2]; // these are size 11 because the extra one is going to be used for when the player finishes a game
		//public static string[,] LeaderboardEnemiesKilledArray = new string[11, 2]; //only the first 10 rows are used within the read file
		//public static string[,] LeaderboardLeastDamageArray = new string[11, 2]; // the 11th row will be culled one the file is resaved


		public class LeaderboardCompletionTimeData
		{
				public string PlayerName { get; set; }

				public string CompletionTime { get; set; }
		}

		public class LeaderboardEnemiesKilledData
		{
				public string PlayerName { get; set; }

				public string EnemiesKilled { get; set; }
		}

		public class LeaderboardLeastDamageData
		{
				public string PlayerName { get; set; }

				public string LeastDamage { get; set; }
		}

		public static List<LeaderboardCompletionTimeData> CTD = new List<LeaderboardCompletionTimeData> ();
		public static List<LeaderboardEnemiesKilledData> EKD = new List<LeaderboardEnemiesKilledData> ();
		public static List<LeaderboardLeastDamageData> LDD = new List<LeaderboardLeastDamageData> ();
		int counter = 1;
		// Use this for initialization
		void Start ()
		{

				Load ("Assets/Data Files/TestLeaderboard.txt");

				//this is just for testing, to paste the LeaderboardCompletionTimeArray to console to check it has read the file
				do {
						Debug.Log (CTD [counter].PlayerName + " | " + CTD [counter].CompletionTime);

						//Old code used when using arrays
						//Debug.Log (LeaderboardCompletionTimeArray [counter, 0] + " | " + LeaderboardCompletionTimeArray [counter, 1]); 

						counter++;
				} while (counter <10);


		}

		public static void Load (string FileName)
		{
		
				try {
						string CurrentLine;
						StreamReader FileReader = new StreamReader (FileName, Encoding.Default);
						int TimeNumber = 0;
						int EnemiesNumber = 0;
						int DamageNumber = 0;

						using (FileReader) {
								do {
										CurrentLine = FileReader.ReadLine ();
										if (CurrentLine != null) {
												string[] SplitLine = CurrentLine.Split (',');
												if (SplitLine [0] == "Time") {

														CTD.Add (new LeaderboardCompletionTimeData{PlayerName = SplitLine[1], CompletionTime = SplitLine[2]});
													
														//Old code used when using arrays
														//LeaderboardCompletionTimeArray [TimeNumber, 0] = SplitLine [1];
														//LeaderboardCompletionTimeArray [TimeNumber, 1] = SplitLine [2];
														TimeNumber++;
												}

												if (SplitLine [0] == "Killed") {
														EKD.Add (new LeaderboardEnemiesKilledData{PlayerName = SplitLine[1], EnemiesKilled = SplitLine[2]});

														//Old code used when using arrays
														//LeaderboardEnemiesKilledArray [EnemiesNumber, 0] = SplitLine [1];
														//LeaderboardEnemiesKilledArray [EnemiesNumber, 1] = SplitLine [2];
														EnemiesNumber++;
												}

												if (SplitLine [0] == "Damage") {
														LDD.Add (new LeaderboardLeastDamageData{PlayerName = SplitLine[1], LeastDamage = SplitLine[2]});

														//Old code used when using arrays
														//LeaderboardLeastDamageArray [DamageNumber, 0] = SplitLine [1];
														//LeaderboardLeastDamageArray [DamageNumber, 1] = SplitLine [2];
														DamageNumber++;
												}
										}
								} while (CurrentLine != null);
								FileReader.Close (); // close the StreamReader
						}
				} catch (FileNotFoundException) {
				}

				SaveFile.SaveCSV ("Assets/Data Files/TestLeaderboard2.txt");// added purely to test the save file
		}

}
