#pragma strict
var newSkin : GUISkin;
var logoTexture : Texture2D;

function Awake()
{
	var script3 = GetComponent(PauseMenuScript); 
    script3.enabled = false;
}

function Start () {

}

function Update () {

}

function thePauseMenu ()
{
	GUI.BeginGroup(Rect(Screen.width / 2 - 150, 50, 300, 250));
	GUI.Box(Rect(0, 0, 300, 250), "");
	GUI.Label(Rect(15, 10, 300, 68), logoTexture);
	
	if(GUI.Button(Rect(55, 100, 180, 40), "Resume")) 
	{
    Time.timeScale = 1.0;
    var script3 = GetComponent(PauseMenuScript); 
    script3.enabled = false;
    }
    
    if(GUI.Button(Rect(55, 150, 180, 40), "Main Menu")) {
    Application.LoadLevel(0);
    }
    
    GUI.EndGroup();
}

function OnGUI ()
{
	GUI.skin = newSkin;
	thePauseMenu();
}