using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour {
	public float xSpeed = 0.1f;
<<<<<<< HEAD
	public AudioClip wall, paddle;
	AudioSource AuS;
=======
>>>>>>> master
	float speed = 1f;
	int dir = 1;
	float x = 0;

	void Start(){
<<<<<<< HEAD
		AuS = GetComponent<AudioSource> ();
=======
		
>>>>>>> master
	}

	void Update () {
		x = dir * xSpeed * Time.deltaTime;
		transform.position += new Vector3 (x, 0, 0);
		transform.position += new Vector3 (0, speed * x, 0); //y = mx
<<<<<<< HEAD
=======

>>>>>>> master
	}
	void OnCollisionEnter2D(Collision2D obj){
		switch (obj.gameObject.tag) {
		case "MainCamera":
			speed *= -1;
<<<<<<< HEAD
			AuS.clip = wall;
			AuS.Play ();
=======
>>>>>>> master
			break;
		case "Paddle":
			dir *= -1;
			speed *= -1;
<<<<<<< HEAD
			AuS.clip = paddle;
			AuS.Play ();
=======
>>>>>>> master
			break;
		}
	}
}
