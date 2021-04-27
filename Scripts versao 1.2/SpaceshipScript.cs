using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpaceshipScript : MonoBehaviour {

	float speed = 1;
	public Camera mainCamera;
	public StickController stick;
	public ButtonController fireButton;
	Animator animations;
	public GameObject bullet;
	public GameObject explosion;
	AudioSource shootSound;

	// Use this for initialization
	void Start () {
		animations = GetComponent<Animator> ();
		shootSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		screenLimits ();
		if(fireButton.buttonDown || Input.GetMouseButtonDown(0))
		{
			shootSound.Play ();
			Instantiate (bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
		}
		float xVector = stick.getAxis ("Horizontal");
		float yVector = stick.getAxis ("Vertical");
		transform.Translate (xVector * speed * Time.deltaTime, yVector * speed * Time.deltaTime, 0);
		Debug.Log (Input.mousePosition.x+" / "+Input.mousePosition.y);
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		transform.position = new Vector3 (r.origin.x, r.origin.y, 0);
	}

	void screenLimits()
	{
		float distance = (transform.position - mainCamera.transform.position).z;
		// camerabouns0.x = left side; camerabouns0.y = botton side; camerabouns1.x = right side; camerabouns1.y = top side;
		Vector3 cameraBounds0 = mainCamera.ViewportToWorldPoint (new Vector3 (0F, 0F, distance));
		Vector3 cameraBounds1 = mainCamera.ViewportToWorldPoint (new Vector3 (1F, 1F, distance));
		if(transform.position.x <= cameraBounds0.x)
		{
			transform.position = new Vector2 (cameraBounds0.x, transform.position.y);
		}
		if(transform.position.x >= cameraBounds1.x)
		{
			transform.position = new Vector2 (cameraBounds1.x, transform.position.y);
		}
		if(transform.position.y <= cameraBounds0.y)
		{
			transform.position = new Vector2 (transform.position.x, cameraBounds0.y);
		}
		if(transform.position.y >= cameraBounds1.y)
		{
			transform.position = new Vector2 (transform.position.x, cameraBounds1.y);
		}
	}

	public void gameOver ()
	{
		GameObject explo =  Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy (explo, 1.9f);
		gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D gObject)
	{
		if(gObject.gameObject.tag == "Meteor")
		{
			
		}
	}
}
