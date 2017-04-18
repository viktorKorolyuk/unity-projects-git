using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFollow : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;

	}
	void FixedUpdate(){
		//player.transform.position = new Vector3 (0, 5, 0);
		transform.position = offset + player.transform.position;
	}

}
