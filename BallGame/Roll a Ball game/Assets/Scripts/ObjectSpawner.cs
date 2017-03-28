using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject ground;
	public GameObject enemyPrefab;
	public GameObject parentTarget;
	public float number;
	float grWidth, grLength, x, y;
	// Use this for initialization
	void Start () {
		//setting initial variables for further use
		grWidth = ground.transform.lossyScale.x;
		grLength = ground.transform.lossyScale.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (number == 0) return; //stop running if the desired amount of objects has been spawned

		//randomize value once
		Random.InitState(System.DateTime.Now.Millisecond);
		x = Random.Range (-grWidth / 2, grWidth / 2);

		//randomize value a second time
		Random.InitState(System.DateTime.Now.Millisecond/2);
		y = Random.Range (-grLength / 2, grLength / 2);

		Vector3 pos = new Vector3 (x, 1.0f, y);
		GameObject ob = Instantiate(enemyPrefab, pos, Quaternion.identity); //create the new GameObject and add it to scene
		ob.transform.Rotate (new Vector3 (-90f, ob.transform.rotation.y, ob.transform.rotation.z)); //set proper prefab rotation
		ob.transform.parent = parentTarget.transform; //add the object to a parent

		//diminush the amount of objects left to create

		number--;
	}
}
