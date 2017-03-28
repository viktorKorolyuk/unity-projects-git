using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public GameObject player; //get the target
	public float speed = 1;
	private float y = 0;
	// Use this for initialization
	void Start () {
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.LookAt(player.transform);
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	void LateUpdate(){
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}
}
