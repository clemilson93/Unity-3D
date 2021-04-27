using UnityEngine;
using System.Collections;

public class EnemyGunScript : MonoBehaviour {

	public GameObject bulletPlace;
	public int ammoAmountValue = 5;
	
	void Start () {
		bulletPlace = GameObject.Find("EnemyBulletPlace");
	}
	
	void Update () {

	}
	

}
