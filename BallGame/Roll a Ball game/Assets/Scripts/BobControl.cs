using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobControl : MonoBehaviour {
	public float speed = 1;
	private Vector3 pos, org;
	bool up = true;
	int frameCount = 0;
	float orgY;
	// Use this for initialization
	void Start () {
		
		org = transform.position;
		orgY = org.y + 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;

		frameCount++;

		if (pos.y > orgY*1.5) up = false;
		if (pos.y <= orgY) up = true;

		if (up == true) {
			transform.position = new Vector3 (pos.x, pos.y + speed, pos.z);
		} else {
			transform.position = new Vector3 (pos.x, pos.y - speed, pos.z);
		}
	}
}
