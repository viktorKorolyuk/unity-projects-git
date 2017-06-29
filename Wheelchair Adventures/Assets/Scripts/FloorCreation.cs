using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreation : MonoBehaviour {
	public GameObject parent;
	GameObject floor;
	GameObject player;
	// Use this for initialization
	void Start () {
		floor = GameObject.FindGameObjectWithTag ("Floor");
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.transform.position.z + 10 >= (floor.transform.position.z + floor.transform.lossyScale.y / 2)) {
			floor = Instantiate (floor,
				new Vector3 (floor.transform.position.x, floor.transform.position.y, floor.transform.position.z + floor.transform.lossyScale.y),
				floor.transform.rotation, parent.transform);
		}

	}
}
