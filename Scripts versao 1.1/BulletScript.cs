using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float speed = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0, speed * Time.deltaTime, 0);

		float distance = (transform.position - Camera.main.transform.position).z;
		Vector3 cameraBounds0 = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, distance));
		Vector3 cameraBounds1 = Camera.main.ViewportToWorldPoint (new Vector3 (1F, 1F, distance));

		transform.Translate (0, speed * Time.deltaTime, 0);

		if(transform.position.y >= cameraBounds1.y)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D gObject)
	{
		if(gObject.gameObject.tag == "Meteor")
		{
			Destroy (gameObject);

		}
	}
}
