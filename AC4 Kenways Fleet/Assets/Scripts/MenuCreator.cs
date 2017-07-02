using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using NUnit.Framework.Internal;
using System;
using System.Diagnostics;
using UnityEngine.UI;

public class MenuCreator : MonoBehaviour {
  public TextAsset str;
  public float distance = 50;
  private float _distance;
  public GameObject menuOBJ;

  GameObject menuStart;
  void Awake(){
    _distance = distance;

    menuStart = transform.Find("Menu Start").gameObject;
    Loop();
  }

  void Update(){
    if (_distance != distance) {
      _distance = distance;
      Loop();
    }
  }

  void Loop() {
    // If no children exist
    if (transform.childCount-1 == 0) {
      
      var x = 1;
      foreach (string name in str.text.Split('\n')) {
        if (name == "") return;
        GameObject obj = Instantiate(menuOBJ, transform);
        obj.name = name;
        obj.transform.GetComponentInChildren<Text>().text = name;

        Vector3 vt3 = obj.transform.position;
        //Setting starting point
        vt3.y = menuStart.transform.position.y;
        vt3.y -= (obj.GetComponent<RectTransform>().sizeDelta.y + distance) * (x-1);
        obj.transform.position = vt3;
        x++;
      }
    }
    // Children exist, modify them
    else {
      var x = 1;
      foreach (Transform child in transform.GetComponentsInChildren<Transform>()) {
        if (child.gameObject == menuStart) return;
        // No need to modify their names.
        // Modify position only
        Vector3 vt3 = menuOBJ.transform.position;
        vt3.y = menuStart.transform.position.y;
        vt3.y -= (child.gameObject.GetComponent<RectTransform>().sizeDelta.y + distance) * (x-1);
        child.position = vt3;
        x++;
      }
    }
  }
}
