using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaylightCycle : MonoBehaviour {
	public int timeChange = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(timeChange,0,0);
		if (transform.rotation.x >= 180) {
			
		}
	}
}
