using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	int divider = 3;
	float push;
	float location = 0;
	float[] positions = new float[3];

	void Start () {
		push = GameObject.FindGameObjectWithTag ("Floor").transform.lossyScale.y / divider;

		positions [0] = transform.position.x - push; //1
		positions [1] = transform.position.x; //2
		positions [2] = transform.position.x + push; //3
	}

	void FixedUpdate () {
		if (Input.GetAxis("wSides") > 0) {
			location = positions [0];
		} else if (Input.GetAxis("wDown") > 0) {
			location = positions [1];
		} else if (Input.GetAxis("wSides") < 0) {
			location = positions [2];
		}
		transform.position = transform.position + Vector3.forward;
		//print ("transform.position.x: " + transform.position.x + " position: " + location);
		transform.position = new Vector3 (Mathf.Lerp(transform.position.x, location, Time.deltaTime * 5f), transform.position.y, transform.position.z);
	}
}
