using UnityEngine;
using System.Collections;
using System.IO;//added

public class SaveFile : MonoBehaviour
{	
		public static void SaveCSV (string fileName)
		{
				int counter = 0;
				using (StreamWriter file = new StreamWriter(fileName)) {
						//write the 10 times
						do {
								//Old code used when using arrays
								//file.WriteLine ("Time," + ReadFile.LeaderboardCompletionTimeArray [counter, 0] + "," + ReadFile.LeaderboardCompletionTimeArray [counter, 1]);
								file.WriteLine ("Time," + ReadFile.CTD [counter].PlayerName + "," + ReadFile.CTD [counter].CompletionTime);
								counter++;
						} while (counter <10);
						counter = 0;

						//write the 10 killed
						do {
								//Old code used when using arrays
								//file.WriteLine ("Killed," + ReadFile.LeaderboardEnemiesKilledArray [counter, 0] + "," + ReadFile.LeaderboardEnemiesKilledArray [counter, 1]);
								file.WriteLine ("Killed," + ReadFile.EKD [counter].PlayerName + "," + ReadFile.EKD [counter].EnemiesKilled);
								counter++;
						} while (counter <10);
						counter = 0;

						//write the 10 damage
						do {
								//Old code used when using arrays
								//file.WriteLine ("Damage," + ReadFile.LeaderboardLeastDamageArray [counter, 0] + "," + ReadFile.LeaderboardLeastDamageArray [counter, 1]);
								file.WriteLine ("Damage," + ReadFile.LDD [counter].PlayerName + "," + ReadFile.LDD [counter].LeastDamage);
								counter++;
						} while (counter <10);
				}
		}
}
