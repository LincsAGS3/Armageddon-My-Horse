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

	static GameObject MainCamera;
	static Camera camera; 
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

		MainCamera = GameObject.Find ("Main Camera");
	
			camera = 	MainCamera.GetComponent<Camera>();
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
				AspectRatioChange(4/3);
				break;
			case 1://16:9
				AspectRatioChange(16/9);
				break;
			case 2://16:10
				AspectRatioChange(16/10);
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
			MenuStateScript.MenuStateChange(0); // return to menu
			break;
		}		
	}
	public static void AspectRatioChange(float TargetAspect) 
	{
		float CurrentWindowAspect = (float)Screen.width / (float)Screen.height; //gets the games window's current aspect ratio
		float ScaleHeight  =  CurrentWindowAspect / TargetAspect;// The current viewport height should be scaled to this value
		if (ScaleHeight  < 1.0f)// if scaled height is less than current height, add black box around the sides
		{  
			Rect Rectangle = camera.rect;
			
			Rectangle.width = 1.0f;
			Rectangle.height = ScaleHeight ;
			Rectangle.x = 0;
			Rectangle.y = (1.0f - ScaleHeight ) / 2.0f;
			
			camera.rect = Rectangle;
		}
		else // add BlackBox
		{
			float ScaleWidth = 1.0f / ScaleHeight ;
			
			Rect Rectangle = camera.rect;
			
			Rectangle.width = ScaleWidth;
			Rectangle.height = 1.0f;
			Rectangle.x = (1.0f - ScaleWidth) / 2.0f;
			Rectangle.y = 0;
			
			camera.rect = Rectangle;
		}
	}

}
