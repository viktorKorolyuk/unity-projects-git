using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (45f, 45f, 45f) * Time.deltaTime);
	}
}
