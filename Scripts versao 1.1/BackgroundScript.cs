using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	float speed = 0.2f;
	Vector2 scrollingDirection;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		scrollingDirection = new Vector2 (0f, speed * Time.time);
		GetComponent<Renderer> ().material.mainTextureOffset = scrollingDirection;
	}
}
