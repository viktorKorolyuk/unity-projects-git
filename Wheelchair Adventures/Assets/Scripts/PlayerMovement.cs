using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	int divider = 3;
	float push;
	int location = 2;
	float[] positions = new float[3];

	void Start () {
		push = GameObject.FindGameObjectWithTag ("Floor").transform.lossyScale.y / divider;

		positions [0] = transform.position.x - push; //1
		positions [1] = transform.position.x; //2
		positions [2] = transform.position.x + push; //3
	}
	void Update () {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (location == 1) return;
				location--;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (location == 3) return;
				location++;
			}
		Debug.Log (location);
		if(location-1 < positions.Length) {
			transform.position = Vector3.Lerp(new Vector3 (positions[location-1], transform.position.y, transform.position.z + 0.2f), transform.position, Time.deltaTime * 10f);
		}
	}
}
