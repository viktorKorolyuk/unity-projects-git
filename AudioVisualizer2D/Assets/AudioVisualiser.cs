using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualiser : MonoBehaviour {

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];

		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		Debug.Log (Mathf.Log(spectrum [0]));
		for (int i = 0; i < spectrum.Length-1; i++) {
			Debug.DrawLine(new Vector3(i - 10, spectrum[i], 0), new Vector3(i-9, spectrum[i + 1] + 10, 0), Color.red);
			if (i + 1 != spectrum.Length)
				spectrum [i + 1] += 10;
		}
	}
}
