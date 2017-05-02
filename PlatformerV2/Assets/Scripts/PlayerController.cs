using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float jump;
	public Transform topRight;
	public Transform bottomLeft;
	public Transform rightWallMargin;
	public Transform leftWallMargin;
	public LayerMask ground;
	Rigidbody2D rb;
	float lastX = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		bool isWalled = Physics2D.OverlapArea (rightWallMargin.position, leftWallMargin.position, ground); //is it hitting somthing on its "sides"
		bool isGrounded = Physics2D.OverlapArea (topRight.position, bottomLeft.position, ground); //is it directly below them (aka walkable object)

		if (!isWalled) {
			rb.velocity = new Vector2 (h * speed, rb.velocity.y);
		}else if (isGrounded && isWalled) {
			rb.velocity = new Vector2 (h * speed, rb.velocity.y);
		}


		if (isGrounded && Input.GetKey (KeyCode.Space)) {
			rb.velocity = new Vector2 (rb.velocity.x, jump);
		}

	}
}
