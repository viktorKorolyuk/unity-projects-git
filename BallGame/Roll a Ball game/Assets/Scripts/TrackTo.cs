using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTo : MonoBehaviour {
	public GameObject target;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = target.transform.position - offset;	
	}
}
