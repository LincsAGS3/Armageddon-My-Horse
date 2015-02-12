using UnityEngine;
using System.Collections;
using UnityEngine.UI;//added

public class MenuOptionsSelectionScript : MonoBehaviour {
	

	string[] AspectRatios = {"4:3","16:9","16:10"};
	string[] Resolutions = {"1024x768","1920x1200"};
	static bool FullScreen;
	string[] Blood = {"Off","Red","Green"};


	static GameObject AspectRatioObject;
	static GameObject ResolutionsObject;	
	static GameObject FullScreenObject;		
	static GameObject BloodObject;	
	
	static int AspectRatioCounter;
	static int ResolutionsCounter;
	static int BloodCounter;

	// Use this for initialization
	void Start () {
		FullScreen = false;
		AspectRatioCounter = 0;
		ResolutionsCounter = 0;
		BloodCounter = 0;

		AspectRatioObject = GameObject.Find("Aspect Ratio");
		ResolutionsObject= GameObject.Find("Resolution");
		FullScreenObject = GameObject.Find("Full Screen");
		BloodObject = GameObject.Find("Blood");

		//defualt settings
		AspectRatioObject.GetComponent<Text>().text = AspectRatios[AspectRatioCounter];
		ResolutionsObject.GetComponent<Text> ().text = Resolutions [ResolutionsCounter];
		FullScreenObject.GetComponent<Text> ().text = FullScreen.ToString();
		BloodObject.GetComponent<Text> ().text = Blood [BloodCounter];
	}
	
	public static void ProcessSelection(int CurrentSelection)
	{
		Debug.Log("Is it entering?????"+ CurrentSelection);
		switch (CurrentSelection) {
		case 0:
			break;
		case 1:

			break;
		case 2:
		
			break;
		case 3:

			break;
		case 4:
			//change aspect ratio resolution full screen and blood here

			//aspect ratio
			switch(AspectRatioCounter)
			{
			case 0://4:3

				break;
			case 1://16:9

				break;
			case 2://16:10

				break;
			}

			//resolution And full screen "Screen.fullScreen = FullScreen;" would be just full screen
			switch(ResolutionsCounter)
			{
			case 0:
				Screen.SetResolution(1024,768,FullScreen);
				break;
			case 1:
				Screen.SetResolution(1920,1200,FullScreen);
				break;
			}

			//Blood
			switch(BloodCounter)
			{
			case 0://Red

				break;
			case 1://Green
				
				break;
			case 2://Off
				
				break;
			}
			Debug.Log("Is it entering?");
			MenuStateScript.MenuStateChange(0); // return to menu
			break;
		}		
	}
}
