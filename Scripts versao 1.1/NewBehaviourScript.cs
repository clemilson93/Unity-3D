using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	int xVector = -1, yVector = 1, speed = 1;
	public Texture2D bottomPanel;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = (transform.position - Camera.main.transform.position).z;
		Debug.Log (Camera.main.ViewportToWorldPoint(new Vector3(1F, 1F, distance)));
		Vector3 cameraBounds0 = Camera.main.ViewportToWorldPoint (new Vector3 (0F, 0F, distance));
		Vector3 cameraBounds1 = Camera.main.ViewportToWorldPoint (new Vector3 (1F, 1F, distance));


		transform.Translate (xVector * speed * Time.deltaTime, yVector * speed * Time.deltaTime, 0);
		if(transform.position.x <= cameraBounds0.x || transform.position.x >= cameraBounds1.x)
		{
			xVector = xVector * -1;
		}
		if(transform.position.y <= cameraBounds0.y || transform.position.y >= cameraBounds1.y)
		{
			yVector = yVector * -1;
		}
	}
}
