using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCenter : MonoBehaviour {
	//Vector3 oldPos;
	public GameObject player;
//	private Rigidbody rb;
	void Start(){
		//oldPos = transform.position;
		//rb = player.GetComponent<Rigidbody> ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		//if (transform.position - oldPos >= ) {
		//Vector3 velocity = rb.velocity;
			transform.Rotate (new Vector3 (100f, 100f, 100f) * Time.deltaTime);
		//}
	
	}
}
