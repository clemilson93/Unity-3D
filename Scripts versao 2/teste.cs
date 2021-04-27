using UnityEngine;
using System.Collections;

public class teste : MonoBehaviour {

	float tempo = 0;
	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		tempo = tempo + Time.deltaTime;
		Debug.Log (Time.deltaTime);
		Debug.Log (tempo);
	}
}
