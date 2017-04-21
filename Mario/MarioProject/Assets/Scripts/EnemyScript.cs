using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float xstart = 1;
	public float xdest = 2;
	bool right = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (right) {
			Vector3 newPos = new Vector3 (xdest, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);
			if (transform.position == newPos)
				right = false;
		} else {
			Vector3 newPos = new Vector3 (xstart, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);
			if (transform.position == newPos)
				right = true;
		}
	}
}
