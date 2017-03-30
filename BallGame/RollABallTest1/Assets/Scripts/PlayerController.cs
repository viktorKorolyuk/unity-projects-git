using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed;
	public Text score;
	public Text winText;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		Vector3 pos = new Vector3 (x, 0f, y);
		rb.AddForce (pos * speed);
	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
	}
}
