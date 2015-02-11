using UnityEngine;
using System.Collections;
using System.Text;//added
using System.IO;  //added

public class ReadFile : MonoBehaviour {

	public string [,] LeaderboardCompletionTimeArray = new string[10,2];
	public string [,] LeaderboardEnemiesKilledArray = new string[10,2];
	public string [,] LeaderboardLeastDamageArray = new string[10, 2];

	//public TextAsset FileAsset;

	int counter = 0;
	// Use this for initialization
	void Start () {
		Load ("Assets/Data Files/TestLeaderboard.txt");

		//this is just for testing, to paste the LeaderboardCompletionTimeArray to console to check it has read the file
		do {
			Debug.Log(LeaderboardCompletionTimeArray[counter,0] + " | " + LeaderboardCompletionTimeArray[counter,1]);
			counter++;
		} while (counter <10);
	}

		void Load(string FileName)
	{
		try
		{
			string CurrentLine;
			StreamReader FileReader = new StreamReader(FileName, Encoding.Default);
			int TimeNumber = 0;
			int EnemiesNumber = 0;
			int DamageNumber = 0;

			using(FileReader)
			{
				do
				{
					CurrentLine = FileReader.ReadLine();
					if (CurrentLine != null)
					{
						string[] SplitLine = CurrentLine.Split(',');
						if(SplitLine[0] == "Time")
						{
							LeaderboardCompletionTimeArray[TimeNumber,0] = SplitLine[1];
							LeaderboardCompletionTimeArray[TimeNumber,1] = SplitLine[2];
							TimeNumber++;
						}

						if(SplitLine[0] == "#Killed")
						{

							LeaderboardEnemiesKilledArray[EnemiesNumber,0] = SplitLine[1];
							LeaderboardEnemiesKilledArray[EnemiesNumber,1] = SplitLine[2];
							EnemiesNumber++;
						}

						if(SplitLine[0] == "Damage")
						{
							LeaderboardLeastDamageArray[DamageNumber,0] = SplitLine[1];
							LeaderboardLeastDamageArray[DamageNumber,1] = SplitLine[1];
							DamageNumber++;
						}
					}
				}
				while (CurrentLine != null);
				FileReader.Close(); // close the StreamReader
			}
		}
		catch(FileNotFoundException){
				}
	}

}
