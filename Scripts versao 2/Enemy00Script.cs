using UnityEngine;
using System.Collections;

public class Enemy00Script : MonoBehaviour {

    public float speed = 1;
    public int shieldLevel = 3;
	public PlayerScript playerScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Time.deltaTime * speed * -1, 0, 0);
		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		if (transform.position.x <= leftBotton.x - GetComponent<SpriteRenderer>().bounds.size.x)
		{
			float y = Random.Range (rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y/2, leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y/2);
			transform.position = new Vector2 ( rightTop.x + GetComponent<SpriteRenderer>().bounds.size.x, y);
		}
	}

	public void spawn ()
	{
		shieldLevel = 3;
		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		float y = Random.Range (rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y/2, leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y/2);
		transform.position = new Vector2 ( rightTop.x + GetComponent<SpriteRenderer>().bounds.size.x, y);
	}

    void OnTriggerEnter2D(Collider2D go)
    {
        if (go.gameObject.tag == "Laser")
        {
			playerScript.scores += 5;
        }
        if (go.gameObject.tag == "PlayerShip")
        {
			playerScript.lives -= 1;
        }
    }
}
