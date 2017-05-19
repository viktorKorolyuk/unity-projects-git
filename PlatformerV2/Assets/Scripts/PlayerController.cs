using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jump;
	public Transform topRight;
	public Transform bottomLeft;
	public Transform rightWallMargin;
	public Transform leftWallMargin;
	public LayerMask ground, wall, water;
	public Text scoreText;

	Rigidbody2D rb;
	Animator ac;
	SpriteRenderer rc;
	float score = 0;
	bool dead = false;
	bool swimming = false;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		ac = GetComponent<Animator> ();
		rc = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (dead)
			return;

		float h = Input.GetAxis ("Horizontal");
		bool allowMovement = false;
		bool isWalled = Physics2D.OverlapArea (rightWallMargin.position, leftWallMargin.position, wall); //is it hitting somthing on its "sides"
		bool isGrounded = Physics2D.OverlapArea (topRight.position, bottomLeft.position, ground | wall); //is it directly below them (aka walkable object)
		bool isSwimming = Physics2D.OverlapArea(rightWallMargin.position, leftWallMargin.position, water);

		if (!isWalled || (isGrounded && isWalled)) allowMovement = true;
		if (isWalled || isGrounded) ac.SetBool ("Jumping", false);
		if (isSwimming)
			ac.SetBool ("swimming", true);
		print (isSwimming);
		if((isGrounded))
			ac.SetBool ("swimming", false);
		if (allowMovement) { //thus it should move
			ac.SetFloat ("Speed", Mathf.Abs (h)); //set the animation speed to correct value
			if (h != 0) {
				if (h < 0)
					rc.flipX = true;
				else
					rc.flipX = false;
			}
			rb.velocity = new Vector2 (h * speed, rb.velocity.y);
		}
		if (Input.GetKey (KeyCode.Space)) {
			if (isGrounded) {
				//Jump
				ac.SetBool ("Jumping", true);
				rb.velocity = new Vector2 (rb.velocity.x, jump);
			} else if (isSwimming) {
				ac.SetBool ("Jumping", true);
				rb.velocity = new Vector2 (rb.velocity.x, jump / 2);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		switch (other.gameObject.tag) {
		case "Enemy":
			BoxCollider2D enemyCollider = other.gameObject.GetComponent<BoxCollider2D> ();

			float enemyTop = other.transform.position.y + (enemyCollider.size.y / 2) + enemyCollider.offset.y;

			if (transform.position.y > enemyTop) {
				other.gameObject.GetComponent<EnemyController> ().Die ();

				rb.velocity = new Vector2 (rb.velocity.x, jump * 0.5f);
			} else {
				Die ();
			}
			break;
		case "giftbox":
			BoxCollider2D blocky = other.gameObject.GetComponent<BoxCollider2D> ();
			float blockY = other.transform.position.y - (blocky.size.y / 2) - 2;
			float blockYtop = other.transform.position.y + (blocky.size.y / 2);
			float blockMinX = other.transform.position.x - (blocky.size.x / 2);
			float blockMaxX = other.transform.position.x + (blocky.size.x / 2);
			if (blockY <= transform.position.y && transform.position.y <= blockYtop && blockMinX <= transform.position.x && transform.position.x <= blockMaxX) {
				score++;
				scoreText.text = "x " + score.ToString ("00");
				other.gameObject.GetComponent<QuestionBlockController> ().anim ();
			}
			break;
		case "flagpole":
			StartCoroutine (NextLevel ());
			break;
		}
	}

	public void Die ()
	{
		StartCoroutine (DelayedDeath ());
	}

	IEnumerator DelayedDeath ()
	{
		rb.velocity = Vector2.zero;
		dead = true;
		ac.SetBool ("Jumping", false);
		ac.SetFloat ("Speed", 0);

		yield return new WaitForSeconds (0.1f);

		GetComponent<BoxCollider2D> ().enabled = false;
		rb.AddForce (Vector2.up * 1000);

		StartCoroutine (RestartLevel ());
	}

	IEnumerator RestartLevel ()
	{
		yield return new WaitForSeconds (1.9f);

		// go back to menu or restart level;
		Application.LoadLevel (Application.loadedLevel);

	}

	IEnumerator NextLevel ()
	{
		yield return new WaitForSeconds (1.9f);
		SceneManager.LoadScene (Application.loadedLevel + 1);
	}
}
