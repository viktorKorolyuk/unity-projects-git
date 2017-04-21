using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector3 offset;
	GameObject player;
	public static float maxX;
	public static float width;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;

		width = GetComponent<Camera> ().pixelWidth;
	}
	
	// Update is called once per frame
	void Update () {
		maxX = transform.position.x;
		transform.position = offset + player.transform.position;

		if (transform.position.x < maxX)
			transform.position = new Vector3 (maxX, transform.position.y, transform.position.z);
	}
}
