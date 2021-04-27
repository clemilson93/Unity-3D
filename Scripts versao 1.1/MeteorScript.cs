using UnityEngine;
using System.Collections;

public class MeteorScript : MonoBehaviour {

	Vector2 defaultPosition;
	float speed = -2f;
	public PlayerScript player;
	public GameObject explosion;
	public int resistence = 3;

	void Awake ()
	{
		defaultPosition = transform.position;
	}

	void Update ()
	{
		if(resistence <= 0)
		{
			resetMeteor ();
		}

		float distance = (transform.position - Camera.main.transform.position).z;
		Vector3 cameraBounds0 = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, distance));
		Vector3 cameraBounds1 = Camera.main.ViewportToWorldPoint (new Vector3 (1F, 1F, distance));

		transform.Translate (0, speed * Time.deltaTime, 0);

		if(transform.position.y <= cameraBounds0.y)
		{
			transform.position = defaultPosition;
		}
	}

	void resetMeteor()
	{
		GameObject explo =  Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy (explo, 1.9f);
		resistence = 3;
		transform.position = defaultPosition;
		player.scores += 13;
	}

	void OnTriggerEnter2D(Collider2D gObject)
	{
		if(gObject.gameObject.tag == "Spaceship")
		{
			GameObject explo =  Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
			Destroy (explo, 1.9f);
			transform.position = defaultPosition;
			player.lives -= 1;

		}
		else if(gObject.gameObject.tag == "Bullet")
		{
			resistence -= 1;
		}
	}
}
