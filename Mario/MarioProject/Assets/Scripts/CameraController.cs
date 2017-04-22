using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 offset;

	public static float minX;
	public static float width;
	public Transform player;

	void Start () {
		offset = transform.position - player.transform.position;

		width = GetComponent<Camera> ().pixelWidth;
	}

	void LateUpdate () {
		minX = transform.position.x;
	//	transform.position = offset + player.transform.position;

		Vector3 playerPos = Camera.main.WorldToScreenPoint(player.position);

		if (playerPos.y > Screen.height/2) {
			//start tracking him

			float yDif = playerPos.y - Screen.height/2;
			transform.position = Vector3.Lerp(
				transform.position,new Vector3 (transform.position.x, 
					transform.position.y + yDif,
					transform.position.z), Time.deltaTime);
		} else if (playerPos.y < Screen.height/4) {
			//start tracking him

			float yDif = Screen.height/4 - playerPos.y;
			transform.position = Vector3.Lerp(
				transform.position,new Vector3 (transform.position.x, 
					transform.position.y - yDif,
					transform.position.z), Time.deltaTime);
		}

		//if (transform.position.x < minX)
		//	transform.position = new Vector3 (minX, transform.position.y, transform.position.z);
	}
}
