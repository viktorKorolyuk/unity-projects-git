using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockController : MonoBehaviour {

	public GameObject gift;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void anim(){
		GameObject current = Instantiate (gift, transform);

		current.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 300);
		//rise 5 pixels then disapear
	}
}
