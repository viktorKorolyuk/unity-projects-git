using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject ground;
	public GameObject enemyPrefab;
	public float number;
	float grWidth, grLength;
	// Use this for initialization
	void Start () {
		grWidth = ground.transform.lossyScale.x;
		grLength = ground.transform.lossyScale.y;
		Debug.Log (grWidth);
		Debug.Log (grLength);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (number == 0)
			return;
		float x, y;

		Random.InitState(System.DateTime.Now.Millisecond);
		x = Random.Range (-grWidth / 2, grWidth / 2);

		//Random.InitState(System.DateTime.Now.Millisecond);
		y = Random.Range (-grLength / 2, grLength / 2);
		Vector3 pos = new Vector3 (x, 1.0f, y);
		GameObject ob = Instantiate(enemyPrefab, pos, Quaternion.identity);
		ob.transform.Rotate (new Vector3 (-90f, ob.transform.rotation.y, ob.transform.rotation.z));
		number--;
	}
}
