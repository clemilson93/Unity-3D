using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy01LaserScript : MonoBehaviour {

	public float speed;
	public Enemy01Script enemy01Script;
	public float range;
	Vector2 startPoint;

	// Use this for initialization
	void Start ()
	{
		speed = -1;
		range = 5;
		startPoint = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if(Vector2.Distance(startPoint, transform.position) >= range)
		{
			enemy01Script.enemyReload (gameObject);
		}
		transform.Translate(Time.deltaTime * speed, 0, 0);
	}

	public void spawn(Vector2 position, Quaternion rotation)
	{
		startPoint = position;
		transform.position = position;
		transform.rotation = rotation;

	}

	void OnTriggerEnter2D(Collider2D go)
	{
		if (go.gameObject.tag == "PlayerShip")
		{
			enemy01Script.enemyReload (gameObject);
		}
		if (go.gameObject.tag == "Laser")
		{
			enemy01Script.enemyReload (gameObject);
		}
	}



}
