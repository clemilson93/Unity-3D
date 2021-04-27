using UnityEngine;

using System.Collections;

using System.Collections.Generic;


public class EnemySpawnerScript : MonoBehaviour
{


	public GameObject enemy00;

	public GameObject enemy01;

	List<GameObject>enemies00;

	List<GameObject>enemies01;

	public int numberOfEnemies00 = 5;

	public int numberOfEnemies01 = 5;

	float initialTime = 0;

	// Use this for initialization
	void Start ()
	{
		initialTime = Mathf.Floor (Time.time);
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
	// Update is called once per frame

	void Update ()

	{
		StartCoroutine ("spawnEnemy00");
		StartCoroutine ("spawnEnemy01");
	}
	IEnumerator spawnEnemy00()

	{
		if(Mathf.Floor(Time.time) - initialTime == 5)
		{
			if(enemies00.Count>0)
			{
				enemies00 [0].gameObject.SetActive (true);
				enemies00 [0].gameObject.GetComponent<Enemy00Script> ().spawn ();
				enemies00.Remove (enemies00[0]);
				initialTime = Mathf.Floor (Time.time);
			}
		}
		yield return null;
	}

	IEnumerator spawnEnemy01()
	{
		if(Mathf.Floor(Time.time) - initialTime == 5)
		{
			if(enemies01.Count>0)
			{
				enemies01 [0].gameObject.SetActive (true);
				enemies01 [0].gameObject.GetComponent<Enemy01Script> ().spawn ();
				enemies01.Remove (enemies01[0]);
				initialTime = Mathf.Floor (Time.time);
			}

		}
		yield return null;
	}
}