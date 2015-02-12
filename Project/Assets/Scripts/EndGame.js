#pragma strict

///Have a different script change this to 1 or 2 when the player wins or dies, respectively
var endGame = 0;

function Start () {

}

function Update () {
////////Testing whether the scene changes work
	if (Input.GetKey("1"))
	{
		endGame = 1;
	}

	if (Input.GetKey("2"))
	{
		endGame = 2;
	}

///Load the victory or game over screens
	if (endGame == 1)
	{
		Application.LoadLevel(2); //Victory
	}

	if (endGame == 2)
	{
		Application.LoadLevel(3); //Game Over
	}

}