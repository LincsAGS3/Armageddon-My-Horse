#pragma strict

function Start () {

}

function Update () {
if (Input.GetKey("p"))
{
	Time.timeScale = 0;
	var script3 = GetComponent(PauseMenuScript);
	script3.enabled = true;
}

}