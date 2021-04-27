using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

    public float speed = 4;
	public PlayerShipScript playerShip;
	public float range = 5;
	Vector2 startPoint;

	// Use this for initialization
	void Start ()
	{
		startPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Vector2.Distance(startPoint, transform.position) >= range)
		{
			playerShip.reload (gameObject);
		}
        transform.Translate(Time.deltaTime * speed, 0, 0);

		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		if (transform.position.x <= leftBotton.x + GetComponent<SpriteRenderer>().bounds.size.x/2)
		{
			transform.position = new Vector2 ( rightTop.x - GetComponent<SpriteRenderer>().bounds.size.x, rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y);
		}

	}

    void OnTriggerEnter2D(Collider2D go)
    {
        if (go.gameObject.tag == "Enemy00")
        {
            Debug.Log("Laser with enemy00");
        }
        if (go.gameObject.tag == "Enemy01")
        {
            Debug.Log("Laser with enemy01");
        }
    }
}
