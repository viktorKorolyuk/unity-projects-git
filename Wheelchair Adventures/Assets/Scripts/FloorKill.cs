using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorKill : MonoBehaviour {
	void Start(){
		Debug.LogError ("[ERROR] I don't make mistakes");
	}
	void OnTriggerEnter(Collider obj){
		Destroy (obj.gameObject);
	}
}
