using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;//added

public class SaveFile : MonoBehaviour
{	
		public static void SaveCSV (string fileName)
		{				
				using (StreamWriter file = new StreamWriter(fileName)) {
						int counter = 0;//creates the counter varable
						foreach (ReadFile.LeaderboardData data in ReadFile.CompletionTimeData) { 
								file.WriteLine ("Time," + data.Name + "," + data.Data); // writes the contents of CompletionTimeData, Name and Data to the current line in the file
								if (++counter == 10)// to ensure only the top 10 are put in the CSV file
										break;
						}
						counter = 0;//resets the counter to 0
						foreach (ReadFile.LeaderboardData data in ReadFile.EnemiesKilledData) {
								file.WriteLine ("Killed," + data.Name + "," + data.Data);// writes the contents of EnemiesKilledData, Name and Data to the current line in the file
								if (++counter == 10)// to ensure only the top 10 are put in the CSV file
										break;
						}
						counter = 0;//resets the counter to 0
						foreach (ReadFile.LeaderboardData data in ReadFile.LeastDamageData) {
								file.WriteLine ("Damage," + data.Name + "," + data.Data);// writes the contents of LeastDamageData, Name and Data to the current line in the file
								if (++counter == 10) // to ensure only the top 10 are put in the CSV file
										break;
						}
				}
		}
}
