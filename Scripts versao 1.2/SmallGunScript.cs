using UnityEngine;
using System.Collections;

public class SmallGunScript : MonoBehaviour {

	public GameObject bulletPlace;
	public int ammoAmount = 10;
	public string gunId = "SmallGun";
	public Vector3 relativePosirion;
	public int damage = 1;



	public void shoot(){
		if(ammoAmount>0){
			GameObject bullet = Instantiate(Resources.Load("prefabs/guns/Bullet"), bulletPlace.transform.position, bulletPlace.transform.rotation ) as GameObject;
			bullet.GetComponent<BulletScript>().damage = damage;
			ammoAmount--;
		}
	}
}
