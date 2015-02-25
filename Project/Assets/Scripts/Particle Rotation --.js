#pragma strict

public var angle : Vector3;
public var speed : int;
var randomX : double;
var randomZ : double;


function Start () {
randomX = Random.value;
randomZ = Random.value;

angle.x = -randomX;
angle.z = -randomZ;
speed = Random.Range(30, 100);

}

function Update () {

transform.RotateAround (Vector3(0, 0, -10), angle, speed * Time.deltaTime);

}