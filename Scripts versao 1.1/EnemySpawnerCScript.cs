using UnityEngine;

using System.Collections;

using System.Collections.Generic;


public class EnemySpawnerCScript : MonoBehaviour
{


	public GameObject enemy00;

	public GameObject enemy01;

	List<GameObject>enemies00;

	List<GameObject>enemies01;

	public int numberOfEnemies00;

	public int numberOfEnemies01;

	float initialTime00 = 0;
	float initialTime01 = 0;

	// Use this for initialization
	void Start ()
	{
		numberOfEnemies00 = 5;
		numberOfEnemies01 = 5;
		initialTime00 = Mathf.Floor (Time.time);
		initialTime01 = Mathf.Floor (Time.time);
		enemies00 = new List<GameObject>();
		enemies01 = new List<GameObject>();
		for (int i=0; i < numberOfEnemies00; i++)
		{
			enemies00.Add( Instantiate(enemy00, transform.position, transform.rotation) as GameObject);
			enemies00[i].SetActive(false);
		}
		for (int i=0; i < numberOfEnemies01; i++)
		{
			enemies01.Add( Instantiate(enemy01, transform.position, transform.rotation) as GameObject);
			enemies01[i].SetActive(false);
		}
	}

	public void replaceEnemy(GameObject enemyEnded)
	{
		enemyEnded.gameObject.SetActive (false);
		if(enemyEnded.gameObject.tag == "Enemy00")
		{
			enemies00.Add (enemyEnded);
			Debug.Log (enemyEnded.gameObject.tag);
		}
		else if(enemyEnded.gameObject.tag == "Enemy01")
		{
			enemies01.Add (enemyEnded);
			Debug.Log (enemyEnded.gameObject.tag);
		}
	}

	// Update is called once per frame

	void Update ()

	{
		if(Mathf.Floor(Time.time) - initialTime00 >= 2)
		{
			if(enemies00.Count>0)
			{
				enemies00 [0].gameObject.SetActive (true);
				enemies00 [0].gameObject.GetComponent<Enemy00Script> ().spawn ();
				enemies00.Remove (enemies00[0]);
				initialTime00 = Mathf.Floor (Time.time);
			}
		}
		if(Mathf.Floor(Time.time) - initialTime01 >= 3)
		{
			if(enemies01.Count>0)
			{
				enemies01 [0].gameObject.SetActive (true);
				enemies01 [0].gameObject.GetComponent<Enemy01Script> ().spawn ();
				enemies01.Remove (enemies01[0]);
				initialTime01 = Mathf.Floor (Time.time);
			}

		}
	}
}