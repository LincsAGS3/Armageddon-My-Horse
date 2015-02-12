using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

//added
using System.IO;  //added
using System.Collections.Generic;//added
public class ReadFile : MonoBehaviour
{
	public	struct LeaderboardData
	{
		public string Name;
		public float Data;

		public LeaderboardData(string name, float data)
		{
			Name = name;
			Data = data;
		}
	}


	public static List<LeaderboardData> CompletionTimeData = new List<LeaderboardData> ();
	public static List<LeaderboardData> EnemiesKilledData = new List<LeaderboardData> ();
	public static List<LeaderboardData> LeastDamageData = new List<LeaderboardData> ();
		int counter = 0;
		// Use this for initialization
		void Start ()
		{

				Load ("Assets/Data Files/TestLeaderboard.txt");

				//this is just for testing, to paste the LeaderboardCompletionTimeArray to console to check it has read the file
				do {
						//Debug.Log ("Completion Time Data : Player Name : " + CTD [counter].PlayerName + " | Time Played : " + CTD [counter].CompletionTime);

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

							CompletionTimeData.Add (new LeaderboardData(SplitLine [1], float.Parse(SplitLine [2])));
														TimeNumber++;
												}

												if (SplitLine [0] == "Killed") {
							EnemiesKilledData.Add (new LeaderboardData(SplitLine [1], float.Parse(SplitLine [2])));
														EnemiesNumber++;
												}

												if (SplitLine [0] == "Damage") {
								LeastDamageData.Add (new LeaderboardData(SplitLine [1], float.Parse(SplitLine [2])));
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
