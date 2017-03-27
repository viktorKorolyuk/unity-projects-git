using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOBJ : MonoBehaviour {

	int frameCount = 0;

	// Update is called once per frame
	void FixedUpdate () {
		frameCount++;
		transform.Rotate (new Vector3 (0.0f,0.0f,30.0f) * Time.deltaTime);
	}
}
