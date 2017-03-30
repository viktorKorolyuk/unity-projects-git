using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	private Rigidbody rb;
	void Start(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate () {
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y;


		Vector3 mv = new Vector3 (moveHorizontal, 0f, moveVertical);
		rb.AddForce (mv * speed);
	}

}
