using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class LeaderboardScript : MonoBehaviour {

	static GameObject CompTimeColum1;
	static GameObject CompTimeColum2;
	static GameObject CompTimeColum3;
	string CompTimeColum1Text;
	string CompTimeColum2Text;
	string CompTimeColum3Text;

	static GameObject EnemieskilledColum1;
	static GameObject EnemieskilledColum2;
	static GameObject EnemieskilledColum3;
	string EnemieskilledColum1Text;
	string EnemieskilledColum2Text;
	string EnemieskilledColum3Text;

	static GameObject LeastDamageColum1;
	static GameObject LeastDamageColum2;
	static GameObject LeastDamageColum3;
	string LeastDamageColum1Text;
	string LeastDamageColum2Text;
	string LeastDamageColum3Text;

	string Spaces;

	// Use this for initialization
	void Start ()
	{
		Spaces = "          ";
		CompTimeColum1 = GameObject.Find ("CompTimeRow1");
		CompTimeColum2 = GameObject.Find ("CompTimeRow2");
		CompTimeColum3 = GameObject.Find ("CompTimeRow3");

		EnemieskilledColum1 = GameObject.Find ("EnemiesKilledRow1");
		EnemieskilledColum2 = GameObject.Find ("EnemiesKilledRow2");
		EnemieskilledColum3 = GameObject.Find ("EnemiesKilledRow3");

		LeastDamageColum1 = GameObject.Find ("LeastDamageRow1");
		LeastDamageColum2 = GameObject.Find ("LeastDamageRow2");
		LeastDamageColum3 = GameObject.Find ("LeastDamageRow3");
		ReadFile.Load ("Assets/Data Files/Leaderboard.txt");

		CompletionTime ();
		EnemiesKilled ();
		LeastDamage ();
				
		}
		// Update is called once per frame
		void Update () 
	{
		CompTimeColum1.GetComponent<Text>().text = CompTimeColum1Text;
		CompTimeColum2.GetComponent<Text>().text = CompTimeColum2Text;
		CompTimeColum3.GetComponent<Text>().text = CompTimeColum3Text;

		EnemieskilledColum1.GetComponent<Text> ().text = EnemieskilledColum1Text;
		EnemieskilledColum2.GetComponent<Text> ().text = EnemieskilledColum2Text;
		EnemieskilledColum3.GetComponent<Text> ().text = EnemieskilledColum3Text;

		LeastDamageColum1.GetComponent<Text> ().text = LeastDamageColum1Text;
		LeastDamageColum2.GetComponent<Text> ().text = LeastDamageColum2Text;
		LeastDamageColum3.GetComponent<Text> ().text = LeastDamageColum3Text;
		}

	void CompletionTime ()
	{
		int counter = 1;
		foreach (ReadFile.LeaderboardData data in ReadFile.CompletionTimeData) 
		{ 
			CompTimeColum1Text += counter + "\n";
			CompTimeColum2Text += data.Name + "\n";
			CompTimeColum3Text += data.Data + "\n";
			if (++counter == 11)
				break;
		}
	}

	void EnemiesKilled ()
	{
		int counter = 1;
		foreach (ReadFile.LeaderboardData data in ReadFile.EnemiesKilledData) { 
			EnemieskilledColum1Text += counter + "\n";
			EnemieskilledColum2Text += data.Name + "\n";
			EnemieskilledColum3Text += data.Data + "\n";
			if (++counter == 11)
				break;
		}
	}

	void LeastDamage ()
	{
		int counter = 1;
		foreach (ReadFile.LeaderboardData data in ReadFile.LeastDamageData) { 
			LeastDamageColum1Text += counter + "\n";
			LeastDamageColum2Text += data.Name + "\n";
			LeastDamageColum3Text += data.Data + "\n";
			if (++counter == 11)
				break;
		}
	}

}
