using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public static float minX;
	public static float width;
	public Transform player;

	float offset;

	void Start () {
		offset = transform.position.x - player.position.x;

		width = GetComponent<Camera> ().pixelWidth;
	}

	void LateUpdate () {
		minX = transform.position.x;

		Vector3 playerPos = Camera.main.WorldToScreenPoint(player.position);

		float yDif = 0;
		if (playerPos.y > Screen.height/2) {
			//start tracking him
			yDif = playerPos.y - Screen.height/2;
		} else if (playerPos.y < Screen.height/4) {
			//start tracking him
			yDif = playerPos.y - Screen.height/4;
		}
		transform.position = new Vector3 (offset + player.position.x, Mathf.Lerp (transform.position.y, transform.position.y + yDif, Time.deltaTime), transform.position.z);

	}
}