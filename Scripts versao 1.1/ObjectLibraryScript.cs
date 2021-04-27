using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectLibraryScript : MonoBehaviour {

	public GameObject playerShip;
	public GameObject playerShipLaser;
	public GameObject enemyLaser;
	public GameObject enemyLevel00;
	public GameObject enemyLevel01;

	private List<GameObject>playerShipList;
	public List<GameObject>playerShipLaserList;
	private List<GameObject>enemyLaserList;
	private List<GameObject>enemyLevel00List;
	private List<GameObject>enemyLevel01List;

	public GameObject GetLaser(string instanceName)
	{
		GameObject instance = null;
		switch(instanceName)
		{
            case "EnemyLevel00":
                if (enemyLevel00List.Count > 0)
                {
                    instance = enemyLevel00List[0];
                    instance.SetActive(true);
                    enemyLevel00List.Remove(enemyLevel00List[0]);
                }
                else
                {
                    instance = Instantiate(enemyLevel00, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    instance.name = "EnemyLevel00";
                }
                break;

            case "EnemyLevel01":
                if (enemyLevel01List.Count > 0)
                {
                    instance = enemyLevel01List[0];
                    instance.SetActive(true);
                    enemyLevel01List.Remove(enemyLevel01List[0]);
                }
                else
                {
                    instance = Instantiate(enemyLevel01, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    instance.name = "EnemyLevel01";
                }
                break;

            case "PlayerShipLaser":
                if (playerShipLaserList.Count > 0)
                {
                    instance = playerShipLaserList[0];
                    instance.SetActive(true);
                    playerShipLaserList.Remove(playerShipLaserList[0]);
                }
                else
                {
                    instance = Instantiate(playerShipLaser, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    instance.name = "PlayerShipLaser";

                }
                break;

            case "EnemyLaser":
                if (enemyLaserList.Count > 0)
                {
                    instance = enemyLaserList[0];
                    instance.SetActive(true);
                    enemyLaserList.Remove(enemyLaserList[0]);
                }
                else
                {
                    instance = Instantiate(enemyLaser, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    instance.name = "EnemyLaser";

                }
                break;
            default:
                break;
		}
        return instance;
	}

	public void ReplaceInstance(GameObject instance)
	{
		//string instanceName = instance.name;
		switch(instance.name)
		{
            case "PlayerShipLaser":
                instance.gameObject.SetActive(false);
                playerShipLaserList.Add(instance);
                break;
            case "EnemyLaser":
                instance.gameObject.SetActive(false);
                enemyLaserList.Add(instance);
                break;
            case "EnemyLevel00":
                instance.gameObject.SetActive(false);
                enemyLevel00List.Add(instance);
                break;
            case "EnemyLevel01":
                instance.gameObject.SetActive(false);
                enemyLevel01List.Add(instance);
                break;
            default:
			break;
		}
		
	}

	// Use this for initialization
	void Awake ()
	{
		playerShipList = new List<GameObject> ();
		playerShipLaserList = new List<GameObject> ();
		enemyLaserList = new List<GameObject> ();
		enemyLevel00List = new List<GameObject> ();
		enemyLevel01List = new List<GameObject> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
