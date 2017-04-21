using UnityEngine;
using System.Collections;

public class MarioController : MonoBehaviour
{

	Rigidbody2D rb;
	Animator anim;
	GameObject lastBlock;
	Transform lastBlockPOS;

	int jumpCnt = 0;
	bool keySpaceDown = false;

	public float moveSpeed = 15f;
	public float sliding = 5f;
	public float jumpPower = 50f;
	public float boxincrease = 0.01f;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}

	void FixedUpdate ()
	{
		float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis("Vertical");

		float xv = rb.velocity.x;
		float yv = rb.velocity.y;


		// if moving
		if (h != 0) {
			rb.velocity = new Vector2 (h * moveSpeed, yv);
			transform.localScale = new Vector2 (Mathf.Sign (h), transform.localScale.y);

		}
		// if sliding
		else {
			rb.velocity = new Vector2 (xv * sliding, yv);
		}

		// setting the "Speed" float in the animator
		anim.SetFloat ("Speed", Mathf.Abs (h));

		//do a jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (jumpCnt >= 2 || keySpaceDown)
				return;
			jumpCnt++;
			print (jumpCnt);


			keySpaceDown = true;
			rb.velocity = new Vector2 (xv, jumpPower);
			anim.SetBool ("Jumping", true);
		}
		if (Input.GetKeyUp (KeyCode.Space))
			keySpaceDown = false;

		//Stop jittering after player has stopped walking
		if (Mathf.Abs (xv) <= 0.5f)
			anim.SetFloat ("Speed", 0);
	}
		
	void OnCollisionEnter2D(Collision2D obj){
		anim.SetBool ("Jumping", false);
		jumpCnt = 0;
		print ("reset jumpCnt to 0");
		obj.gameObject.transform.position = new Vector2 (obj.gameObject.transform.position.x, obj.gameObject.transform.position.y + boxincrease);
	}

	void OnCollisionExit2D(Collision2D obj){
		obj.gameObject.transform.position = new Vector2 (obj.gameObject.transform.position.x, obj.gameObject.transform.position.y - boxincrease);
	}


}
