using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float speed;
	public bool startRight;

	Rigidbody2D rb;
	Animator anim;

	bool dead = false;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		if (!startRight)
			speed *= -1;
	}

	void FixedUpdate(){
		if (dead)
			return; //if the enemy is dead, don't continue the code, there is nothing left to do but mourn....
		UpdateDirection();
		UpdateMovement();
	}

	void UpdateDirection(){
		if (speed != 0) //if it has a speed change rotation
			transform.localScale = new Vector3(Mathf.Sign(speed), transform.localScale.y, transform.localScale.z);
	}

	void UpdateMovement(){
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Barrier"))
			speed *= -1;
	}

	public void Die(){
		anim.SetTrigger("Death");
		StartCoroutine(DelayedDeath());
	}

	IEnumerator DelayedDeath(){
		dead = true;
		rb.velocity = Vector2.zero;

		yield return new WaitForSeconds(0.1f);

		Destroy(gameObject);
	}
}

