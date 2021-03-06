﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	void Awake() {
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move(float h, float v){
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.position + movement); //move player
	}
	void Turning(){
		//get mouse position
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//variable that will define what camRay hit
		RaycastHit floorHit;
		 
		//floorHit is uninitialized, but when the if statement runs 
		//"out floorHit" it gets initialized. This is very useful to get variable return
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f; //the y difference is 0
			Quaternion newRotation = Quaternion.LookRotation (playerToMouse); //look at that position
			playerRigidbody.MoveRotation (newRotation); //rotate to that position
		}
	}
	void Animating(float h, float v){
		bool walking = h  != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}
}

