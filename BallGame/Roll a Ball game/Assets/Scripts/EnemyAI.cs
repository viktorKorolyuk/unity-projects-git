using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public GameObject player; //get the target
	public float speed = 1;
	private float x = 0,y = 0;
	// Use this for initialization
	float frameCount = 0;
	void Start () {
		y = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = new Vector3 (transform.position.x + x, transform.position.y, transform.position.z + y);
		//Vector3 relativePos = player.transform.position - transform.position;
		//transform.rotation = Quaternion.LookRotation(relativePos);
		transform.LookAt(player.transform);
		//transform.forward = new Vector3(10f,50f,15f);
		transform.position += transform.forward * Time.deltaTime * speed;

		//transform.LookAt (player.transform);

	}
	void LateUpdate(){
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}
}
