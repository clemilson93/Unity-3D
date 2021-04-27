using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy00LaserScript : MonoBehaviour {

	public float speed;
	public Enemy00Script enemy00Script;
	public float range;
	Vector2 startPoint;

	// Use this for initialization
	void Start ()
	{
		speed = -2;
		range = 5;
		startPoint = transform.position;
	}

	// Update is called once per frame
	void Update ()
	{
		if(Vector2.Distance(startPoint, transform.position) >= range)
		{
			enemy00Script.enemyReload (gameObject);
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
			enemy00Script.enemyReload (gameObject);
		}
		if (go.gameObject.tag == "Laser")
		{
			enemy00Script.enemyReload (gameObject);
		}
	}



}
