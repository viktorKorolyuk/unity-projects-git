using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {

	public float speed = 0.1f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (speed, 0.0f, 0.0f);
	}
}
