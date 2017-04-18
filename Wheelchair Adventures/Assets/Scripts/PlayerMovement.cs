using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	int divider = 3;
	float push;
	int location = 2;

	// Use this for initialization
	void Start () {
		push = GameObject.FindGameObjectWithTag ("Floor").transform.lossyScale.y / divider;
	}
	
	// Update is called once per frame
	void Update () {
		
		Debug.Log (location);
		if (1 <= location && location <= 2) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				transform.position = new Vector3 (transform.position.x - push, transform.position.y, transform.position.z);
				location++;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				transform.position = new Vector3 (transform.position.x + push, transform.position.y, transform.position.z);
				location--;
			}
		}
		//xmov = (xmov > 0) ? -1 : 1;

		//transform.position = new Vector3 (transform.position.x + xmov, transform.position.y, transform.position.z);
	}
}
