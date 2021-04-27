using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShipScript : MonoBehaviour {

    public float speed = 2;
    public int shootLimit = 5;
    public GameObject laser;
	private List<GameObject> lasers;

	// Use this for initialization
	void Start ()
    {
		lasers = new List<GameObject>();
        for (int i=0; i < shootLimit; i++)
        {
			lasers.Add( Instantiate(laser, transform.position, transform.rotation) as GameObject);
			lasers[i].GetComponent<LaserScript> ().playerShip = this;
			lasers[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }

        float yAxis = Input.GetAxis("Vertical");
		transform.Translate(0, Time.deltaTime * speed * yAxis, 0);
		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		if (transform.position.y <= leftBotton.y+GetComponent<SpriteRenderer>().bounds.size.y/2)
		{
			transform.position = new Vector2 ( transform.position.x, leftBotton.y+GetComponent<SpriteRenderer>().bounds.size.y/2);
		}
		else if(transform.position.y >= rightTop.y-GetComponent<SpriteRenderer>().bounds.size.y/2)
		{
			transform.position = new Vector2 ( transform.position.x, rightTop.y-GetComponent<SpriteRenderer>().bounds.size.y/2);
		}
    }

    void shoot()
    {
		if(lasers.Count > 0)
		{
			lasers[0].gameObject.SetActive(true);
			lasers[0].transform.position = transform.position;
			lasers[0].transform.rotation = transform.rotation;
			lasers.Remove (lasers[0]);
		}
    }

	public void reload(GameObject laserEnded)
	{
		laserEnded.SetActive (false);
		lasers.Add (laserEnded);
	}

    void OnTriggerEnter2D(Collider2D go)
    {
        if (go.gameObject.tag == "Enemy00")
        {
            Debug.Log("PlayerShip with enemy00");
        }
        if (go.gameObject.tag == "Enemy01")
        {
            Debug.Log("PlayerShip with enemy01");
        }
    }
}
