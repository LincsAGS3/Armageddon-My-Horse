using UnityEngine;
using System.Collections;

public class LanceRotation : MonoBehaviour {

	// Use this for initialization
	float zrot = 0;
	void Start () {
	}
	float rot = 0;
	// Update is called once per frame
	void Update () {
		if (zrot < 40 && zrot > -40) {
			rot = PlayerController.rotAngle;
			zrot += rot;
		} else {
			rot = 0;
		}
		if (zrot > 0) {
			transform.Rotate (0, 0, -0.5f * Player.rotateSpeed * Time.deltaTime);
			zrot -= 0.5f;
		}
		if (zrot < 0) {
			transform.Rotate (0, 0, 0.5f * Player.rotateSpeed * Time.deltaTime);
			zrot +=0.5f;
		}
		if (zrot > 360) {
			zrot -= 360;
		}
		if (zrot < -360) {
			zrot += 360;
		}
		transform.Rotate (0, 0, rot * Player.rotateSpeed * Time.deltaTime);
	}
}
