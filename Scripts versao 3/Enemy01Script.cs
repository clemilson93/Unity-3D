using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy01Script : MonoBehaviour {
	public float speed;
    public int shieldLevel;
	private List <GameObject> lasers01;
	public GameObject laser01;
	public int shootLimit;
	public int range;
	
	// Use this for initialization
	void Start ()
	{
		speed = 0.5f;
		shieldLevel = 6;
		range = 5;
		shootLimit = 1;
		lasers01 = new List<GameObject> ();
		for(int i=0; i<shootLimit; i++)
		{
			GameObject obj = Instantiate (laser01, transform.position, transform.rotation) as GameObject;
			obj.GetComponent<Enemy01LaserScript> ().enemy01Script = this;
			obj.SetActive(false);
			lasers01.Add (obj);

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(shieldLevel <= 0)
		{
			//GameObject.Find ("Enemy spawner").GetComponent<EnemySpawnerScript> ().replaceEnemy (gameObject);
		}

		if(Mathf.Floor(Random.value* 2) <= 1)
		{
			if(lasers01.Count > 0)
			{
				lasers01[0].gameObject.SetActive(true);
				lasers01[0].gameObject.GetComponent<Enemy01LaserScript> ().spawn( new Vector2(transform.position.x - GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y), transform.rotation);
				lasers01.Remove (lasers01[0]);
			}
		}

		transform.Translate(Time.deltaTime * speed * -1, 0, 0);
		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		if (transform.position.x <= leftBotton.x - GetComponent<SpriteRenderer>().bounds.size.x)
		{
			float y = Random.Range (rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y/2, leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y/2);
			transform.position = new Vector2 ( rightTop.x + GetComponent<SpriteRenderer>().bounds.size.x, y);
		}
	}

	public void enemyReload(GameObject laserEnded)
	{
		laserEnded.SetActive (false);
		lasers01.Add (laserEnded);
	}

	public void spawn ()
	{
		shieldLevel = 6;
		Vector3 leftBotton = Camera.main.ViewportToWorldPoint (new Vector3(0, 0, transform.position.z));
		Vector3 rightTop = Camera.main.ViewportToWorldPoint (new Vector3(1, 1, transform.position.z));
		float y = Random.Range (rightTop.y - GetComponent<SpriteRenderer>().bounds.size.y/2, leftBotton.y + GetComponent<SpriteRenderer>().bounds.size.y/2);
		transform.position = new Vector2 ( rightTop.x + GetComponent<SpriteRenderer>().bounds.size.x, y);
	}
	void OnTriggerEnter2D(Collider2D go)
	{
        	if (go.gameObject.tag == "Laser")
        	{
				shieldLevel -= 1;
        	}
    	}
}
