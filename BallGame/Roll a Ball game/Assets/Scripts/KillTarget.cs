using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTarget : MonoBehaviour {
	public GameObject target;
	public Text txtScore;
	public int max;
	int score = 0;
	// Use this for initialization
	void Start () {
		//txtScore.text = score.ToString () + "/"+max.ToString() + " collected";
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag != target.tag)
			return;
		Destroy(other.gameObject);
		score++;
		txtScore.text = score.ToString () + "/"+max.ToString() + " collected";
	}
}
