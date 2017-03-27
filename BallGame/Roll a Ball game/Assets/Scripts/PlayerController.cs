using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	private Rigidbody rb;
	void Start(){
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = 0;
		bool s = Input.GetKey (KeyCode.Space);
		if (s)
			moveUp = 5;
		Vector3 mv = new Vector3 (moveHorizontal, moveUp, moveVertical);
		rb.AddForce (mv * speed);
	}

}
