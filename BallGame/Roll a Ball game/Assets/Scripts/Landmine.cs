using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour {

	public float radius;
	public float explosionPower;

	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		

		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach(Collider s in colliders){
			if (s.gameObject.tag != "Player")
				continue;
			s.gameObject.GetComponent<Rigidbody> ().AddExplosionForce (explosionPower * 100, transform.position, radius);
		}
	}
}
