using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour {
	public GameObject trackTarget;
	// Use this for initialization
	//
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (trackTarget.transform);
		Vector3 relativePos = trackTarget.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(relativePos);
		//transform.rotation = Quaternion.Euler(new Vector3(0,trackTarget.transform.position.x,0));
	}
}
