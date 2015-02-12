using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;//added

public class SaveFile : MonoBehaviour
{	
		public static void SaveCSV (string fileName)
		{
				
				using (StreamWriter file = new StreamWriter(fileName)) {

						int counter = 0;
						foreach (ReadFile.LeaderboardData data in ReadFile.CompletionTimeData) {
								file.WriteLine ("Time," + data.Name + "," + data.Data);
								if (++counter == 10)
										break;
						}

						counter = 0;

			foreach (ReadFile.LeaderboardData data in ReadFile.EnemiesKilledData) {
				file.WriteLine ("Killed," + data.Name + "," + data.Data);
								if (++counter == 10)
										break;
						}
						
						counter = 0;

			foreach (ReadFile.LeaderboardData data in ReadFile.LeastDamageData) {
				file.WriteLine ("Damage," + data.Name + "," + data.Data);
								if (++counter == 10)
										break;
						}
			Debug.Log ("saved File");
				}
		}
}
