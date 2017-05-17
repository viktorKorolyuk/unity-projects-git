using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.position;
	}

	void LateUpdate () {
		transform.position = player.position + offset;
	}
}
