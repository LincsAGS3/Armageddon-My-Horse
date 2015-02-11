using UnityEngine;
using System.Collections;
using System.IO;  //added
public class SaveFile : MonoBehaviour {	
	public static void SaveCSV(string fileName)
	{
		int counter = 0;
		using (StreamWriter file = new StreamWriter(fileName))
		{
			//write the 10 times
			do {
				file.WriteLine("Time," + ReadFile.LeaderboardCompletionTimeArray[counter,0] + "," + ReadFile.LeaderboardCompletionTimeArray[counter,1]);
				counter++;
			} while (counter <10);
			counter = 0;



			//write the 10 killed
			do {
				file.WriteLine("Killed," + ReadFile.LeaderboardEnemiesKilledArray[counter,0] + "," + ReadFile.LeaderboardEnemiesKilledArray[counter,1]);
				counter++;
			} while (counter <10);
			counter = 0;


			//write the 10 damage
			do {
				file.WriteLine("Damage," + ReadFile.LeaderboardLeastDamageArray[counter,0] + "," + ReadFile.LeaderboardLeastDamageArray[counter,1]);
				counter++;
			} while (counter <10);
		}
	}
}
