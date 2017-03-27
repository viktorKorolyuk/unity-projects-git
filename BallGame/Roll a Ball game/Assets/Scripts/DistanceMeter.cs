using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMeter : MonoBehaviour {
	public TextMesh text;
	public GameObject owner;
	public GameObject target;

	// Use this for initialization
	void Start () {
		text.text = "0m";
	}

	// Update is called once per frame
	void LateUpdate () {
		//x = x, z = y
		//l = sqrt((x2-x1)^2 + (y2-y1)^2)
		float x1 = owner.transform.position.x,
		x2 = target.transform.position.x,
		y1 = owner.transform.position.z,
		y2 = target.transform.position.z;
		Debug.Log("A("+x1+", " + y1+")");
		Debug.Log("B("+x2+", " + y2+")");
		Debug.Log (square(x2-x1));
		float l = Mathf.Sqrt (square(x2 - x1) + square(y2 - y1));
		l = Mathf.Round (l) / 10;
		text.text = l.ToString() + "m";
		if (l <= 0.15)
			Application.LoadLevel("DeathScreen");

	}
	float square(float num){
		return num * num;
	}
}
